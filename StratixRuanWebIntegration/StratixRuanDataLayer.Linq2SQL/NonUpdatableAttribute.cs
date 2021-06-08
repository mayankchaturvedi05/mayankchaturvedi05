using System;

namespace StratixRuanDataLayer.Linq2SQL
{
    [AttributeUsage(AttributeTargets.Property)]
    public class NonUpdatableAttribute : Attribute
    {
    }
}
