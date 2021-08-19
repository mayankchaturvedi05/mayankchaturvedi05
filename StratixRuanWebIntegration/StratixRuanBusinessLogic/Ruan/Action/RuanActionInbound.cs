using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Text.RegularExpressions;
using StratixRuanBusinessLogic.CoreData;
using StratixRuanBusinessLogic.Ruan.Serialization;
using StratixRuanDataLayer;
using System.Threading;
using System.Xml;
using System.Xml.Linq;
using StratixRuanDataLayer.StratixAuthenticationService;
using StratixRuanDataLayer.StratixTransportFreightService;
using AuthenticationToken = StratixRuanDataLayer.StratixAuthenticationService.AuthenticationToken;
using ServiceMessages = StratixRuanDataLayer.StratixAuthenticationService.ServiceMessages;

namespace StratixRuanBusinessLogic.Ruan.Action
{
    public static partial class RuanAction
    {
        
        public static void ProcessTa(APITransportationShipment ta)
        {
            
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

            //Purchase order or returns logic
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
        
        public static void TAtoStratix(APITransportationShipment ta)
        {
            QueueFlag queueFlagForActivityNotAssigned = GlobalState.QueueFlags.QueueFlagByCode("ActivityNotAssigned");


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
                double weightTotal = 0;
                if (DateTime.TryParse(pickupStop.StopPlannedDepartureDateTime, out DateTime dateShippedTemp))
                {
                    dateShipped = dateShippedTemp;
                }
                else
                {
                    throw new RuanJobException($"Shipment Number {ta.ShipmentNumber}, Invalid date {pickupStop.StopPlannedDepartureDateTime}.");
                }

                // Check for existing transport.
                if (string.IsNullOrWhiteSpace(ta.ShipmentNumber))
                {
                    throw new RuanJobException($"Missing Ruan Shipment Number");
                }

                if (string.IsNullOrWhiteSpace(pickupStop.Location.Name))
                {
                    throw new RuanJobException($"Shipment Number {ta.ShipmentNumber}, has missing Pickup location name");
                }
                string ruanCarrierRefNum = ta.ShipmentNumber;
                string wareHouse = pickupStop.Location.Name;

                long transportNumber =
                    StratixHelperData.GetTransportNumberByRuanCarrierRefAndWarehouse(ruanCarrierRefNum, wareHouse);
                long interchangeNumberTransport = StratixHelperData.GetMaxInterchangeNumber() + 1;

                XCTI18 objXcti18 = new XCTI18();
                XCTI19 objXcti19 = new XCTI19();
                if (transportNumber > 0) //change
                {
                    objXcti19.i19_intchg_no = interchangeNumberTransport;
                    string formatDate = "yyyy-MM-dd HH:mm:ss";
                    objXcti19.i19_crtd_dtts = $"'{DateTime.Now.ToString(formatDate)}'";
                    objXcti19.i19_trrte = "RUAN";
                    objXcti19.i19_dlvy_mthd = "OC";
                    objXcti19.i19_cmpy_id = "HSP";
                    objXcti19.i19_intchg_pfx = "XI";
                    objXcti19.i19_rte_clr = string.Empty;

                    string carrierInfo = $"{ta.CarrierScac}*{ta.CarrierName}";
                    if (carrierInfo.Length > 35)
                    {
                        carrierInfo = carrierInfo.Substring(0, 35);
                    }
                    objXcti19.i19_crr_nm = carrierInfo;

                    objXcti19.i19_frt_exrt = 1.00000000;
                    objXcti19.i19_frt_ex_rt_typ = "V";
                    objXcti19.i19_sch_rmk = "remark";
                    objXcti19.i19_trctr = 1;
                    objXcti19.i19_trlr_typ = "FB";
                    objXcti19.i19_max_stp = deliveryStops.Length + pickupStops.Length;

                    objXcti19.i19_crr_ref_no = ta.ShipmentNumber;
                    objXcti19.i19_frt_cry = "USD";
                    objXcti19.i19_frt_ven_id = "9999";
                    objXcti19.i19_sch_dtts = $"'{dateShipped.Value.ToString(formatDate)}'";
                }
                else // new
                {
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
                    objXcti18.i18_trpln_whs = pickupStop.Location.Name;
                }

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

                        double weight = shipUnit.Contents.Sum(x =>
                        {
                            if (double.TryParse(x.Weight, out weight))
                            {
                                return weight;
                            }

                            return 0;
                        });
                        weightTotal = weightTotal + weight;


                    }

                    objXcti18.i18_max_wgt = weightTotal;
                   
                } // Pickup Orders

