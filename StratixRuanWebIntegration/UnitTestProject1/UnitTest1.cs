using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StratixRuanBusinessLogic.Ruan.Action;
using System.Configuration;
using System.IO;
using System.Linq;
using System.ServiceModel.Syndication;
using StratixToRuanDataTransfer;
using System.Xml;
using System.Xml.Serialization;
using StratixRuanBusinessLogic.Ruan.Serialization;
using StratixRuanDataLayer;
using StratixRuanWebIntegration;
using GlobalState = StratixRuanBusinessLogic.GlobalState;
using StratixOrderNotification = StratixRuanBusinessLogic.Stratix.StratixOrderNotification;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GenerateSalesOrderFileTest()
        {
            StratixRuanDataLayer.GlobalState.StratixConnectionString = ConfigurationManager.AppSettings["StratixDsn"];

            var connectionSettings = ConfigurationManager.ConnectionStrings["qa"];
            if (connectionSettings != null)
            {
                GlobalState.ConnectionString = connectionSettings.ConnectionString;
               
            }

            
            RuanAction.Synchronize = true;
            StratixOrderReleaseParametersForRuan stratixOrderReleaseParametersForRuan = new StratixOrderReleaseParametersForRuan
            {
                orderFileKeyPfx = "SO",
                stratixInterchangeNumber = 1435,
                orderFileKeyNumber = 1169
            };
           
          stratixOrderReleaseParametersForRuan.orderFileItemNumber = 1;
          stratixOrderReleaseParametersForRuan.orderFileSubItemNumber = 1;
          stratixOrderReleaseParametersForRuan.orderReleaseStatusValue = "A";
          RuanAction.GenerateOrderReleaseForRuan(stratixOrderReleaseParametersForRuan);


        }

        [TestMethod]
        public void GenerateTransferOrderFileTestForIP()
        {
            StratixRuanDataLayer.GlobalState.StratixConnectionString = ConfigurationManager.AppSettings["StratixDsn"];

            var connectionSettings = ConfigurationManager.ConnectionStrings["qa"];
            if (connectionSettings != null)
            {
                GlobalState.ConnectionString = connectionSettings.ConnectionString;

            }

            RuanAction.Synchronize = true;
            StratixOrderReleaseParametersForRuan stratixOrderReleaseParametersForRuan = new StratixOrderReleaseParametersForRuan
            {
                orderFileKeyPfx = "IP",
                stratixInterchangeNumber = 1483,
                orderFileKeyNumber = 1530
            };

            stratixOrderReleaseParametersForRuan.orderFileItemNumber = 2;
            stratixOrderReleaseParametersForRuan.orderFileSubItemNumber = 1;
            stratixOrderReleaseParametersForRuan.orderReleaseStatusValue = "U";
            RuanAction.GenerateOrderReleaseForRuan(stratixOrderReleaseParametersForRuan);


        }

        [TestMethod]
        public void GenerateTransferOrderFileTestForJS()
        {
            StratixRuanDataLayer.GlobalState.StratixConnectionString = ConfigurationManager.AppSettings["StratixDsn"];

            var connectionSettings = ConfigurationManager.ConnectionStrings["qa"];
            if (connectionSettings != null)
            {
                GlobalState.ConnectionString = connectionSettings.ConnectionString;

            }

            RuanAction.Synchronize = true;
            StratixOrderReleaseParametersForRuan stratixOrderReleaseParametersForRuan = new StratixOrderReleaseParametersForRuan
            {
                orderFileKeyPfx = "JS",
                stratixInterchangeNumber = 1128,
                orderFileKeyNumber = 988
            };

            stratixOrderReleaseParametersForRuan.orderFileItemNumber = 2;
            stratixOrderReleaseParametersForRuan.orderFileSubItemNumber = 1;
            stratixOrderReleaseParametersForRuan.orderReleaseStatusValue = "U";
            RuanAction.GenerateOrderReleaseForRuan(stratixOrderReleaseParametersForRuan);


        }

        [TestMethod, Ignore]
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

        [TestMethod, Ignore]
        public void TestMethod3()
        {

            StratixRuanDataLayer.GlobalState.StratixConnectionString = ConfigurationManager.AppSettings["StratixDsn"];

            string path = @"C:\Stratix\StratixRuanWebIntegration\UnitTestProject1\testDataFiles\TATest1.xml";
            XmlSerializer s = new XmlSerializer(typeof(APITransportationShipment));
            TextReader r = new StreamReader(path);

            APITransportationShipment apiTransportationPITransportationShipment = (APITransportationShipment)s.Deserialize(r);
            r.Close();

            RuanAction.ProcessTaTest(apiTransportationPITransportationShipment);
           // RuanAction.DeleteTransportFromStratix(apiTransportationPITransportationShipment);

            //var test = new RuanStratixServiceClient();

            //RuanStratixService svcTest = new RuanStratixService();
        }
    }
}
