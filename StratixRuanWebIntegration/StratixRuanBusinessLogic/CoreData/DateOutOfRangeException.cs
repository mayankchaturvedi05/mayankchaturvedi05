using System;

namespace StratixRuanBusinessLogic
{
    public class DateOutOfRangeException : ValidationException
    {
        public DateTime Min { get; set; }
        public DateTime Max { get; set; }

        public DateOutOfRangeException(string message, string fieldName, string objectName, DateTime min, DateTime max)
            : base(message, fieldName, objectName)
        {
            Min = min;
            Max = max;
        }
    }
}