                objXcti18.i18_max_wgt = weightTotal;
                objXcti18.i18_max_wgt = weightTotal;

                if (transportNumber > 0)//change
                {
                    objXcti19.i19_max_wgt = weightTotal;
                }
                else
                {
                    objXcti18.i18_max_wgt = weightTotal;
                }

                RuanXml ruanXml = new RuanXml(ta);//Save the TA
                try
                {
                    if (transportNumber > 0)//change
                    {
                        XCTI19.ModifyTransport(objXcti19);
                        PrepareForTransportActivity(ta, pickupStop.Location.Name, transportNumber);
                        ruanXml.Save();
                    }
                    else
                    {
                        XCTI18.AddTransport(objXcti18);
                        ruanXml.Save();

                        //Send this to activities queue to be processed little bit later as we won't have a transport number immediately(for few seconds atleast) and the Plan Activities require the transport number.
                        RuanXMLQueue activitiesQueue = new RuanXMLQueue
                        {
                            RuanXMLNumber = ruanXml.RuanXMLNumber,
                            QueueFlagNumber = queueFlagForActivityNotAssigned.QueueTypeNumber, //Denotes Transport Number Not available
                            StratixInterchangeNumber = interchangeNumberTransport
                        };

                        activitiesQueue.Save();

                    }
                }
                catch (Exception e)
                {
                    throw new RuanJobException($"Error Adding Transport.");
                }

            }//Pickup Stops

        }

        public static void ProcessTransportActivities(long ruanXMLQueueNumber)
        {
            QueueFlag queueFlagForActivityAssigned = GlobalState.QueueFlags.QueueFlagByCode("ActivityAssigned");
            try
            {
                RuanXMLQueue ruanXmlQueueObject = RuanXMLQueue.FetchByNumber(ruanXMLQueueNumber) ?? throw new ArgumentNullException(nameof(ruanXMLQueueNumber));
                RuanXml ruanXmlObject = RuanXml.FetchByNumber(ruanXmlQueueObject.RuanXMLNumber);

                if (ruanXmlQueueObject.StratixInterchangeNumber != null)
                {
                    long transportNumber = StratixHelperData.GetTransportNumberFromTransportAddGateway(ruanXmlQueueObject.StratixInterchangeNumber.Value);
                    string pickupWarehouse = StratixHelperData.GetPickupWarehouseFromTransportAddGateway(ruanXmlQueueObject.StratixInterchangeNumber.Value);

                    string xmlParameter = ruanXmlObject.XML;

                    XDocument xdoc;
                    if (xmlParameter == null)
                    {
                        throw new Exception("Invalid XML");
                    }

                    using (Stream s = Utilities.GenerateStreamFromString(xmlParameter))
                    {
                        xdoc = XDocument.Load(s);
                    }

                    XElement root = xdoc.Root;
                    if (root == null)
                    {
                        throw new Exception("The XML Root is null");
                    }

                    if (root.Name == "APITransportationShipment")
                    {
                        APITransportationShipment ta = Utilities.DeserializeFromXmlString<APITransportationShipment>(xmlParameter);

                        PrepareForTransportActivity(ta, pickupWarehouse, transportNumber);
                    }

                    ruanXmlQueueObject.QueueFlagNumber = queueFlagForActivityAssigned.QueueTypeNumber;//Flag it, so that it wouldn't be processed in future calls.
                }
            }
            catch (Exception e)
            {
                throw new RuanJobException($"Error processing Transport Activities");
            }
            
        }

        private static void PrepareForTransportActivity(APITransportationShipment ta, string pickupWarehouse,
            long transportNumber)
        {
            TransportationArrangedStop[] pickupStops = ta.Stops.Where(x => x.StopType == "P").ToArray();
            TransportationArrangedStop pickupStopsByLocation =
                pickupStops.FirstOrDefault(x => x.Location.Name.Equals(pickupWarehouse));
            if (pickupStopsByLocation != null)
            {
                foreach (var pickupOrder in pickupStopsByLocation.Orders)
                {
                    string orderIdWithReleaseInformation = pickupOrder.OrderId;
                    char separationCharacter = '_';

                    int separationCharacterCount =
                        orderIdWithReleaseInformation.Count(x => (x == separationCharacter));
                    if (separationCharacterCount != 2)
                    {
                        throw new RuanJobException($"Invalid OrderID {orderIdWithReleaseInformation}.");
                    }

                    var orderSplitArray =
                        pickupOrder.OrderId.Split(
                            separationCharacter); //First array value is the OrderID, second is the Detail and the third array is the release item id.

                    PlanTransportActivity(transportNumber, orderSplitArray);
                }
            }
            else
            {
                throw new RuanJobException($"PickStop NOT found");
            }
        }

        private static void PlanTransportActivity(long transportNumber, string[] orderSplitArray)
        {
            string formatDate = "yyyy-MM-dd HH:mm:ss";
            XCTI21 objXcti21 = new XCTI21();
            long interchangeNumberTransportActivity = StratixHelperData.GetMaxInterchangeNumber() + 1;
            objXcti21.i21_intchg_no = interchangeNumberTransportActivity;
            objXcti21.i21_intchg_itm = 1;

            objXcti21.i21_crtd_dtts = $"'{DateTime.Now.ToString(formatDate)}'";
            objXcti21.i21_transp_no = transportNumber;

            TRTTAVCondensed tRttavCondensedObject =
                TRTTAVCondensed.GetTrttavCondensed(orderSplitArray[0], orderSplitArray[1], orderSplitArray[2]);
            objXcti21.i21_actvy_pfx = tRttavCondensedObject.tav_trac_pfx;
            objXcti21.i21_actvy_no = tRttavCondensedObject.tav_trac_no;
            objXcti21.i21_actvy_itm = tRttavCondensedObject.tav_trac_itm;
            objXcti21.i21_plnd_trs_pcs = tRttavCondensedObject.tav_bal_pcs;
            objXcti21.i21_plnd_trs_msr = tRttavCondensedObject.tav_bal_msr;
            objXcti21.i21_plnd_trs_wgt = tRttavCondensedObject.tav_bal_wgt;

            try
            {
                XCTI21.PlanTransportActivity(objXcti21);
            }
            catch (Exception e)
            {
                throw new RuanJobException($"Error Adding Transport Activities for transport number {transportNumber}");
            }
            
        }

        public static void DeleteTransportFromStratix(APITransportationShipment ta)
        {
            if (string.IsNullOrWhiteSpace(ta.CarrierScac))
            {
                throw new RuanJobException($"Shipment Number {ta.ShipmentNumber}, has no Carrier SCAC.");
            }

            TransportationArrangedStop[] pickupStops = ta.Stops.Where(x => x.StopType == "P").ToArray();
            foreach (TransportationArrangedStop pickupStop in pickupStops)
            {

                if (string.IsNullOrWhiteSpace(ta.ShipmentNumber))
                {
                    throw new RuanJobException($"Missing Ruan Shipment Number");
                }

                if (string.IsNullOrWhiteSpace(pickupStop.Location.Name))
                {
                    throw new RuanJobException($"Shipment Number {ta.ShipmentNumber}, has missing Pickup location name");
                }
                string ruanCarrierRefNum = ta.ShipmentNumber;
                string wareHouse = pickupStop.Location.Name;

                long transportNumber =
                    StratixHelperData.GetTransportNumberByRuanCarrierRefAndWarehouse(ruanCarrierRefNum, wareHouse);

                XCTI20 objXcti20 = new XCTI20();
                objXcti20.i20_cmpy_id = "HSP";
                objXcti20.i20_intchg_pfx = "XI";
                objXcti20.i20_intchg_no = StratixHelperData.GetMaxInterchangeNumber() + 1;
                string formatDate = "yyyy-MM-dd HH:mm:ss";
                objXcti20.i20_crtd_dtts = $"'{DateTime.Now.ToString(formatDate)}'";
                objXcti20.i20_transp_pfx = "TR";
                objXcti20.i20_transp_no = transportNumber;
                XCTI20.DeleteTransport(objXcti20);
            }

        }

        public static void AssignFreightCost()
        {
            AuthenticationServiceClient authenticationServiceClient = new AuthenticationServiceClient();
            GatewayLoginRequestType gatewayLoginRequestType = new GatewayLoginRequestType();
            gatewayLoginRequestType.username = GlobalState.StratixUserName;
            gatewayLoginRequestType.password = GlobalState.StratixPassword;
            gatewayLoginRequestType.environmentName = GlobalState.StratixEnvironmentName;
            gatewayLoginRequestType.environmentClass = GlobalState.StratixEnvironmentClass;
            gatewayLoginRequestType.forceDisconnect = true;
            gatewayLoginRequestType.connectedAccessType = "I";
            gatewayLoginRequestType.forceDisconnectSpecified = true;

            GatewayLoginResponseType gatewayLoginResponseType = new GatewayLoginResponseType();
            authenticationServiceClient.GatewayLogin(gatewayLoginRequestType, out gatewayLoginResponseType);

            TransportFreightServiceClient trn = new TransportFreightServiceClient();
            UpdateTRFreightCostRequest updateTRFreightCostRequest = new UpdateTRFreightCostRequest();

            StratixRuanDataLayer.StratixTransportFreightService.AuthenticationToken authenticationToken = new StratixRuanDataLayer.StratixTransportFreightService.AuthenticationToken();
            authenticationToken.username = gatewayLoginResponseType.authenticationToken.username;
            authenticationToken.value = gatewayLoginResponseType.authenticationToken.value;

            UpdateTRFreightCostInput updateTrFreightCostInput = new UpdateTRFreightCostInput();
            updateTrFreightCostInput.trNumber = 533;
            updateTrFreightCostInput.trFreightCostSpecified = true;
            updateTrFreightCostInput.trFreightCostUM = "CWT";
            updateTrFreightCostInput.trFreightCost = 0.6m;

            updateTrFreightCostInput.trFlSurChrgCostSpecified = false;
            updateTrFreightCostInput.trFlSurChrgCostUM = "PCT";


            updateTrFreightCostInput.trCarrierRef = "R11121";


            updateTrFreightCostInput.trStopChrgSpecified = false;


            updateTRFreightCostRequest.AuthenticationHeader = authenticationToken;
            updateTRFreightCostRequest.updateTRFreightCostInput = updateTrFreightCostInput;

            try
            {
                StratixRuanDataLayer.StratixTransportFreightService.ServiceMessages updateFreightCostMessages = trn.UpdateTRFreightCost(ref authenticationToken, updateTrFreightCostInput);
            }
            catch (FaultException faultex)
            {
                var msgFault = faultex.CreateMessageFault();

                if (msgFault.HasDetail)
                {
                    XmlElement detailNode = msgFault.GetDetail<XmlElement>();
                    FaultReason faultReason = msgFault.Reason;
                    string faultReasonMessage = faultReason.ToString();

                    throw new RuanJobException($"Error calling Stratix service: {faultReasonMessage}.");
                }
            }
            catch (Exception exception)
            {
                throw new RuanJobException($"{exception.Message}.");
            }

        }

    }
}