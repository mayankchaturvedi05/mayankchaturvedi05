using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StratixRuanBusinessLogic.Ruan.Action;
using System.Configuration;
using StratixRuanBusinessLogic;

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
    }
}
