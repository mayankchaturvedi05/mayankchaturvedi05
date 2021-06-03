using System;

namespace StratixRuanBusinessLogic.Attributes
{
    public class VGreaterThanZero : ValidateSelfBase
    {
        public VGreaterThanZero(string Alias)
        {
            this.Alias = Alias;
            this.ErrorMessage = "is zero or less\n";
        }

        public override bool Validate(object Object, string fieldName, string objectName, out ValidationException exception)
        {
            if(Object == null)
            {
                FieldMustBeNonZeroException nze = new FieldMustBeNonZeroException(ValidationFailedString(fieldName), fieldName, objectName);
                exception = nze as ValidationException;
                return false;
            }

            Double D = Convert.ToDouble(Object);
            
            if (D > 0)
            {
                exception = null;
                return true;
            }
            else
            {
                FieldMustBeNonZeroException nze = new FieldMustBeNonZeroException(ValidationFailedString(fieldName), fieldName, objectName);
                exception = nze as ValidationException;
                return false;
            }
        }
    }
}
