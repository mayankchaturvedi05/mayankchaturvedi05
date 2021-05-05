using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StratixRuanBusinessLogic
{
    [DataContract]
    public class RuanCredentials
    {
        [DataMember]
        public string username { get; set; }
        [DataMember]
        public string password { get; set; }
    }
}
