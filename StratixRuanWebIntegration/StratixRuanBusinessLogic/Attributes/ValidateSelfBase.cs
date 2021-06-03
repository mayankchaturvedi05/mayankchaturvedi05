namespace StratixRuanBusinessLogic.Attributes
{
    public class ValidateSelfBase : ValidationAttributeBase
    {
        public override bool Validate(string fieldName, string objectName, out ValidationException exception)
        {
            return Validate(null, fieldName, objectName, out exception);
        }

        public override bool Validate(object o, string fieldName, string objectName, out ValidationException exception)
        {
            exception = null;
            return false;
        }
    }
}
