namespace StratixRuanBusinessLogic
{
    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class IgnoreForTest : System.Attribute
    {
        public IgnoreForTest()
        {
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class IgnoreForSave : System.Attribute
    {
        public IgnoreForSave()
        {
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class ViewAttribute : System.Attribute
    {
        public int Index { get; set; }

        public ViewAttribute()
        {
        }
    }
}
