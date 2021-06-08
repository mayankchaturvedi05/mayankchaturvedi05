using System.Linq;
using l2s = StratixRuanDataLayer.Linq2SQL;

namespace StratixRuanBusinessLogic
{
    public class MSCColumnToFieldMappingsList : BusinessLogicList<MSCColumnToFieldMappings, l2s.MSCColumnToFieldMappings>
    {
        public string GetFieldNameForColumn(string columnName)
        {
            string fieldName = null;

            MSCColumnToFieldMappings thing = this.Where(i => i.ColumnName == columnName).FirstOrDefault();
            if(thing != null)
            {
                fieldName = thing.FieldName;
            }

            return fieldName;
        }

        public string GetColumnNameForField(string fieldName)
        {
            string columnName = null;

            MSCColumnToFieldMappings thing = this.Where(i => i.FieldName == fieldName).FirstOrDefault();
            if(thing == null)
            {
                if (fieldName.EndsWith("UMNumber"))
                {
                    string newFieldName = fieldName.Replace("UMNumber", "UM");
                    thing = this.Where(i => i.FieldName == newFieldName).FirstOrDefault();
                }
            }

            if(thing != null)
            {
                columnName = thing.ColumnName;
            }

            return columnName;
        }
    }
}