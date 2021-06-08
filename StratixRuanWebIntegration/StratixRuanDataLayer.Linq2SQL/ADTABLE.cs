using System;
using System.Linq;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace StratixRuanDataLayer.Linq2SQL
{
    [Table()]
    public class ADTABLE : SharedAppsDataObject<ADTABLE>
    {
        [Column(DbType = "BIGINT IDENTITY (1, 1) NOT NULL", IsPrimaryKey = true, IsDbGenerated = true)]
        public long ADTBLNumber { get; set; }

        [Column(DbType = "VARCHAR(30) NOT NULL", UpdateCheck = UpdateCheck.Never)]
        public string ADTBLCode { get; set; }

        [Column(DbType = "VARCHAR(50)", CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public string ADTBLDesc { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public bool ADTBLAllowUDF { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public bool ADTBLAllowMmo { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public bool ADTBLUsesAudit { get; set; }

        [Column(DbType = "VARCHAR(1)", CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public string ADTBLDisplayType { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public int? ADTBLEcbWidth { get; set; }

        [Column(DbType = "VARCHAR(5)", CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public string ADTBLPrefix { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public DateTime? ADTBLCreatedOn { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public DateTime? ADTBLCreatedAt { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public long? ADTBLCreatedBy { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public long? ADTBLCreatedWS { get; set; }

        [Column(CanBeNull = true)]
        public DateTime? ADTBLLastChgOn { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public DateTime? ADTBLLastChgAt { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public long? ADTBLLastChgBy { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public long? ADTBLLastChgWS { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public DateTime? ADTBLPostedOn { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public DateTime? ADTBLPostedAt { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public long? ADTBLPostedBy { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public long? ADTBLPostedWS { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public DateTime? ADTBLDeletedOn { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public DateTime? ADTBLDeletedAt { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public long? ADTBLDeletedBy { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public long? ADTBLDeletedWS { get; set; }

        public override string GetFieldPrefix()
        {
            return "ADTBL";
        }

       

        public static List<object> GetTableFromName(string name)
        {
            using (SharedAppsDataContext db = new SharedAppsDataContext())
            {
                List<object> results = new List<object>();
                Type returnType = Type.GetType("SharedApps.DataLayer.Linq2SQL." + name);

                
                ITable dataTable = db.GetTable(Type.GetType("SharedApps.DataLayer.Linq2SQL." + name));

                IEnumerator resultEnumerator = dataTable.GetEnumerator();

                while (resultEnumerator.MoveNext())
                {
                    results.Add(resultEnumerator.Current);
                }
                

                return results;
            }
        }
    }
}
