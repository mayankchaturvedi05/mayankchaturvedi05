using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StratixRuanDataLayer.Linq2SQL
{
    public class DataItem<DataLayerType> where DataLayerType : SharedAppsDataObject<DataLayerType>, new()
    {
        public DataLayerType Original { get; set; }
        public DataLayerType Current { get; }
        public DataLayerType Result { get; set; }

        public DataItem(DataLayerType original, DataLayerType current)
        {
            Original = original;
            Current = current;
            Result = null;
        }
    }

    public class DataItemList<DataLayerType> : List<DataItem<DataLayerType>>
        where DataLayerType : SharedAppsDataObject<DataLayerType>, new()
    {
        public DataItemList<DataLayerType> Save()
        {
            return SharedAppsDataObject<DataLayerType>.BulkSave(this);
        }
    }
}
