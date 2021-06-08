using System;

namespace StratixRuanDataLayer.Linq2SQL
{
    public class ItemChangedException<DerivedType> : Exception where DerivedType : SharedAppsDataObject<DerivedType>, new() 
    {
        public ItemChangedException(string message, DerivedType original)
            : base(message)
        {
            Original = original;
        }

        public ItemChangedException(DerivedType original)
        {
            Original = original;
        }

        public DerivedType Original { get; set; }
    }
}
