using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using StratixRuanBusinessLogic.CoreData;
using StratixRuanBusinessLogic.Ruan.Serialization;
using StratixRuanDataLayer;
using System.Threading;

namespace StratixRuanBusinessLogic.Ruan.Action
{
    public static partial class RuanAction
    {
        public class TaFileChanges
        {
            public string ShipmentId { get; set; }
            //public Carrier NewCarrier { get; set; }
            public List<TaShipUnit> PreChangeShipUnits { get; set; } = new List<TaShipUnit>();
            public List<TaShipUnit> AfterChangeShipUnits { get; set; } = new List<TaShipUnit>();

            public class TaShipUnit
            {
                public TaShipUnit(long? shipUnitId, long? locationNumber, long? carrierNumber, string shipmentId)
                {
                    ShipUnitId = shipUnitId;
                    LocationNumber = locationNumber;
                    CarrierNumber = carrierNumber;
                    ShipmentId = shipmentId;
                }

                public TaShipUnit(string shipUnitId, long? locationNumber, long? carrierNumber, string shipmentId)
                {
                    ShipUnitId = Convert.ToInt64(shipUnitId);
                    LocationNumber = locationNumber;
                    CarrierNumber = carrierNumber;
                    ShipmentId = shipmentId;
                }

                public long? ShipUnitId { get; private set; }
                public long? LocationNumber { get; private set; }
                public long? CarrierNumber { get; private set; }
                public string ShipmentId { get; private set; }
            }
        }

        public static void ProcessTaTest(IRuanStratixClass xmlData)
        {
            var test = Utilities.SerializeObjectToStringUtf8(xmlData);
            ProcessTa((APITransportationShipment)xmlData);
        }

        public static void ProcessTa(APITransportationShipment ta)
        {
            var test = Utilities.SerializeObjectToStringUtf8(ta);
            if (string.IsNullOrWhiteSpace(ta.ShipmentNumber))
            {
               // throw new RuanJobException($"No Shipment Number.");
            }
            else if (ta.ShipmentNumber.ToUpper().StartsWith("INV"))
            {
                return;
            }

            //determine type of TA
            //ignore TNT Orders
            if (ta.Stops.All(s => s.Orders.All(o => o.OrderType == "SALES_ORDER" && o.OrderId.StartsWith("TNT"))))
            {
                return;
            }

            //before phase 2 ignore purchase orders,
            //TODO: for phase2 logic should change to any then process PO logic
            if (ta.Stops.All(s => s.Orders.All(o => o.OrderType == "PURCHASE_ORDER" || o.OrderType == "RETURNS")))
            {
                //ignore but don't throw error
                return;
            }

            if (ta.TransactionType == "D")
            {
                DeleteTransportFromStratix(ta);
            }

            else if (ta.Stops.Any(s => s.Orders.Any(o => o.OrderType == "SALES_ORDER" || o.OrderType == "TRANSFERS")))
            {
                TAtoStratix(ta);
            }
        }

        public static void test(IRuanStratixClass xmlData)
        {

        }

