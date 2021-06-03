namespace StratixRuanBusinessLogic
{
    public class FieldCustomValidationMissingException : ValidationException
    {
        public FieldCustomValidationMissingException(string message, string fieldName, string objectName)
            : base(message, fieldName, objectName)
        {
        }
    }
}
