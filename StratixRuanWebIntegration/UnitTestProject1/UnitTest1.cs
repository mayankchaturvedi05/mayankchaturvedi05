using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StratixRuanBusinessLogic.Ruan.Action;
using System.Configuration;
using System.IO;
using System.Linq;
using StratixRuanBusinessLogic;
using StratixRuanBusinessLogic.Stratix;
using StratixToRuanDataTransfer;
using System.Xml;
using System.Xml.Serialization;
using StratixRuanBusinessLogic.Ruan.Serialization;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            var connectionSettings = ConfigurationManager.ConnectionStrings["qa"];
            if (connectionSettings != null)
            {
                GlobalState.ConnectionString = connectionSettings.ConnectionString;
               
            }
            //RuanAction.GenerateOrderReleaseForRuan(661);
            

           
        }

        [TestMethod]
        public void TestMethod2()
        {

            List<StratixOrderNotification> allPendingOrderNtNotifications = StratixOrderNotification.GetStratixOrderNotification();
            IEnumerable<StratixOrderNotification> allPendingOrderNotificationAddList = allPendingOrderNtNotifications.Where(x => x.InterchangeActivity == "A");
            IEnumerable<StratixOrderNotification> allPendingOrderNotificationChangesList = allPendingOrderNtNotifications.Where(x => x.InterchangeActivity != "A");//changes or updates etc.
            IEnumerable<long> uniqueChangeOrderNumbers = allPendingOrderNotificationChangesList.ToList()
                .Select(x => x.ReferenceNumber).Distinct();



            foreach (long uniqueChangeOrderNumber in uniqueChangeOrderNumbers.ToList())
            {
                var pendingChangeAlreadyInAddlist = allPendingOrderNotificationAddList.FirstOrDefault(x =>x.ReferenceNumber == uniqueChangeOrderNumber);
                if (pendingChangeAlreadyInAddlist != null)
                { //add flag and send to ruan
                    //update as ackknowledge even though not sent to Ruan
                    var sdf = pendingChangeAlreadyInAddlist;
                }
                else
                {
                    //update flag to Ruan
                    //send to ruan
                    //update the acknowledge flags in stratix.
                }
            }

        }

        [TestMethod]
        public void TestMethod3()
        {

            StratixRuanDataLayer.GlobalState.StratixConnectionString = ConfigurationManager.AppSettings["StratixDsn"];

            string path = @"C:\Stratix\StratixRuanWebIntegration\UnitTestProject1\testDataFiles\TATest1.xml";
            XmlSerializer s = new XmlSerializer(typeof(APITransportationShipment));
            TextReader r = new StreamReader(path);

            APITransportationShipment apiTransportationPITransportationShipment = (APITransportationShipment)s.Deserialize(r);
            r.Close();

           // RuanAction.TAtoStratix(apiTransportationPITransportationShipment);
            RuanAction.DeleteTransportFromStratix(apiTransportationPITransportationShipment);
        }
    }
}
