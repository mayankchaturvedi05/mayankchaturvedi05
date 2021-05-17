using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using StratixRuanBusinessLogic;
using StratixRuanBusinessLogic.Ruan.Serialization;

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
            //TODO: uncomment
            //try
            //{
            //   // apiUriBase = ConfigurationManager.AppSettings["RuanApiUri"];
            //    if (string.IsNullOrEmpty(apiUriBase)) throw new Exception();
            //}
            //catch (Exception)
            //{
            //    throw new Exception("Ruan API is not properly configured for the environment, contact support.");
            //}
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
                    return "/ActualShipments";
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

        public static void GenerateOrderReleaseForRuan(long tslacNumber)
        {
            StratixRuanBusinessLogic.Stratix.RuanOrderIntegrationHelperData helperData = StratixRuanBusinessLogic.Stratix.RuanOrderIntegrationHelperData
                .GetDataToConstructRuanOrderIntegrationHelperData(tslacNumber);
        }
        #endregion

        #region "Submit methods"
        public static void SubmitToRuan(object apiObject)
        {
            RuanApiType apiType;
            string key = string.Empty;
            if (apiObject is APIReleaseOrder apiReleaseOrder)
            {
                apiType = RuanApiType.ReleaseOrders;
                key = apiReleaseOrder.SenderTransmissionNo.Replace("HS-", null);

            }
            else if (apiObject is APIActualShipment apiActualShipment)
            {
                apiType = RuanApiType.ActualShipment;
                key = apiActualShipment.SenderTransmissionNo.Replace("HS-", null);
            }
            else
            {
                throw new Exception("Invalid Type of Ruan API cannot send!");
            }

            if (Synchronize)
            {
                SubmitToRuanAsync(apiType, apiObject, key).Wait();
            }
            else
            {
                Task.Run(() => SubmitToRuanAsync(apiType, apiObject, key));
            }
        }

        public static async Task SubmitToRuanAsync(RuanApiType apiType, object apiObject, string mscKey)
        {
            string xml = Serialize(apiObject);
            string dbXml = SerializeForDb(apiObject);
            string uri = $"{apiUriBase}{GetActionUri(apiType)}";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(120d); //default is 100
                    using (StringContent httpContent = new StringContent(xml, Encoding.UTF8, "application/xml"))
                    {
                        using (HttpResponseMessage response = await client.PostAsync(uri, httpContent))
                        {
                            Debug.WriteLine(response.ToString());
                            LastResponse = response.ToString();
                            response.EnsureSuccessStatusCode(); //throw exception if not successful 

                            ////save to database after it gets sent to Ruan(If its fails, then it is saved in the job engine to reprocess it)
                            //RuanXml ruanXml = new RuanXml(apiObject);
                            //ruanXml.Save();
                        }
                    }
                }
            }
            catch (Exception e)
            {
    
            }
        }
        #endregion
    }
}