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
                default:
                    return "";
            }
        }
        #endregion

        //mapping functions go here
        #region Mapping Functions 
            
        //creates and submits Actual Shipment (SA) to Ruan from a manifestHeaderNumber
        public static void SubmitActualShipment(long manifestHeaderNumber)
        {
           
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
                    $"{stratixOrderReleaseParametersForRuan.orderFileKeyNumber}_{stratixOrderReleaseParametersForRuan.orderFileItemNumber}_{stratixOrderReleaseParametersForRuan.orderFileKeyNumber}";
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
                            ShippingAndDeliveryDates = !String.IsNullOrEmpty(helperData.OrderDeliveryDateFrom.ToString())? new ShippingAndDeliveryDates()
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
                            try
                            {
                                Debug.WriteLine(response.ToString());
                                LastResponse = response.ToString();
                                response.EnsureSuccessStatusCode(); //throw exception if not successful 

                            }
                            catch (Exception e)
                            {
                                //set it back to be processed.
                                StratixOrderNotification.SetOrderNotificationToOpen(key);
                            }


                            ////save to database after it gets sent to Ruan(If its fails, then it is saved in the job engine to reprocess it)
                            RuanXml ruanXml = new RuanXml(apiObject);
                            ruanXml.Save();

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