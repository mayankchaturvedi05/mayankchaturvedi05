namespace StratixRuanBusinessLogic
{
    public class FieldNullException : ValidationException
    {
        public FieldNullException(string message, string fieldName, string objectName)
            : base(message, fieldName, objectName)
        {
        }
    }
}
