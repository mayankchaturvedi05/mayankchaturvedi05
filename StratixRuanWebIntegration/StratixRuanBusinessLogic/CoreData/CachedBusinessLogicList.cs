using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StratixRuanDataLayer.Linq2SQL;

namespace StratixRuanBusinessLogic.CoreData
{
    public class CachedBusinessLogicList<BusinessLogicType, DataLayerType> : BusinessLogicList<BusinessLogicType, DataLayerType>
        where BusinessLogicType : BusinessLogicBase<BusinessLogicType, DataLayerType>, new()
        where DataLayerType : SharedAppsDataObject<DataLayerType>, new()
    {
        public BusinessLogicType ItemByNumber(long? number)
        {
            BusinessLogicType requestedItem = null;

            if (number.HasValue)
            {
                foreach (BusinessLogicType item in this)
                {
                    if (item.Number == number)
                    {
                        requestedItem = item;
                        break;
                    }
                }

                if(requestedItem == null)
                {
                    if(CachedBusinessLogicListState.ThrowExceptionOnCacheFailure)
                    {
                        throw new ApplicationException("CachedBusinessLogicList cache hit failure");
                    }
                    else
                    {
                        requestedItem = BusinessLogicBase<BusinessLogicType, DataLayerType>.FetchByNumber(number);
                        if(requestedItem != null)
                        {
                            this.Add(requestedItem);
                        }
                    }
                }
            }

            return requestedItem;
        }

        public BusinessLogicType this[long? number]
        {
            get
            {
                return ItemByNumber(number);
            }
        }

        public BusinessLogicType ItemByCode(string code)
        {
            BusinessLogicType requestedItem = null;

            foreach (BusinessLogicType item in this)
            {
                if (item.Code == code)
                {
                    requestedItem = item;
                    break;
                }
            }

            if (requestedItem == null)
            {
                if(CachedBusinessLogicListState.ThrowExceptionOnCacheFailure)
                {
                    throw new ApplicationException("CachedBusinessLogicList cache hit failure");
                }
                else
                {
                    requestedItem = BusinessLogicBase<BusinessLogicType, DataLayerType>.FetchByCode(code);
                    if(requestedItem != null)
                    {
                        this.Add(requestedItem);
                    }
                }
            }

            return requestedItem;
        }

        public new BusinessLogicType this[string code]
        {
            get
            {
                return ItemByCode(code);
            }
        }
    }

    public class CachedBusinessLogicListState
    {
        // This property is purely for allowing us to set up some tests on this list
        public static bool ThrowExceptionOnCacheFailure { get; set; } = false;
    }
}
