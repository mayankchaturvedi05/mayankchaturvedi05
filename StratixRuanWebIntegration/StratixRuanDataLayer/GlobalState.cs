using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratixRuanDataLayer
{
    public class GlobalState
    {
        private static string _stratixConnectionString;
        public static string StratixConnectionString
        {
            get
            {
                return _stratixConnectionString;
            }
            set
            {
                _stratixConnectionString = value;
            }
        }
    }
}
