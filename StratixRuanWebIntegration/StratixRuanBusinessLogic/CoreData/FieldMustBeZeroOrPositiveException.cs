namespace StratixRuanBusinessLogic
{
    public class FieldMustBeZeroOrPositiveException : ValidationException
    {
        public FieldMustBeZeroOrPositiveException(string message, string fieldName, string objectName)
            : base(message, fieldName, objectName)
        {
        }
    }
}
