using System;

namespace StratixRuanBusinessLogic.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class ValidationAttributeBase : Attribute
    {
        private string _alias;
        public string Alias
        {
            get { return _alias; }
            set { _alias = value; }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }

        public abstract bool Validate(string fieldName, string objectName, out ValidationException exception);

        public virtual bool Validate(object one, string fieldName, string objectName, out ValidationException exception)
        {
            exception = null;
            return Validate(fieldName, objectName, out exception);
        }

        public virtual string ValidationFailedString(string fieldName)
        {
           
            {
                return Alias + " " + ErrorMessage + "\r\n";
            }
        }
    }
}
