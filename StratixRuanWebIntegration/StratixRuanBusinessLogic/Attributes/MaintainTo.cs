using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratixRuanBusinessLogic.Attributes
{
    public class MaintainTo : Attribute
    {

        public MaintainTo(Type type)
        {
            Type = type;
            IsNumber = true;
            IsCode = false;
            UseThisNumberFieldInstead = null;
        }

        public MaintainTo(Type type, bool isCode, string useThisNumberFieldInstead = null, string regExReplace = null)
        {
            Type = type;
            IsNumber = false;
            IsCode = isCode;
            UseThisNumberFieldInstead = useThisNumberFieldInstead;
            RegExReplace = regExReplace;
        }

        public Type Type { get; }
        public bool IsNumber { get; }
        public bool IsCode { get; }

        public string UseThisNumberFieldInstead { get; }
        public string RegExReplace { get; }
    }
}
