using System.Collections.Generic;

namespace StratixRuanInterfaces
{
    public interface IBulkSavable : IListSaveable
    {
        string SecondaryUniqueId();

        List<object> FetchAllBySecondaryUniqueId(List<object> ids);
    }
}
