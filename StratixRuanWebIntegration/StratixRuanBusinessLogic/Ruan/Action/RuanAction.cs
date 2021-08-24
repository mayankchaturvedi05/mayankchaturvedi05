using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using StratixRuanBusinessLogic;
using StratixRuanBusinessLogic.Ruan.Serialization;
using StratixRuanBusinessLogic.Stratix;
using StratixRuanDataLayer;
using StratixOrderNotification = StratixRuanDataLayer.StratixOrderNotification;

namespace StratixRuanBusinessLogic.Ruan.Action
{
    public static partial class RuanAction
    {
        private static string apiUriBase = string.Empty;
        public static string LastResponse = string.Empty;
        public static bool Synchronize { get; set; } = false;
       

        #region "Helper functions"
        //static constructor sets environment (dev/qa/prod) from AppConfig
        static RuanAction()
        {
            try
            {
                apiUriBase = ConfigurationManager.AppSettings["RuanApiUri"];
                if (string.IsNullOrEmpty(apiUriBase)) throw new Exception();
            }
            catch (Exception)
            {
                throw new Exception("Ruan API is not properly configured for the environment, contact support.");
            }
        }
        
        //Helper function to Deserialize an xml string to class
        private static T Deserialize<T>(string xml)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            using (StringReader sr = new StringReader(xml))
            {
                return (T) ser.Deserialize(sr);
            }
        }

        //Helper function to Serialize a class to an xml string (utf-8)
        private static string Serialize<T>(T objectToSerialize)
        {
            return Utilities.SerializeObjectToStringUtf8(objectToSerialize);
        }

        //Helper function to Serialize Class for saving to db.
        private static string SerializeForDb<T>(T objectToSerialize)
        {
            return Utilities.SerializeObjectToStringNoEncoding(objectToSerialize);
        }

        //Creates Ruan api uri based on environment and api action
        private static string GetActionUri(RuanApiType apiAction)
        {
            switch (apiAction)
            {
                case RuanApiType.ReleaseOrders:
                    return "/ReleaseOrders";
                case RuanApiType.TransportationArrangedShipments:
                    return "/TransportationArrangedShipments";
                case RuanApiType.ActualShipment:
                    return "/ReleaseOrderShipments";
                case RuanApiType.BaseOrders:
                    return "/BaseOrders";
                default:
                    return "";
            }
        }
        #endregion

        //mapping functions go here
        #region Mapping Functions 
            
       
        public static void SubmitActualShipmentForSalesOrderAndTransfer()
        {
           //Currently being worked on locally by Skhan
        }


