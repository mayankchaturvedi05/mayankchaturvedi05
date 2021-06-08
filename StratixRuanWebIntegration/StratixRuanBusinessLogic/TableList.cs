using System.Collections.Generic;
using StratixRuanDataLayer.Linq2SQL;

namespace StratixRuanBusinessLogic
{
    public class TableList : BusinessLogicList<Table, ADTABLE>
    {
        public Table TableByNumber(long? number)
        {
            if (number.HasValue)
            {
                foreach (Table tab in this)
                {
                    if (tab.TableNumber == number)
                    {
                        return tab;
                    }
                }
            }

            return null;
        }
        
        public TableList TablesByCodeAndDescription(string code, bool includeDeleted = false)
        {
            TableList tables = new TableList();

            foreach (Table tab in this)
            {
                if (!includeDeleted && tab.IsDeleted)
                {
                    continue;
                }

                if (tab.Code.ToLowerInvariant().Contains(code.ToLowerInvariant()) || tab.Description.ToLowerInvariant().Contains(code.ToLowerInvariant()))
                {
                    tables.Add(tab);
                }
            }

            return tables;
        }
        
        public Table TableByCode(string code)
        {
            foreach (Table tab in this)
            {
                if (tab.Code == code)
                {
                    return tab;
                }
            }
            return null;
        }

        public TableList TablesLikeCode(string code, int numberOfRecords)
        {
            if(code == null)
            {
                code = "";
            }

            TableList tables = new TableList();
            int count = 0;
            foreach (Table tab in this)
            {
                if (numberOfRecords < count)
                    break;

                if (tab.Code.ToLowerInvariant().Contains(code.ToLowerInvariant()))
                {
                    tables.Add(tab);
                    count++;
                }
            }
            return tables;
        }
    }
}
