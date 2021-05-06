using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StratixRuanBusinessLogic
{
    [DataContract]
    public class RuanStratixException
    {
        [DataMember]
        public string ExceptionMesssage { get; set; }
        [DataMember]
        public string ExceptionDescription { get; set; }
    }
}
