using System;

namespace StratixRuanBusinessLogic
{
    public class CodeLookupFailedException : Exception
    {
        public string LookupType { get; set; }
        public CodeLookupFailedException(string typeName)
            : base()
        {
            LookupType = typeName;
        }
    }
}
