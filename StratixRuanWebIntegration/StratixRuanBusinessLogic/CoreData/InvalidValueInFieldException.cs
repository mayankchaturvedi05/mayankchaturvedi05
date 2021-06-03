namespace StratixRuanBusinessLogic
{
    public class InvalidValueInFieldException : ValidationException
    {
        public InvalidValueInFieldException(string message, string fieldName, string objectName)
            : base(message, fieldName, objectName)
        {
        }
    }
}
