using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratixRuanBusinessLogic
{
    public class MSCInvalidOperationException : InvalidOperationException
    {
        private List<ValidationException> _validationExceptions;
        public List<ValidationException> ValidationExceptions
        {
            get
            {
                return _validationExceptions;
            }
            set
            {
                _validationExceptions = value;
            }
        }

        public MSCInvalidOperationException(string message, List<ValidationException> exceptions)
            : base(message)
        {
            _validationExceptions = exceptions;
        }

        public override string Message
        {
            get
            {
                string exceptionsMessage = "";
                foreach (ValidationException ve in ValidationExceptions)
                {
                    exceptionsMessage += ve.ObjectName + " : " + ve.Message;
                }

                return base.Message + Environment.NewLine + exceptionsMessage;
            }
        }
    }
}