        public static void TAtoStratix(APITransportationShipment ta)
        {
            TaFileChanges taFileChanges = new TaFileChanges();
            Regex validTslacTest = new Regex("^[0-9]{6,}(?=-).+$");

            //Tuple Item1 - RuanNumber, Item2- LocationNumber, Item3 - TruckReleaseNumber, Item4-SalesOrderRelease, Item5-TransferHeaderNumber
            //List<Tuple<string, long, long, long?, long?>> opLocationsWithTaDetailsForEmail = new List<Tuple<string, long, long, long?, long?>>();
            //List<EmailHelper.RuanTaShippingEmailHelper> opLocationsWithTaDetailsForEmail = new List<EmailHelper.RuanTaShippingEmailHelper>();

            //ManifestHeaderList manifestListByRuanShipmentID = ManifestHeader.FetchAllByRuanShipmentID(ta.ShipmentNumber);

            ////check to see if there are any valid tslac, if there are continue and ignore invalid inline
            //Regex validTslacTest = new Regex("^[0-9]{6,}(?=-).+$");
            //if (!ta.ShipmentUnits.Any(su => validTslacTest.IsMatch(su.ShipUnitId)))
            //{
            //    //throw new RuanJobException($"All ShipmentIds are invalid : {ta.ShipmentNumber}");
            //    return;
            //}

            //List<TaShipUnit> shipUnits = ta.ShipmentUnits.ToList();

            if (string.IsNullOrWhiteSpace(ta.CarrierScac))
            {
                throw new RuanJobException($"Shipment Number {ta.ShipmentNumber}, has no Carrier SCAC.");
            }

            List<TaShipUnit> shipUnits = ta.ShipmentUnits.ToList();
            TransportationArrangedStop[] pickupStops = ta.Stops.Where(x => x.StopType == "P").ToArray();
            TransportationArrangedStop[] deliveryStops = ta.Stops.Where(x => x.StopType == "D").ToArray();
            DateTime? dateShipped = null;


            foreach (TransportationArrangedStop pickupStop in pickupStops)
            {
                if (DateTime.TryParse(pickupStop.StopPlannedDepartureDateTime, out DateTime dateShippedTemp))
                {
                    dateShipped = dateShippedTemp;
                }
                else
                {
                    throw new RuanJobException($"Shipment Number {ta.ShipmentNumber}, Invalid date {pickupStop.StopPlannedDepartureDateTime}.");
                }

                
                long interchangeNumberTransport = StratixHelperData.GetMaxInterchangeNumber() + 1;
                XCTI18 objXcti18 = new XCTI18();
                objXcti18.i18_intchg_no = interchangeNumberTransport;
                string formatDate = "yyyy-MM-dd HH:mm:ss";
                objXcti18.i18_crtd_dtts = $"'{DateTime.Now.ToString(formatDate)}'";
                objXcti18.i18_trrte = "RUAN";
                objXcti18.i18_dlvy_mthd = "OC";
                objXcti18.i18_cmpy_id = "HSP";
                objXcti18.i18_intchg_pfx = "XI";
                objXcti18.i18_rte_clr = string.Empty;

                string carrierInfo = $"{ta.CarrierScac}*{ta.CarrierName}";
                if (carrierInfo.Length > 35)
                {
                    carrierInfo = carrierInfo.Substring(0, 35);
                }
                objXcti18.i18_crr_nm = carrierInfo;

                objXcti18.i18_frt_exrt = 1.00000000;
                objXcti18.i18_frt_ex_rt_typ = "V";
                objXcti18.i18_sch_rmk = "remark";
                objXcti18.i18_trctr = 1;
                objXcti18.i18_trlr_typ = "FB";
                objXcti18.i18_max_stp = deliveryStops.Length + pickupStops.Length;

                objXcti18.i18_crr_ref_no = ta.ShipmentNumber;
                objXcti18.i18_frt_cry = "USD";
                objXcti18.i18_frt_ven_id = "9999";
                objXcti18.i18_sch_dtts = $"'{dateShipped.Value.ToString(formatDate)}'";

                long orderID = 0;
                foreach (Order order in pickupStop.Orders)
                {
                    string orderIdWithReleaseInformation = order.OrderId;
                    char separationCharacter = '_';

                    int separationCharacterCount = orderIdWithReleaseInformation.Count(x => (x == separationCharacter));
                    if (separationCharacterCount != 2)
                    {
                        throw new RuanJobException($"Invalid OrderID {orderIdWithReleaseInformation}.");
                    }

                    var orderSplitArray = order.OrderId.Split(separationCharacter);//First array value is the OrderID, second is the Detail and the third array is the release item id.
                    objXcti18.i18_trpln_whs = StratixHelperData.GetShipFromWarehouseForOrder(orderSplitArray[0]);

                    double weightTotal = 0;
                    foreach (TaShipUnit shipUnit in shipUnits)
                    {
                        //skip invalid shipunits
                        //if (!validTslacTest.IsMatch(shipUnit.ShipUnitId))
                        //{
                        //    continue;
                        //}

                        string shipUnitBase = shipUnit.ShipUnitId.Contains("-") ? shipUnit.ShipUnitId.Substring(0, shipUnit.ShipUnitId.IndexOf("-", StringComparison.Ordinal)) : shipUnit.ShipUnitId;

                        var shipUnitBaseArray = shipUnitBase.Split(separationCharacter);//First array value is the shipUnitBase(order or transferid)
                        

                        if (!long.TryParse(shipUnitBaseArray[0], out long shipUnitId))
                        {
                            throw new RuanJobException($"Shipment Unit {shipUnit.ShipUnitId} should have all numeric digits before the first dash.");
                        }

                        Order orderWithinShipUnit = pickupStop.Orders.FirstOrDefault(x => x.OrderId == shipUnitBase);
                        string orderId = orderWithinShipUnit?.OrderId;
                        if (orderId == null)
                        {
                            continue;
                        }
                        else
                        {
                            double weight = shipUnit.Contents.Sum(x =>
                            {
                                if (double.TryParse(x.Weight, out weight))
                                {
                                    return weight;
                                }
                                else
                                {
                                    return 0;
                                }
                            });
                            weightTotal = weightTotal + weight;
                        }

                        
                    }

                    objXcti18.i18_max_wgt = weightTotal;
                    XCTI18.AddTransport(objXcti18);

                    Thread.Sleep(5000);
                    long transportNumber = StratixHelperData.GetTransportNumber(interchangeNumberTransport);
                    

                    XCTI21 objXcti21 = new XCTI21();
                    long interchangeNumberTransportActivity = StratixHelperData.GetMaxInterchangeNumber() + 1;
                    objXcti21.i21_intchg_no = interchangeNumberTransportActivity;
                    objXcti21.i21_intchg_itm = 1;

                    objXcti21.i21_crtd_dtts = $"'{DateTime.Now.ToString(formatDate)}'";
                    objXcti21.i21_transp_no = transportNumber;

                    TRTTAVCondensed tRTTAVCondensedObject = TRTTAVCondensed.GetTrttavCondensed(orderSplitArray[0], orderSplitArray[1], orderSplitArray[2]);
                    objXcti21.i21_actvy_pfx = tRTTAVCondensedObject.tav_trac_pfx;
                    objXcti21.i21_actvy_no = tRTTAVCondensedObject.tav_trac_no;
                    objXcti21.i21_actvy_itm = tRTTAVCondensedObject.tav_trac_itm;
                    objXcti21.i21_plnd_trs_pcs = tRTTAVCondensedObject.tav_bal_pcs;
                    objXcti21.i21_plnd_trs_msr = tRTTAVCondensedObject.tav_bal_msr;
                    objXcti21.i21_plnd_trs_wgt = tRTTAVCondensedObject.tav_bal_wgt;

                    XCTI21.PlanTransportActivity(objXcti21);
                }
            }


           

            //Carrier carrier = Carrier.FetchSingleBySCACCode(ta.CarrierScac);

            //if (carrier == null)
            //{
            //    Carrier newCarrier = new Carrier()
            //    {
            //        CarrierCode = ta.CarrierScac,
            //        SCACCode = ta.CarrierScac,
            //        Description = ta.CarrierName
            //    };
            //    try
            //    {
            //        newCarrier.Save();
            //    }
            //    catch (Exception e)
            //    {
            //        throw new RuanJobException($"Failed to insert new carrier SCAC {ta.CarrierScac}.", e);
            //    }

            //    carrier = Carrier.FetchSingleBySCACCode(ta.CarrierScac);
            //}

            //taFileChanges.ShipmentId = ta.ShipmentNumber;
            //taFileChanges.NewCarrier = carrier;

            //List<ManifestCross> oldShipUnitList = ManifestCross.FetchAllShipmentsByRuanShipmentId(ta.ShipmentNumber).ToList();

            //foreach (ManifestCross mx in oldShipUnitList)
            //{
            //    taFileChanges.PreChangeShipUnits.Add(new TaFileChanges.TaShipUnit(mx.LoadAuthorizationCrossNumber, mx.LocationNumber, mx.CarrierNumber, mx.ShipmentID));
            //}

            //TransportationArrangedStop[] pickupStops = ta.Stops.Where(x => x.StopType == "P").ToArray();

            //List<RuanCostStop> stopCosts = new List<RuanCostStop>();
            ////get total cost by stop and apply stop cost to manifest cross
            //foreach (TransportationArrangedStop stop in pickupStops)
            //{
            //    RuanCostStop stopCost = new RuanCostStop(stop.StopNumber);
            //    foreach (Order order in stop.Orders)
            //    {
            //        stopCost.AddTruckRelease(order.OrderId);
            //        foreach (TransportationArrangedOrderCost orderCost in ta.OrderCosts)
            //        {
            //            if (order.OrderId == orderCost.OrderId)
            //            {
            //                stopCost.AddCost(orderCost.CostAmount);
            //            }
            //        }
            //    }

            //    stopCosts.Add(stopCost);
            //}

            //foreach (TaShipUnit shipUnit in shipUnits)
            //{
            //    //skip invalid shipunits
            //    if (!validTslacTest.IsMatch(shipUnit.ShipUnitId))
            //    {
            //        continue;
            //    }

            //    string shipUnitBase = shipUnit.ShipUnitId.Contains("-") ? shipUnit.ShipUnitId.Substring(0, shipUnit.ShipUnitId.IndexOf("-", StringComparison.Ordinal)) : shipUnit.ShipUnitId;

            //    if (!long.TryParse(shipUnitBase, out long shipUnitId))
            //    {
            //        throw new RuanJobException($"Shipment Unit {shipUnit.ShipUnitId} should have all numeric digits before the first dash.");
            //    }

            //    LoadAuthorizationCross lac = LoadAuthorizationCross.FetchByNumber(shipUnitId);

            //    if (lac == null)
            //    {
            //        try
            //        {
            //            Module mod = Module.FetchByCode("AD");
            //            ErrorLogT errorLogT = new ErrorLogT(mod, mod, "TA", $"Shipment Number {ta.ShipmentNumber}, invalid TSLAC {shipUnit.ShipUnitId}.", null, Environment.StackTrace);
            //            errorLogT.Save();
            //        }
            //        catch
            //        {
            //            //fail silently
            //        }

            //        throw new RuanJobException($"Shipment Number {ta.ShipmentNumber}, invalid TSLAC {shipUnit.ShipUnitId}.");
            //    }

            //    DateTime? dateShipped = null;

            //    if (pickupStops.Length == 0)
            //    {
            //        throw new RuanJobException($"Shipment Number {ta.ShipmentNumber}, No pickup stops.");
            //    }

            //    double cost = 0;
            //    cost = stopCosts.Single(sc => sc.TruckReleases.Contains(shipUnitId)).TotalCost;

            //    long? pickupStopSequence = null;
            //    long? dropoffStopSequence = null;
            //    string trackingUrl = null;

            //    foreach (TransportationArrangedStop stop in pickupStops)
            //    {
            //        Order order = stop.Orders.FirstOrDefault(x => x.OrderId == shipUnitBase);
            //        string orderId = order?.OrderId;
            //        if (orderId == null)
            //        {
            //            continue;
            //        }
            //        else
            //        {
            //            try
            //            {
            //                if (order.References != null)
            //                {
            //                    if (order.References.Any(r => r.ReferenceNumberType == "RUAN_TRACKING_ORDER_URL"))
            //                    {
            //                        trackingUrl = order.References?.FirstOrDefault(r => r.ReferenceNumberType == "RUAN_TRACKING_ORDER_URL")?.ReferenceNumberValue;
            //                    }
            //                }
            //            }
            //            catch
            //            {
            //                //fail silently
            //            }
            //        }

            //        if (stop.StopPlannedDepartureDateTime == null)
            //        {
            //            continue;
            //        }

            //        if (long.TryParse(stop.StopNumber, out long tempStop))
            //        {
            //            pickupStopSequence = tempStop;
            //        }

            //        if (DateTime.TryParse(stop.StopPlannedDepartureDateTime, out DateTime dateShippedTemp))
            //        {
            //            dateShipped = dateShippedTemp;
            //        }
            //        else
            //        {
            //            throw new RuanJobException($"Shipment Number {ta.ShipmentNumber}, Invalid date {stop.StopPlannedDepartureDateTime}.");
            //        }

            //    }

            //    string estTimeArrival = null;
            //    TransportationArrangedStop[] deliveryStops = ta.Stops.Where(x => x.StopType == "D").ToArray();

            //    if (deliveryStops.Length == 0)
            //    {
            //        throw new RuanJobException($"Shipment Number {ta.ShipmentNumber}, No delivery stops.");
            //    }

            //    foreach (TransportationArrangedStop stop in deliveryStops)
            //    {
            //        string orderId = stop.Orders.FirstOrDefault(x => x.OrderId == shipUnitBase)?.OrderId;
            //        if (orderId == null)
            //        {
            //            continue;
            //        }

            //        estTimeArrival = stop.StopPlannedArrivalDateTime;
            //        if (long.TryParse(stop.StopNumber, out long tempStop))
            //        {
            //            dropoffStopSequence = tempStop;
            //        }

            //    }

            //    double weight = shipUnit.Contents.Sum(x =>
            //    {
            //        if (double.TryParse(x.Weight, out weight))
            //        {
            //            return weight;
            //        }
            //        else
            //        {
            //            return 0;
            //        }
            //    });

            //    ManifestCross mc = ManifestCross.FetchSingleByLoadAuthCross(lac.LoadAuthorizationCrossNumber);
            //    long? currentManifestNumber = ManifestHeader.FetchManifestHeaderNumberByLoadAuthorizationCrossNumber(lac.LoadAuthorizationCrossNumber);
            //    //The above call should fetch a single number if any. If there are multiples, it should error out and stop processing.
            //    //Better to have TA Fail than incorrect ManifestCRoss and manifest number.

            //    if (mc == null)
            //    {
            //        mc = new ManifestCross
            //        {
            //            LoadAuthorizationCrossNumber = lac.LoadAuthorizationCrossNumber,
            //            ManifestHeaderNumber = currentManifestNumber,
            //            SalesOrderReleaseNumber = lac.SalesOrderReleaseNumber,
            //            TransferDetailNumber = lac.TransferDetailNumber,
            //            SalesShipAuthorizationDetailNumber = lac.SalesShipAuthorizationDetailNumber,
            //            LocationNumber = lac.LocationNumber,
            //            TransferHeaderNumber = lac.TransferHeaderNumber,
            //            StatusNumber = lac.StatusNumber,
            //            CarrierNumber = carrier.Number,
            //            Weight = weight,
            //            DateShipped = dateShipped,
            //            EstTimeArrival = estTimeArrival,
            //            ShipmentID = ta.ShipmentNumber,
            //            TransportMode = ta.ModeOfTransport,
            //            StopCount = ta.Stops.Length,
            //            TotalEstimatedCost = cost,
            //            Equipment = ta.Equipment,
            //            PickupStopSequence = pickupStopSequence,
            //            DropoffStopSequence = dropoffStopSequence,
            //            DeliveryTrackingUrl = trackingUrl
            //        };
            //    }
            //    else
            //    {
            //        taFileChanges.AfterChangeShipUnits.Add(new TaFileChanges.TaShipUnit(mc.LoadAuthorizationCrossNumber, lac.LocationNumber, mc.CarrierNumber, mc.ShipmentID));

            //        mc.LoadAuthorizationCrossNumber = lac.LoadAuthorizationCrossNumber;
            //        mc.ManifestHeaderNumber = currentManifestNumber;
            //        mc.SalesOrderReleaseNumber = lac.SalesOrderReleaseNumber;
            //        mc.TransferDetailNumber = lac.TransferDetailNumber;
            //        mc.SalesShipAuthorizationDetailNumber = lac.SalesShipAuthorizationDetailNumber;
            //        mc.LocationNumber = lac.LocationNumber;
            //        mc.TransferHeaderNumber = lac.TransferHeaderNumber;
            //        mc.StatusNumber = lac.StatusNumber;
            //        mc.CarrierNumber = carrier.Number;
            //        mc.Weight = weight;
            //        mc.DateShipped = dateShipped;
            //        mc.EstTimeArrival = estTimeArrival;
            //        mc.ShipmentID = ta.ShipmentNumber;
            //        mc.TransportMode = ta.ModeOfTransport;
            //        mc.StopCount = ta.Stops.Length;
            //        mc.TotalEstimatedCost = cost;
            //        mc.Equipment = ta.Equipment;
            //        mc.PickupStopSequence = pickupStopSequence;
            //        mc.DropoffStopSequence = dropoffStopSequence;
            //        if (!string.IsNullOrEmpty(trackingUrl))
            //        {
            //            mc.DeliveryTrackingUrl = trackingUrl;
            //        }
            //    }

            //    bool taFileHasChanged = TaFileHasChanges(ta); //calculate once

            //    List<string> changes = mc.GetChangedProperties();
            //    if (changes.Count > 0)
            //    {
            //        ManifestHeader manifest = ManifestHeader.FetchByNumber(mc.ManifestHeaderNumber);

            //        if (manifest != null)
            //        {
            //            manifest.FreightCost = mc.TotalEstimatedCost;
            //            manifest.CarrierNumber = mc.CarrierNumber;

            //            if (manifest.GetChangedProperties().Contains("CarrierNumber"))
            //            {
            //                manifest.CarrierChangedByTaFile = true;
            //            }

            //            if (taFileHasChanged)
            //            {
            //                manifest.ChangedByTAFile = true;
            //            }

            //            manifest.Save();
            //            manifest.CalculateFreightCosting();
            //        }
            //    }


            //    Status openStatus = GlobalState.Statuses.StatusByCodeAndModule("OPEN", "TS");
            //    Status builtStatus = GlobalState.Statuses.StatusByCodeAndModule("BUILT", "TS");
            //    Status inProcessStatus = GlobalState.Statuses.StatusByCodeAndModule("In Process", "TS");
            //    Status cancelledStatus = GlobalState.Statuses.StatusByCodeAndModule("CANCELLED", "TS");
            //    Status completeStatus = GlobalState.Statuses.StatusByCodeAndModule("COMPLETE", "TS");
            //    Status retenderStatus = GlobalState.Statuses.StatusByCodeAndModule("RETENDER", "TS");
            //    Status voidStatus = GlobalState.Statuses.StatusByCodeAndModule("Void", "TS");

            //    if (lac.Status.StatusNumber == retenderStatus.StatusNumber)
            //    {
            //        mc.StatusNumber = openStatus.StatusNumber;
            //    }
            //    mc.Save(false);




            //    if (lac.StatusNumber != cancelledStatus.StatusNumber && lac.StatusNumber != completeStatus.StatusNumber)
            //    {
            //        if (lac.StatusNumber != retenderStatus.StatusNumber)
            //        {
            //            if (lac.StatusNumber != builtStatus.StatusNumber)
            //            {
            //                lac.StatusNumber = inProcessStatus.StatusNumber;
            //            }
            //            else if(lac.StatusNumber == voidStatus.StatusNumber)
            //            {
            //                lac.StatusNumber = builtStatus.StatusNumber;
            //            }
            //        }
            //        else
            //        {
            //            lac.StatusNumber = inProcessStatus.StatusNumber;
            //        }
            //    }

            //    lac.Save();

            //    if (lac.LocationNumber.HasValue)
            //    {
            //        //MSC-4250 Certain OP Shipping offices need similar email notification like they get when a Sellers load is created.
            //        BusinessLogic.Location loc = BusinessLogic.Location.FetchByNumber(lac.LocationNumber);
            //        if (loc.EnableShippingEmail && !String.IsNullOrWhiteSpace(loc.ShippingEmail))
            //        {
            //            opLocationsWithTaDetailsForEmail.Add(new EmailHelper.RuanTaShippingEmailHelper(ta.ShipmentNumber, lac.LocationNumber.Value, lac.LoadAuthorizationCrossNumber, lac.SalesOrderReleaseNumber, lac.TransferHeaderNumber));
            //        }
            //    }
            //}

            //if (manifestListByRuanShipmentID.Any())
            //{
            //    foreach (ManifestHeader manifestByRuanShipmentID in manifestListByRuanShipmentID.Where(x=>x.Complete))
            //    {
            //        if (manifestByRuanShipmentID.Complete) //Check if we got any updates from Ruan after it has been completed.
            //        {
            //            ManifestDetailList manifestDetailList = ManifestDetail.FetchAllByHeaderNumber(manifestByRuanShipmentID.ManifestHeaderNumber);
            //            ManifestCrossList manifestCrossList = ManifestCross.FetchAllByManifest(manifestByRuanShipmentID.ManifestHeaderNumber);

            //            foreach (ManifestCross manifestCross in manifestCrossList)
            //            {
            //                if (manifestDetailList.All(x => x.LoadAuthorizationCrossNumber != manifestCross.LoadAuthorizationCrossNumber))
            //                {
            //                    ManifestHeader manifestHeader = ManifestHeader.FetchByNumber(manifestCross.ManifestHeaderNumber);
            //                    manifestHeader.Complete = false;
            //                    if (!manifestHeader.ChangedByTAFile.HasValue)
            //                    {
            //                        manifestHeader.ChangedByTAFile = false;
            //                    }
            //                    manifestHeader.Save(false);
            //                    break;
            //                }
            //            }
            //        }
            //    }

            //    if (manifestListByRuanShipmentID.Any(x => x.Printed))
            //    {
            //        return; //Should not send OP email for shipped Ruan Loads.
            //    }
            //}

            //if (opLocationsWithTaDetailsForEmail.Any())
            //{
            //    EmailHelper.RuanComposeTaShippingEmail(opLocationsWithTaDetailsForEmail);
            //}

            //EmailHelper.RuanComposeTaChangedEmail(taFileChanges);

        }

