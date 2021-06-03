namespace StratixRuanBusinessLogic.Attributes
{
    public class VCustomValidation : ValidationAttributeBase
    {
        public VCustomValidation(string Alias, string ErrorString)
        {
            this.Alias = Alias;
            this.ErrorMessage = ErrorString;
        }

        public override bool Validate(string fieldName, string objectName, out ValidationException exception)
        {
            ValidationException ve = new ValidationException(ValidationFailedString(fieldName), fieldName, objectName);
            exception = ve;
            return false;
        }
    }
}
