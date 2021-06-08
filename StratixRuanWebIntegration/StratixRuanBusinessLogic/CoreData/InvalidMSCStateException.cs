using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratixRuanBusinessLogic.CoreData
{
    public class InvalidMSCStateException : InvalidOperationException
    {
        public string Caption {get;set;}
    
        public InvalidMSCStateException(string message, string caption) : base(message)
        {
            Caption = caption;
        }
        public InvalidMSCStateException(string message, string caption, Exception innerException) : base(message, innerException)
        {
            Caption = caption;
        }
    }
}
