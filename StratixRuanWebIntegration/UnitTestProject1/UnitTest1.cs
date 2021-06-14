using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StratixRuanBusinessLogic.Ruan.Action;
using System.Configuration;
using System.Linq;
using StratixRuanBusinessLogic;
using StratixRuanBusinessLogic.Stratix;
using StratixToRuanDataTransfer;

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
            RuanAction.GenerateOrderReleaseForRuan(661);
            

           
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
    }
}
