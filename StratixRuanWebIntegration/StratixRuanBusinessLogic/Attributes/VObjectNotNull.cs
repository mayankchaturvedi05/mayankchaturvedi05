namespace StratixRuanBusinessLogic.Attributes
{
    public class VObjectNotNull : ValidateSelfBase
    {
        public VObjectNotNull(string Alias)
        {
            this.Alias = Alias;
            this.ErrorMessage = "is Null";
        }

        public override bool Validate(object Object, string fieldName, string objectName, out ValidationException exception)
        {
            if (Object != null)
            {
                exception = null;
                return true;
            }
            else
            {
                FieldNullException fne = new FieldNullException(ValidationFailedString(fieldName), fieldName, objectName);
                exception =  fne as ValidationException;
                return false;
            }
        }
    }
}
