using System.ComponentModel;
using System.Linq;
using StratixRuanInterfaces;

namespace StratixRuanBusinessLogic
{
    public class SimpleBusinessLogicList<BusinessLogicType> : BindingList<BusinessLogicType>
    where BusinessLogicType : IBusinessLogicBase
    {
        public bool Contains(long number)
        {
            BusinessLogicType result = (from s in this where s.Number == number select s).SingleOrDefault();
            return result != null;
        }
        public int IndexOf(long number)
        {
            int index = -1;
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].Number == number)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
    }

}