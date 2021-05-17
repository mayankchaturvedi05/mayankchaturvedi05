using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StratixRuanBusinessLogic.Ruan.Action;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            RuanAction.GenerateOrderReleaseForRuan(661);
        }
    }
}
