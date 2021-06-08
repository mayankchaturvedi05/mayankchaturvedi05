using System.Collections;
using System.Collections.Generic;
using System.Linq;
using StratixRuanDataLayer.Linq2SQL;

namespace StratixRuanBusinessLogic
{
    public static class BusinessLogicExtensions
    {
        public static BusinessLogicList<BusinessLogicType, DataLayerType> ToBusinessLogicList<BusinessLogicType, DataLayerType>(this IEnumerable list)
            where BusinessLogicType : BusinessLogicBase<BusinessLogicType, DataLayerType>, new()
            where DataLayerType : SharedAppsDataObject<DataLayerType>, new()
        {
            BusinessLogicList<BusinessLogicType, DataLayerType> genList = new BusinessLogicList<BusinessLogicType, DataLayerType>();

            foreach (BusinessLogicType item in list)
            {
                genList.Add(item);
            }

            return genList;
        }
    }
}