        public static String GenerateActualShipmentForRuan(string orderNumber)
        {

            APIActualShipment objAS = new APIActualShipment
            {

                //  DomainName = "RUAN/HS",
                TransmissionType = "FRESH",
                SenderTransmissionNo = $"HS_R2854782_2000490342",
                ActualShipments = new List<ActualShipment>()
                {
                        new ActualShipment()
                        {
                             ShipmentHeader = new ShipmentHeader()
                            {

                                DomainName="RUAN",
                                ShipmentNumber="R2854782",
                                ShipmentName="HS",
                                TransactionCode="IU",
                                ServiceProviderDomain="RUAN",
                                ServiceProvider="RRXN",
                                ProcessAsFlowThru="Y",
                                TransportMode="TL",
                                StopCount="2",
                                ShipmentAsWork="N",
                                AutoGenerateRelease="N",
                                ReferenceNumbers = new List<ReferenceNumber>()
                                {
                                     new ReferenceNumber()
                                     {
                                        ReferenceNumberType="ORDER_STOP_ID",
                                        ReferenceNumberValue="P|1|20210520230646",
                                     },
                                      new ReferenceNumber()
                                     {
                                        ReferenceNumberType="BM",
                                        ReferenceNumberValue="2000490342",
                                     },

                                }


                             },

                              ReleaseOrders = new List<ReleaseOrder>()
                                {
                                     new ReleaseOrder()
                                     {
                                        OrderHeader = new OrderHeader()
                                        {
                                             DomainName="RUAN/HS",
                                             OrderNumber="354271",
                                             TransactionCode="IU",
                                             IntegrationCommand="RemoveShipmentRefForRC",
                                             PaymentMethod="TPB",
                                             TimeWindowEmphasis="NONE",
                                             Priority="999",
                                             StatusValue="A",
                                             StatusType="CANCELLED",
                                             OrderShippingConfiguration="SHIP_UNIT_LINES",
                                             OrderType="PURCHASE_ORDER",
                                              ReferenceNumbers = new List<ReferenceNumber>()
                                                    {
                                                         new ReferenceNumber()
                                                         {
                                                            ReferenceNumberType="MBL",
                                                            ReferenceNumberValue="1000748310",
                                                         },
                                                          new ReferenceNumber()
                                                         {
                                                            ReferenceNumberType="LINE_OF_BUSINESS",
                                                            ReferenceNumberValue="Sales",
                                                         },
                                                          new ReferenceNumber()
                                                         {
                                                            ReferenceNumberType="CUST_PO",
                                                            ReferenceNumberValue="90105825",
                                                         },
                                                    }
                                        },
                                        ShipFrom = new ShipFrom()
                                        {
                                            DomainName="RUAN/HS",
                                            Id="HSP08",
                                            Name="Heidtman Steel - Butler",
                                            AddressLine1="4400 County Road 59",
                                            City="Butler",
                                            Zip="46721",
                                            Country="United States",
                                           // Latitude="0",
                                           // Longitude="0",
                                            Role="SHIPFROM/SHIPTO",
                                            PostLocationToOTM="true",
                                        },
                                        ShipTo = new ShipTo()
                                        {
                                            DomainName="RUAN/HS",
                                            Id="JA7257S003",
                                            Name="JAYTEC LLC",
                                            AddressLine1="620 S Platt Rd",
                                            City="Milan",
                                            Zip="48160",
                                            Country="United States",
                                           // Latitude="0",
                                           // Longitude="0",
                                            Role="SHIPFROM/SHIPTO",
                                            PostLocationToOTM="true",
                                        },
                                        ShippingAndDeliveryDates = new ShippingAndDeliveryDates()
                                        {
                                            ShipDateTimeEarly= DateTime.Parse("2021-05-20T23:06:46"),
                                            ShipDateTimeLate= DateTime.Parse("2021-05-20T23:06:46"),
                                        },
                                        OrderRouting = new OrderRouting()
                                        {
                                            ShipWithGroupId="051821001",
                                            PreferredTransportationMode="TL",

                                        },
                                        LineItems = new List<LineItem>()
                                        {
                                             new LineItem()
                                            {
                                                AutoCreateItem="Y",
                                                AutoCreateItemMaster="Y",
                                                LineItemNumber="354271-1",
                                                TransportUnitKey="354271-001",
                                                ItemNumber="1000521627-002",
                                                ItemName="Y700388/9C",
                                                ItemDescription=".048 X 3.926 [0.048x3.926xCoil]",
                                                Quantity="1",
                                                QuantityUnitOfMeasure="EA",
                                                Weight="0",
                                                Volume="0",
                                                WeightGross="3455",
                                                WeightGrossUnitOfMeasure="LB",
                                                VolumeGross="0",
                                                VolumeGrossUnitOfMeasure="CUFT",
                                                LineItemDimensions = new LineItemDimensions()
                                                {
                                                     //Length1="0",
                                                     //Length2="0",
                                                     //Width1="0",
                                                     //Width2="0",
                                                     //Height1="0",
                                                     //Height2="0",
                                                     UnitOfMeasure="IN",
                                                     Weight="3455",
                                                     WeightUnitOfMeasure="LB",
                                                     Volume="0",
                                                     VolumeUnitOfMeasure="CUFT",
                                                }
                                             }

                                        },
                                        ShipUnits = new ShipUnits()
                                        {
                                            ShipUnitList = new List<ShipUnit>()
                                            {
                                                new ShipUnit()
                                                {
                                                    ShipFromLocationDomainName="RUAN/HS",
                                                    ShipFromLocation="HSP08",
                                                    ShipToLocationDomainName="RUAN/HS",
                                                    ShipToLocation="JA7257S003",
                                                    DomainName="RUAN/HS",
                                                    TransactionCode="IU",
                                                    ShipUnitKey="354271-001",
                                                    ShipUnitType="1H",
                                                    ShipUnitCount="1",
                                                    Weight="0",
                                                    WeightUnitOfMeasure="LB",
                                                    Volume="0",
                                                    VolumeUnitOfMeasure="CUFT",
                                                    WeightGross="3455",
                                                    WeightGrossUnitOfMeasure="LB",
                                                    VolumeGross="0",
                                                    VolumeGrossUnitOfMeasure="CUFT",
                                                    //TotalWeight="0",
                                                    //TotalVolume="0",
                                                    IsSplitAllowed="N",
                                                    IsCountSplittable="N",
                                                    IsRepackAllowed="N",

                                                    ShipUnitContents = new List<ShipUnitContent>()
                                                    {
                                                        new ShipUnitContent()
                                                        {
                                                            DomainName="RUAN/HS",
                                                         //   SequenceNumber="0",
                                                            ReleaseLineSequenceNumber="1",
                                                            OrderNumber="354271",
                                                            LineItemNumber="354271-1",
                                                            ItemNumber="1000521627-002",
                                                            ItemName="Y700388/9C",
                                                            ItemDescription=".048 X 3.926 [0.048x3.926xCoil]",
                                                            Quantity="1",
                                                            QuantityUnitOfMeasure="EA",
                                                            Weight="3455",
                                                            WeightUnitOfMeasure="LB",
                                                            Volume="0",
                                                            VolumeUnitOfMeasure="CUFT",
                                                            WeightGross="3455",
                                                            WeightGrossUnitOfMeasure="LB",
                                                            VolumeGross="0",
                                                            VolumeGrossUnitOfMeasure="CUFT",
                                                          //  PackagedItemCount="1",
                                                        },


                                                    },
                                                     ShipUnitDimensions = new ShipUnitDimensions()
                                                     {
                                                         Length="0",
                                                         LengthUnitOfMeasure="IN",
                                                         Width="0",
                                                         WidthUnitOfMeasure="IN",
                                                         Height="0",
                                                         HeightUnitOfMeasure="IN",
                                                     }

                                                },



                                            }

                                        }



                                     }
                              }

                        }

                }




            };

            string xml = Serialize(objAS);
            return xml;
        }



