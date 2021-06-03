namespace StratixRuanBusinessLogic
{
    public class FieldOutOfRangeException : ValidationException
    {
        public double Min { get; set; }
        public double Max { get; set; }

        public FieldOutOfRangeException(string message, string fieldName, string objectName, double min, double max)
            : base(message, fieldName, objectName)
        {
            Min = min;
            Max = max;
        }
    }
}
