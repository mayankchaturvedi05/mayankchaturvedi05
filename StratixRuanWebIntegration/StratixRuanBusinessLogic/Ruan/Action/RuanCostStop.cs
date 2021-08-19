using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratixRuanBusinessLogic.Ruan.Action
{
    internal class RuanCostStop
    {
        public RuanCostStop() { }

        public RuanCostStop(string stopNumber)
        {
            StopNumber = stopNumber;
        }

        public string StopNumber { get; set; }
        public double TotalCost { get; set; } = 0d;
        public List<string> KeyOrderIds { get; set; } = new List<string>();

        public void AddCost(string stringCost)
        {
            if (double.TryParse(stringCost, out double cost))
            {
                TotalCost += cost;
            }
        }

        public void AddOrders(string keyorderId)
        {
                KeyOrderIds.Add(keyorderId);
        }
    }
}