        public static String GenerateBaseOrderForRuan(string orderNumber, List<StratixRuanBusinessLogic.Stratix.RuanBaseOrdersHelperData> helperData) //long stratixInterchangeNumber, long orderNumber, string orderReleaseStatusValue
        {

            List<StratixRuanBusinessLogic.Stratix.RuanBaseOrdersHelperData> helperData1 = StratixRuanBusinessLogic.Stratix.RuanBaseOrdersHelperData
                 .GetPurchaseOrderDataToConstructRuanOrderIntegrationXML(orderNumber);

            RuanBaseOrdersHelperData objHelper = new RuanBaseOrdersHelperData();
            StratixRuanBusinessLogic.Ruan.Serialization.ApiBaseOrder ruanBaseOrder = new StratixRuanBusinessLogic.Ruan.Serialization.ApiBaseOrder();

            ApiBaseOrderBaseOrderOrderHeader OrderHeaderObj = new ApiBaseOrderBaseOrderOrderHeader();

            foreach (var ord in helperData)
            {
                OrderHeaderObj.OrderNumber = ord.poh_po_no;
                OrderHeaderObj.OrderType = "PURCHASE_ORDER";
                OrderHeaderObj.StatusType = "CANCELLED";
                OrderHeaderObj.StatusValue = "A";
                //  OrderHeaderObj.EffectiveDate = "2099-12-31T23:59:59";
                OrderHeaderObj.ExpirationDate = "2099-12-31T23:59:59";
                OrderHeaderObj.TransactionCode = "IU";
                OrderHeaderObj.TimeWindowEmphasis = "SHIP";
                OrderHeaderObj.OrderShippingConfiguration = "OB_LINE_COUNT_OVER";
                OrderHeaderObj.PaymentMethod = "TPB";

                ApiBaseOrderBaseOrderOrderHeaderFlexFieldStrings FlexFieldStrings = new ApiBaseOrderBaseOrderOrderHeaderFlexFieldStrings();
                FlexFieldStrings.Attribute1 = "HS";

                OrderHeaderObj.FlexFieldStrings = FlexFieldStrings;
            }

            List<ApiBaseOrderBaseOrderOrderLine> orderLinesLstObj = new List<ApiBaseOrderBaseOrderOrderLine>();
            ApiBaseOrderBaseOrderOrderLine orderLinesObj;
            ApiBaseOrderBaseOrderOrderLineShipFrom ShipFromObj;
            ApiBaseOrderBaseOrderOrderLineShipTo ShipToObj;
            ApiBaseOrderBaseOrderOrderLineLineItemDimensions LineItemDimensionsObj;
            ApiBaseOrderBaseOrderOrderLineShippingAndDeliveryDates ShippingAndDeliveryDatesObj;


            foreach (var ord in helperData)
            {

                orderLinesObj = new ApiBaseOrderBaseOrderOrderLine();

                orderLinesObj.AutoCreateItem = "Y";
                orderLinesObj.AutoCreateItemMaster = "Y";
                orderLinesObj.LineItemNumber = ord.poh_po_no + "-00" + ord.poi_po_itm;
                orderLinesObj.TransactionCode = "IU";
                orderLinesObj.StatusValue = "A";
                orderLinesObj.StatusType = "CANCELLED";

                ShipFromObj = new ApiBaseOrderBaseOrderOrderLineShipFrom();
                ShipFromObj.DomainName = "HS";
                ShipFromObj.Id = ord.poh_ven_id;
                ShipFromObj.Name = ord.ship_from.cva_nm1;
                ShipFromObj.AddressLine1 = ord.ship_from.cva_addr1;
                ShipFromObj.AddressLine2 = "";
                ShipFromObj.City = ord.ship_from.cva_city;
                ShipFromObj.State = ord.ship_from.cva_st_prov;
                ShipFromObj.Zip = ord.ship_from.cva_pcd;
                ShipFromObj.Country = ord.ship_from.cva_cty;
                ShipFromObj.Latitude = 0;
                ShipFromObj.Longitude = 0;
                ShipFromObj.PostLocationToOTM = false;
                orderLinesObj.ShipFrom = ShipFromObj;

                ShipToObj = new ApiBaseOrderBaseOrderOrderLineShipTo();
                ShipToObj.DomainName = "RUAN/HS";
                ShipToObj.Id = "HS" + ord.poh_ven_id; ;
                ShipToObj.Name = ord.ship_To.brh_nm1;
                ShipToObj.AddressLine1 = ord.ship_To.brh_addr1;
                ShipToObj.AddressLine2 = ord.ship_To.brh_addr2 + " " + ord.ship_To.brh_addr3;
                ShipToObj.City = ord.ship_To.brh_city;
                ShipToObj.State = ord.ship_To.brh_st_prov;
                ShipToObj.Zip = ord.ship_To.brh_pcd;
                ShipToObj.Country = ord.ship_To.brh_cty;
                ShipToObj.Latitude = 0;
                ShipToObj.Longitude = 0;
                ShipToObj.PostLocationToOTM = false;
                orderLinesObj.ShipTo = ShipToObj;

                orderLinesObj.ItemName = ord.prd_desc.pds_prd_desc50a + " " + ord.prd_desc.pds_prd_desc50b + " " + ord.prd_desc.pds_prd_desc50c;
                orderLinesObj.ItemNumber = ord.poh_po_no + "-00" + ord.poi_po_itm; ;
                orderLinesObj.ItemDescription = ord.prd_desc.pds_prd_desc50a + " " + ord.prd_desc.pds_prd_desc50b + " " + ord.prd_desc.pds_prd_desc50c;
                orderLinesObj.Quantity = Math.Round(Convert.ToDecimal(ord.poi_ord_qty), 0);
                orderLinesObj.DomainName = "RUAN/HS";

                LineItemDimensionsObj = new ApiBaseOrderBaseOrderOrderLineLineItemDimensions();
                LineItemDimensionsObj.Weight = 1;
                LineItemDimensionsObj.WeightUnitOfMeasure = ord.poi_ord_wgt_um;
                orderLinesObj.LineItemDimensions = LineItemDimensionsObj;

                ShippingAndDeliveryDatesObj = new ApiBaseOrderBaseOrderOrderLineShippingAndDeliveryDates();
                ShippingAndDeliveryDatesObj.DeliveryDateTimeEarly = ord.poh_po_pl_dt;
                ShippingAndDeliveryDatesObj.DeliveryDateTimeLate = ord.poh_po_pl_dt;
                orderLinesObj.ShippingAndDeliveryDates = ShippingAndDeliveryDatesObj;

                orderLinesLstObj.Add(orderLinesObj);
            }

          
            int totalOrderCount = 0;
           
            StratixRuanBusinessLogic.Ruan.Serialization.ApiBaseOrder ruanBaseOrderObj = new StratixRuanBusinessLogic.Ruan.Serialization.ApiBaseOrder
            {
                DomainName = "RUAN/HS",
                TransmissionType = "FRESH",
                SenderTransmissionNo = $"HS_OB_NAME_OF_PO",

                BaseOrders = new List<ApiBaseOrderBaseOrder>()
                {
                        new ApiBaseOrderBaseOrder()
                        {
                            OrderHeader=OrderHeaderObj,
                          
                            OrderLines = orderLinesLstObj,
                        
                    }
                }

            };
            
            string xml = Serialize(ruanBaseOrderObj);
            return xml;
        }



