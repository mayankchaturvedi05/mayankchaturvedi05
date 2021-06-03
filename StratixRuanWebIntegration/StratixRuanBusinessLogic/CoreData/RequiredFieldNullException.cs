namespace StratixRuanBusinessLogic
{
    public class RequiredFieldNullException : ValidationException
    {
        public RequiredFieldNullException(string message, string fieldName, string objectName)
            : base(message, fieldName, objectName)
        {
        }
    }
}
