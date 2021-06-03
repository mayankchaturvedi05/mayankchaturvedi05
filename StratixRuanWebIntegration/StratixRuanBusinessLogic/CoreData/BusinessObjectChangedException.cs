using System;
using StratixRuanInterfaces;

namespace StratixRuanBusinessLogic
{
    public class BusinessObjectChangedException : ApplicationException
    {
        public IBusinessLogicBase Original { get; set; }

        public BusinessObjectChangedException(IBusinessLogicBase original)
        {
            Original = original;
        }

        public BusinessObjectChangedException(string message, IBusinessLogicBase original)
            : base(message)
        {
            Original = original;
        }
    }
}