        public static void GenerateOrderReleaseForRuan(StratixOrderReleaseParametersForRuan stratixOrderReleaseParametersForRuan)
        {
            if (Debugger.IsAttached) Debug.WriteLine($"KeyNumber: {stratixOrderReleaseParametersForRuan.orderFileKeyNumber}");

            int totalOrderCount = 0;

            StratixRuanBusinessLogic.Stratix.RuanOrderIntegrationHelperData helperData = StratixRuanBusinessLogic.Stratix.RuanOrderIntegrationHelperData
                    .GetDataToConstructRuanOrderIntegrationHelperData(stratixOrderReleaseParametersForRuan);

            if (helperData == null)
            {
                return;
            }

            string ruanUniqueOrderNumber;
            if (stratixOrderReleaseParametersForRuan.orderFileKeyPfx.Equals("SO"))
            {
                ruanUniqueOrderNumber =
                    $"{stratixOrderReleaseParametersForRuan.orderFileKeyNumber}_{stratixOrderReleaseParametersForRuan.orderFileItemNumber}_{stratixOrderReleaseParametersForRuan.orderFileSubItemNumber}";
            }
            else //JS or IP
            {
                ruanUniqueOrderNumber =
                    $"{stratixOrderReleaseParametersForRuan.orderFileKeyPfx}_{stratixOrderReleaseParametersForRuan.orderFileKeyNumber}";
            }

            string releaseWeight = $"{helperData.ReleaseWeight}";

            string packageType = helperData.PackagingCode;


            List<Serialization.Comment> orderReleaseComments = new List<Serialization.Comment>();

            StringBuilder concatenatedComments = new StringBuilder();
            StringBuilder concatenatedCarrierInstructionComments = new StringBuilder();
            if (!string.IsNullOrEmpty(helperData.LoadComments))
            {
                concatenatedComments.Append($"Load Comments: {helperData.LoadComments}");
                orderReleaseComments.Add(new Serialization.Comment()
                {
                    CommentType = "PICKUP_INSTR",
                    CommentValue = helperData.LoadComments
                });
            }

            

            if (!string.IsNullOrEmpty(helperData.ShippingComments))
            {
                concatenatedComments.AppendLine($"Shipping Comments: {helperData.ShippingComments}");
                concatenatedCarrierInstructionComments.AppendLine($"Shipping Comments: {helperData.ShippingComments}");
            }

            if (!string.IsNullOrEmpty(helperData.DeliveryComments))
            {
                concatenatedComments.AppendLine($"Delivery Comments: {helperData.DeliveryComments}");
                concatenatedCarrierInstructionComments.AppendLine($"Delivery Comments: {helperData.DeliveryComments}");
            }

            if (!string.IsNullOrEmpty(concatenatedComments.ToString()))
            {
                orderReleaseComments.Add(new Serialization.Comment()
                {
                    CommentType = "COMMENTS",
                    CommentValue = concatenatedComments.ToString()
                });
            }

            if (!string.IsNullOrEmpty(concatenatedCarrierInstructionComments.ToString()))
            {
                orderReleaseComments.Add(new Serialization.Comment()
                {
                    CommentType = "CARRIER_INSTR",
                    CommentValue = concatenatedCarrierInstructionComments.ToString()
                });
            }

        

            List<Serialization.ReferenceNumber> orderReleaseReferenceNumbers = new List<Serialization.ReferenceNumber>();
            orderReleaseReferenceNumbers.Add(new Serialization.ReferenceNumber()
            {
                ReferenceNumberType = "SO_NUM",
                ReferenceNumberValue = $"{ruanUniqueOrderNumber}"
            }
                );

            orderReleaseReferenceNumbers.Add(new Serialization.ReferenceNumber()
            {
                ReferenceNumberType = "SOLD_TO_CUST_NUM",
                ReferenceNumberValue = $"{helperData.SoldToName} {helperData.SoldToAddress1} {helperData.SoldToAddress2} {helperData.SoldToAddress3} {helperData.SoldToCity} {helperData.SoldToState} {helperData.SoldToZipCode} {helperData.SoldToCountry}"
            }
                );
            orderReleaseReferenceNumbers.Add(new Serialization.ReferenceNumber()
            {
                ReferenceNumberType = "CUSNM",
                ReferenceNumberValue = totalOrderCount.ToString()
            }
            );

            if (!string.IsNullOrEmpty(helperData.CustomerPO))
            {
                orderReleaseReferenceNumbers.Add(new Serialization.ReferenceNumber()
                {
                    ReferenceNumberType = "CUST_PO",
                    ReferenceNumberValue = helperData.CustomerPO
                }
                );
            }

            if (!string.IsNullOrEmpty(helperData.PartID))
            {
                orderReleaseReferenceNumbers.Add(new Serialization.ReferenceNumber()
                {
                    ReferenceNumberType = "PARENT_NUMBER",
                    ReferenceNumberValue = helperData.PartID
                }
                );
            }

            //if (helperData.EarliestDueDateTolerance > 0) // Removed for now. But, will evaluate later.
            //{
            //    helperData.OrderDeliveryDateFrom =
            //        helperData.OrderDeliveryDateFrom.AddDays(helperData.EarliestDueDateTolerance);
            //}

            if (helperData.OrderDeliveryDateFromHour > 0)
            {
                helperData.OrderDeliveryDateFrom = helperData.OrderDeliveryDateFrom.AddHours(helperData.OrderDeliveryDateFromHour);
                if (helperData.OrderDeliveryDateFrom < DateTime.Now)
                {
                    helperData.OrderDeliveryDateFrom = DateTime.Now;
                }
            }

            if (helperData.OrderDeliveryDateToHour > 0)
            {
                helperData.OrderDeliveryDateTo = helperData.OrderDeliveryDateTo.AddHours(helperData.OrderDeliveryDateToHour);
                if (helperData.OrderDeliveryDateTo < DateTime.Now)
                {
                    helperData.OrderDeliveryDateTo = DateTime.Now;
                }
            }


            APIReleaseOrder ruanReleaseOrder = new APIReleaseOrder
            {
                TransmissionType = "FRESH",
                SenderTransmissionNo = $"HS-{ruanUniqueOrderNumber}",
                ReleaseOrders = new List<ReleaseOrder>()
                {
                        new ReleaseOrder()
                        {
                            OrderHeader = new OrderHeader()
                            {
                                DomainName =  "RUAN/HS",
                                OrderNumber = ruanUniqueOrderNumber,
                                TransactionCode = "RC",
                                IntegrationCommand = "RemoveShipmentRefForRC",
                                PaymentMethod = "TPB",
                                TimeWindowEmphasis = "DELV",
                                Priority = "3",
                                StatusValue = stratixOrderReleaseParametersForRuan.orderReleaseStatusValue,
                                StatusType = "CANCELLED",
                                OrderShippingConfiguration =  "SHIP_UNIT_LINES",
                                OrderType = stratixOrderReleaseParametersForRuan.orderFileKeyPfx.Equals("SO") ? "SALES_ORDER" : "TRANSFERS",
                                CustomerServiceRepInfo = new CustomerServiceRepInfo()
                                {
                                    CustomerServiceRepName = helperData.InsideSalesPersonName,
                                    CustomerServiceRepEmail = helperData.InsideSalesPersonEmail

                                },
                                ReferenceNumbers = orderReleaseReferenceNumbers,
                                Comments = orderReleaseComments
                            },//OrderHeader
                            ShipFrom = new ShipFrom()
                            {
                                DomainName = "RUAN/HS",
                                Id = helperData.ShipFromID,
                                Name = helperData.ShipFromName,
                                AddressLine1 = $"{helperData.ShipFromAddress1} {helperData.ShipFromAddress2} {helperData.ShipFromAddress3}",
                                City = helperData.ShipFromCity,
                                State = helperData.ShipFromState,
                                Zip = helperData.ShipFromZipCode,
                                Country = helperData.ShipFromCountry,
                                Role = "SHIPFROM/SHIPTO",
                                PostLocationToOTM = "true"
                            },
                            ShipTo = new ShipTo()
                            {
                                DomainName = "RUAN/HS",
                                Id = helperData.ShipToID,
                                Name = helperData.ShipToName,
                                AddressLine1 = $"{helperData.ShipToAddress1} {helperData.ShipToAddress2} {helperData.ShipToAddress3}",
                                City = helperData.ShipToCity,
                                State = helperData.ShipToState,
                                Zip = helperData.ShipToZipCode,
                                Country = helperData.ShipToCountry,
                                Role = "SHIPFROM/SHIPTO",
                                PostLocationToOTM = "true"
                            },
                            ShippingAndDeliveryDates = !String.IsNullOrEmpty(helperData.ShipDateTimeEarly.ToString())? new ShippingAndDeliveryDates()
                            {
                                ShipDateTimeEarly = helperData.OrderDeliveryDateFrom,
                                DeliveryDateTimeEarly = helperData.OrderDeliveryDateFrom, //$"{earliestDeliveryDateTimeWithTimeStamp:yyyy-MM-ddTHH:mm:ss.fffffffzzz}",
                                DeliveryDateTimeLate  = helperData.OrderDeliveryDateTo //$"{latestDeliveryDateTimeWithTimeStamp:yyyy-MM-ddTHH:mm:ss.fffffffzzz}",
                            }:new ShippingAndDeliveryDates()
                            {
                                DeliveryDateTimeEarly = helperData.OrderDeliveryDateFrom, //$"{earliestDeliveryDateTimeWithTimeStamp:yyyy-MM-ddTHH:mm:ss.fffffffzzz}",
                                DeliveryDateTimeLate  = helperData.OrderDeliveryDateTo //$"{latestDeliveryDateTimeWithTimeStamp:yyyy-MM-ddTHH:mm:ss.fffffffzzz}",
                            },
                            OrderRouting = new OrderRouting()
                            {
                                ShipWithGroupId = "TBD",
                                PreferredTransportationMode = "TL",
                                EquipmentGroup = "FLAT"
                            },
                            LineItems = new List<Serialization.LineItem>()
                            {
                                new Serialization.LineItem()
                                {
                                    AutoCreateItem = "Y",
                                    AutoCreateItemMaster= "Y",
                                    LineItemNumber = $"{ruanUniqueOrderNumber}-1",//alway append by -1
                                    TransportUnitKey = $"{ruanUniqueOrderNumber}-001",//alway append by -001
                                    ItemNumber = ruanUniqueOrderNumber,
                                    ItemName = ruanUniqueOrderNumber,
                                    ItemDescription = helperData.OrderProductDescription1,
                                    ItemCommodityGroup="FAK",//Hard Coded Per Runi's REvision
                                    Quantity = "5",
                                    QuantityUnitOfMeasure = "EA",
                                    WeightGross = helperData.ReleaseWeight.ToString(CultureInfo.InvariantCulture),
                                    WeightGrossUnitOfMeasure= "LB",
                                    VolumeGross = "0",
                                    VolumeGrossUnitOfMeasure = "CUFT",
                                    LineItemDimensions = new Serialization.LineItemDimensions()
                                    {
                                        Length = helperData.PartLength.HasValue ? helperData.PartLength.ToString() : "0",
                                        Width = helperData.PartWidth.HasValue ? helperData.PartWidth.ToString() : "0",
                                        Height = "0",
                                        UnitOfMeasure = "IN",
                                        Weight = helperData.ReleaseWeight.ToString(),
                                        WeightUnitOfMeasure = "LB",
                                        Volume = "0",
                                        VolumeUnitOfMeasure = "CUFT",
                                        UserDefinedCommodity = null
                                    },
                                    ItemMaster = new ItemMaster()
                                    {
                                       ReferenceNumbers = new List<Serialization.ReferenceNumber>()
                                    }//ItemMaster
                                }//LineItem
                            },//LineItems
                            ShipUnits = new Serialization.ShipUnits
                            {
                                ShipUnitList = new List<ShipUnit>()
                                {
                                    new Serialization.ShipUnit()
                                    {
                                    ShipFromLocationDomainName = "RUAN/HS",
                                    ShipFromLocation = helperData.ShipFromID,
                                    ShipToLocationDomainName = "RUAN/HS",
                                    ShipToLocation = helperData.ShipToID,
                                    DomainName = "RUAN/HS",
                                    TransactionCode = "IU",
                                    ShipUnitKey = $"{ruanUniqueOrderNumber}-001",//alway append by -001
                                    ShipUnitType = $"{packageType}",                               //helperData.InventoryType.ToUpper(),
                                    ShipUnitCount = "5",
                                    WeightUnitOfMeasure = "LB",
                                    VolumeUnitOfMeasure = "CUFT",
                                    WeightGross = helperData.ReleaseWeight.ToString(),
                                    WeightGrossUnitOfMeasure = "LB",
                                    VolumeGross = "0",
                                    VolumeGrossUnitOfMeasure = "CUFT",
                                    IsSplitAllowed = "N",
                                    IsCountSplittable = "N",
                                    IsRepackAllowed = "N",
                                    ShipUnitContents = new List<ShipUnitContent>()
                                    {
                                        new ShipUnitContent()
                                        {
                                            DomainName = "RUAN/CUST",
                                            ReleaseLineSequenceNumber = "1",
                                            OrderNumber = ruanUniqueOrderNumber,
                                            LineItemNumber = $"{ruanUniqueOrderNumber}-1",//alway append by -1,
                                            ItemNumber = ruanUniqueOrderNumber,
                                            ItemName = ruanUniqueOrderNumber,
                                            ItemDescription = helperData.OrderProductDescription1,
                                            ItemCommodityGroup="FAK",//Hard Coded Per Runi's Revision
                                            Quantity = "5",
                                            Weight = helperData.ReleaseWeight.ToString(),
                                            WeightUnitOfMeasure = "LB",
                                            Volume = "0",
                                            VolumeUnitOfMeasure = "CUFT",
                                            WeightGross = helperData.ReleaseWeight.ToString(),
                                            WeightGrossUnitOfMeasure = "LB",
                                            VolumeGross = "0",
                                            VolumeGrossUnitOfMeasure = "CUFT",
                                            PackagedItem = ruanUniqueOrderNumber
                                        }
                                    },
                                    ShipUnitDimensions = new ShipUnitDimensions()
                                    {
                                        Length = helperData.PartLength.HasValue ? helperData.PartLength.ToString() : "0",
                                        LengthUnitOfMeasure = "IN",
                                        Width = helperData.PartWidth.HasValue ? helperData.PartWidth.ToString() : "0",
                                        WidthUnitOfMeasure = "IN",
                                        Height = "0",
                                        HeightUnitOfMeasure = "FT"
                                    }
                                }//ShipUnit
                            }//ShipUnitList
                        }//ShipUnits

                    }//ReleaseOrder
                }
            };

         
            SubmitToRuan(stratixOrderReleaseParametersForRuan.stratixInterchangeNumber, ruanReleaseOrder);
        }
        #endregion

