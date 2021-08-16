using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratixRuanDataLayer
{
    public class StratixOrderReleaseParametersForRuan
    {
        public long stratixInterchangeNumber { get; set; }
        public string orderFileKeyPfx { get; set; }
        public long orderFileKeyNumber { get; set; }
        public short? orderFileItemNumber { get; set; }
        public short? orderFileSubItemNumber { get; set; }
        public string orderReleaseStatusValue { get; set; }
    }
}
