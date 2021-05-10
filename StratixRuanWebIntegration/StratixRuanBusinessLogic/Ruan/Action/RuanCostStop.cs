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
        public List<long> TruckReleases { get; set; } = new List<long>();

        public void AddCost(string stringCost)
        {
            if (double.TryParse(stringCost, out double cost))
            {
                TotalCost += cost;
            }
        }

        public void AddTruckRelease(string stringTruckRelease)
        {
            if (Int64.TryParse(stringTruckRelease, out long truckRelease))
            {
                TruckReleases.Add(truckRelease);
            }
        }
    }
}