        #region "Submit methods"
        public static void SubmitToRuan(long stratixInterchangeNumber, object apiObject)
        {
            RuanApiType apiType;
            string key = string.Empty;
            if (apiObject is APIReleaseOrder apiReleaseOrder)
            {
                apiType = RuanApiType.ReleaseOrders;

            }
            else if (apiObject is APIActualShipment apiActualShipment)
            {
                apiType = RuanApiType.ActualShipment;
            }
            else
            {
                throw new Exception("Invalid Type of Ruan API cannot send!");
            }

            if (Synchronize)
            {
                SubmitToRuanAsync(apiType, apiObject, stratixInterchangeNumber).Wait();
            }
            else
            {
                Task.Run(() => SubmitToRuanAsync(apiType, apiObject, stratixInterchangeNumber));
            }
        }

        public static async Task SubmitToRuanAsync(RuanApiType apiType, object apiObject, long key)
        {
            string xml = Serialize(apiObject);
            string dbXml = SerializeForDb(apiObject);
            string uri = $"{apiUriBase}{GetActionUri(apiType)}";

            //PostToRuan(xml);

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(120d); //default is 100
                    using (StringContent httpContent = new StringContent(xml, Encoding.UTF8, "application/xml"))
                    {


                        using (HttpResponseMessage response = await client.PostAsync(uri, httpContent))
                        //using (HttpResponseMessage response =  client.PostAsync(uri, httpContent)) // without the await during testing.
                        {
                            //try
                            //{
                            //    Debug.WriteLine(response.ToString());
                            //    LastResponse = response.ToString();
                            //    response.EnsureSuccessStatusCode(); //throw exception if not successful 

                            //}
                            //catch (Exception e)
                            //{
                            //    //set it back to be processed.
                            //    StratixOrderNotification.SetOrderNotificationToOpen(key);
                            //}


                            ////save to database after it gets sent to Ruan(If its fails, then it is saved in the job engine to reprocess it)
                            RuanXml ruanXml = new RuanXml(apiObject);
                            ruanXml.Save();
                            var test = ruanXml.RuanXMLNumber;

                        }
                    }
                }
            }
            catch (Exception e)
            {
                //let it continue to run as we don't want this queuing service to be stopped.
            }
        }


        /// <summary>
        /// Both PostToRuan and PostFilesToWebServiceEndPoint were created to triage during the asynchronous testing issue and it should not be used as part of the Ruan send.
        /// </summary>
        /// <param name="fileContentString"></param>
        public static void PostToRuan(string fileContentString)
        {


            //Establish request to upload the xmlcontents to MG WebServer.
            // HttpWebRequest request = (HttpWebRequest)WebRequest.Create(MercuryGateFileEndPointPath);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://apiqagateway.ruan.com/ReleaseOrders");
           // HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://69.87.209.117:443/ReleaseOrders");
            request.ContentType = "application/xml"; //set the content type to XML
            request.Method = "POST"; //make an HTTP POST

            PostFilesToWebServiceEndPoint(request, fileContentString);
        }


        public static void PostFilesToWebServiceEndPoint(HttpWebRequest request, string fileContentString)
        {
            try
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(fileContentString);
                request.ContentLength = byteArray.Length;

                using (Stream dataStream = request.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    dataStream.Close();
                }

                using (HttpWebResponse httpResponse = request.GetResponse() as HttpWebResponse)
                {
                    Stream ResponseStream = null;
                    ResponseStream = httpResponse.GetResponseStream();
                    int responseCode = (int)httpResponse.StatusCode;
                    string responseBody = ((new StreamReader(ResponseStream)).ReadToEnd());
                }

                request.Abort();
            }
            catch (Exception ex)
            {
                var test = ex;
                throw;
            }
        }

        //////////////////////////////////////////////////////////////////// 
        #endregion
    }
}