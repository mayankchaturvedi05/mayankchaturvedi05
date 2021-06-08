using System;

namespace StratixRuanBusinessLogic.Attributes
{
    public class VBetweenDateRange : ValidateSelfBase
    {
        private string _min;
        public string Min
        {
            get { return _min; }
            set { _min = value; }
        }

        private string _max;
        public string Max
        {
            get { return _max; }
            set { _max = value; }
        }

        public VBetweenDateRange(string Alias, string min, string max)
        {
            this.Alias = Alias;
            this.Min = min;
            this.Max = max;
            this.ErrorMessage = "is not between " + Min + " and " + Max;
        }

        public override bool Validate(object Object, string fieldName, string objectName, out ValidationException exception)
        {
            DateTime? D = Convert.ToDateTime(Object);
            DateTime dateMin = Convert.ToDateTime(Min);
            DateTime dateMax = Convert.ToDateTime(Max);
            if ((Object == null) || (D >= dateMin && D <= dateMax))
            {
                exception = null;
                return true;
            }
            else
            {
                DateOutOfRangeException foor = new DateOutOfRangeException(ValidationFailedString(fieldName), fieldName, objectName, dateMin, dateMax);
                exception = foor as ValidationException;
                return false;
            }
        }
    }
}
