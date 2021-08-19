using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratixRuanBusinessLogic.Stratix
{
    public class StratixOrderNotification
    {
        public long InterchangeNumber { get; set; }
        public long ReferenceNumber { get; set; }
        public long ReferenceItem { get; set; }
        public long ReferenceSubItem { get; set; }
        public string InterchangeActivity { get; set; }
        public string ReferencePrefix { get; set; }
        public DateTime ActivityDateTime { get; set; }
        public short AcknowledgedFlag { get; set; }
        public DateTime AcknowledgedDateTime { get; set; }

        public StratixOrderNotification(StratixRuanDataLayer.StratixOrderNotification source)
        {
            InterchangeNumber = source.InterchangeNumber;
            ReferenceNumber = source.ReferenceNumber;
            ReferenceItem = source.ReferenceItem;
            ReferenceSubItem = source.ReferenceSubItem;
            InterchangeActivity = source.InterchangeActivity;
            ActivityDateTime = source.ActivityDateTime;
            AcknowledgedFlag = source.AcknowledgedFlag;
            AcknowledgedDateTime = source.AcknowledgedDateTime;
            ReferencePrefix = source.ReferencePrefix;
        }

        public static List<StratixOrderNotification> GetStratixOrderNotification()
        {
            List<StratixOrderNotification> convertedList = new List<StratixOrderNotification>();
            List<StratixRuanDataLayer.StratixOrderNotification> dataLayerResultsList = StratixRuanDataLayer.StratixOrderNotification.GetStratixOrderNotification();

            foreach (var dataLayerResult in dataLayerResultsList)
            {
                convertedList.Add(new StratixOrderNotification(dataLayerResult));
               
            }
 
            return convertedList;
        }
    }
}
