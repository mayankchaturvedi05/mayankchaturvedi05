namespace StratixRuanBusinessLogic
{
    public class FieldMustBeNonZeroException : ValidationException
    {
        public FieldMustBeNonZeroException(string message, string fieldName, string objectName)
            : base(message, fieldName, objectName)
        {
        }
    }
}
