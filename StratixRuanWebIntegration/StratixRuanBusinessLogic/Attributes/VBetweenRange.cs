using System;

namespace StratixRuanBusinessLogic.Attributes
{
    public class VBetweenRange : ValidateSelfBase
    {
        private double _min;
        public double Min
        {
            get { return _min; }
            set { _min = value; }
        }

        private double _max;
        public double Max
        {
            get { return _max; }
            set { _max = value; }
        }


        public VBetweenRange(string Alias, double min, double max)
        {
            this.Alias = Alias;
            this.Min = min;
            this.Max = max;
            this.ErrorMessage = "is not between " + Min + " and " + Max;
        }

        public override bool Validate(object Object, string fieldName, string objectName, out ValidationException exception)
        {
            Double? D = Convert.ToDouble(Object);
            if (D >= Min && D <= Max)
            {
                exception = null;
                return true;
            }
            else
            {
                FieldOutOfRangeException foor = new FieldOutOfRangeException(ValidationFailedString(fieldName), fieldName, objectName, Min, Max);
                exception = foor as ValidationException;
                return false;
            }
        }
    }
}
