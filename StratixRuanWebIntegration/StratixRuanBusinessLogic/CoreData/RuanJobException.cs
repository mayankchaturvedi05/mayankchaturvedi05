using System;

namespace StratixRuanBusinessLogic.CoreData
{
    public class RuanJobException : InvalidOperationException
    {
        public RuanJobException(string message) : base(message)
        {
        }
        public RuanJobException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}