        public static void DeleteTransportFromStratix(APITransportationShipment ta)
        {
            for (int i = 515; i <= 516; i++)
            {
                XCTI20 objXcti20 = new XCTI20();
                objXcti20.i20_cmpy_id = "HSP";
                objXcti20.i20_intchg_pfx = "XI";
                objXcti20.i20_intchg_no = StratixHelperData.GetMaxInterchangeNumber() + 1;
                string formatDate = "yyyy-MM-dd HH:mm:ss";
                objXcti20.i20_crtd_dtts = $"'{DateTime.Now.ToString(formatDate)}'";
                objXcti20.i20_transp_pfx = "TR";
                objXcti20.i20_transp_no = i;
                XCTI20.DeleteTransport(objXcti20);
            }

           

        }

        private static bool TaFileHasChanges(this APITransportationShipment ta)
        {
            bool taFileHasChanged = false;
            ////get TSLACS from manifest cross
            //List<string> orderIds = new List<string>();
            //List<long> truckReleases = new List<long>();

            ////get all order Ids'
            //foreach (TransportationArrangedStop stop in ta.Stops.Where(s => s.StopType == "P"))
            //{
            //    orderIds.AddRange(stop.Orders.Select(o => o.OrderId).Distinct());
            //}

            ////get truckReleases
            //foreach (string orderId in orderIds.Distinct())
            //{
            //    if (long.TryParse(orderId, out long truckRelease))
            //    {
            //        truckReleases.Add(truckRelease);
            //    }
            //}

            ////get manifest crosses
            //ManifestCrossList mcs = ManifestCross.FetchAllShipmentsByRuanShipmentId(ta.ShipmentNumber);
            //if (mcs.Count == 0)
            //{
            //    //this is new or changed lets check
            //    foreach (long truckRelease in truckReleases)
            //    {
            //        mcs = ManifestCross.FetchAllByLoadAuthCrossNumber(truckRelease);
            //        foreach (ManifestCross mc in mcs)
            //        {
            //            if (mc.ShipmentID != ta.ShipmentNumber)
            //            {
            //                taFileHasChanged = true;
            //                break;
            //            }
            //        }

            //        if (taFileHasChanged) break;
            //    }
            //}
            //else
            //{
            //    //if different R# 
            //    if (mcs.Any(mc => mc.ShipmentID != ta.ShipmentNumber))
            //    {
            //        taFileHasChanged = true;
            //    }
            //    else
            //    {
            //        //see if any truck releases not on the manifest cross.
            //        List<long> currentTruckReleases = mcs.Select(mc => Convert.ToInt64(mc.LoadAuthorizationCrossNumber)).ToList();
            //        if (truckReleases.Any(tr => !currentTruckReleases.Contains(tr)))
            //        {
            //            taFileHasChanged = true;
            //        }
            //    }
            //}

            return taFileHasChanged;
        }
    }
}