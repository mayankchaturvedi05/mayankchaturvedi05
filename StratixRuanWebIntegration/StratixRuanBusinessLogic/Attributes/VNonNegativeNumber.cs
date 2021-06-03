using System;

namespace StratixRuanBusinessLogic.Attributes
{
    public class VNonNegativeNumber : ValidateSelfBase
    {
        public VNonNegativeNumber(string Alias)
        {
            this.Alias = Alias;
            this.ErrorMessage = "is not 0 or greater\n";
        }

        public override bool Validate(object Object, string fieldName, string objectName, out ValidationException exception)
        {
            if(Object == null)
            {
                FieldMustBeZeroOrPositiveException nze = new FieldMustBeZeroOrPositiveException(ValidationFailedString(fieldName), fieldName, objectName);
                exception = nze as ValidationException;
                return false;
            }

            Double D = Convert.ToDouble(Object);
            
            if (D >= 0)
            {
                exception = null;
                return true;
            }
            else
            {
                FieldMustBeZeroOrPositiveException nze = new FieldMustBeZeroOrPositiveException(ValidationFailedString(fieldName), fieldName, objectName);
                exception = nze as ValidationException;
                return false;
            }
        }
    }
}
