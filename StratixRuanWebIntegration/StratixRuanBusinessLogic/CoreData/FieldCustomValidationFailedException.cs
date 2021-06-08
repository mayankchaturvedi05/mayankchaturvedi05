namespace StratixRuanBusinessLogic
{
    public class FieldCustomValidationFailedException : ValidationException
    {
        public FieldCustomValidationFailedException(string message, string fieldName, string objectName)
            : base(message, fieldName, objectName)
        {
        }
    }
}
