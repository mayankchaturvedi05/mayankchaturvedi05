using System;

namespace StratixRuanBusinessLogic
{
    public class ValidationException : ApplicationException
    {
        public string FieldName { get; set; }
        public string ObjectName { get; set; }

        //public ValidationException()
        //{
        //}

        //public ValidationException(string message) : base(message)
        //{
        //}

        public ValidationException(string message, string fieldName, string objectName)
            : base(message)
        {
            FieldName = fieldName;
            ObjectName = objectName;
        }

        public override string ToString()
        {
            string realExceptionName = this.GetType().Name;
            return string.Format("{0}: {1} has exception {2}", ObjectName, FieldName, realExceptionName);
        }
    }
}
