using System.Linq;
using System.Data.Linq.Mapping;

namespace StratixRuanDataLayer.Linq2SQL
{
    [Table()]
    public class MSCColumnToFieldMappings : SharedAppsDataObject<MSCColumnToFieldMappings>
    {
        [Column(UpdateCheck = UpdateCheck.Never)]
        public string TableName { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public int Position { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public string ColumnName { get; set; }

        [Column(DbType = "VARCHAR(-1)", CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public string FieldName { get; set; }

        [Column(CanBeNull=true , UpdateCheck = UpdateCheck.Never)]
        public string Type { get; set; }

        [Column(DbType="VARCHAR(3)", CanBeNull=true , UpdateCheck = UpdateCheck.Never)]
        public string Nullable { get; set; }

        public static MSCColumnToFieldMappings[] FetchAllByTableName(string TableName)
        {
              MSCColumnToFieldMappings[] results = null;

              using (SharedAppsDataContext db = new SharedAppsDataContext())
              {
                 string sql = @"SELECT *
                                 FROM MSCColumnToFieldMappings 
                                WHERE TableName = {0}
                                ORDER BY Position";

                  results = db.ExecuteQuery<MSCColumnToFieldMappings>(sql, TableName).ToArray();
              }

              return results;
         }
    }
}
