using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratixRuanBusinessLogic.Ruan.Action
{
    public class RuanSaException : Exception
    {
        public RuanSaException(string message) : base(message)
        {
        }
    }
}
