using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using StratixRuanInterfaces;


namespace StratixRuanDataLayer.Linq2SQL
{
    [Table()]
    public class TSRuanXMLQueue : SharedAppsDataObject<TSRuanXMLQueue>
    {
        [Column(DbType = "BIGINT IDENTITY (1, 1) NOT NULL", IsPrimaryKey = true, IsDbGenerated = true)]
        public long TSRNQNumber { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public long TSRNXNumber { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public long SMQFNumber { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public long? STRINTNumber { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public DateTime? TSRNQCreatedOn { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public DateTime? TSRNQCreatedAt { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public long? TSRNQCreatedBy { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public long? TSRNQCreatedWS { get; set; }

        [Column(CanBeNull = true)]
        public DateTime? TSRNQLastChgOn { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public DateTime? TSRNQLastChgAt { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public long? TSRNQLastChgBy { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public long? TSRNQLastChgWS { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public DateTime? TSRNQDeletedOn { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public DateTime? TSRNQDeletedAt { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public long? TSRNQDeletedBy { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public long? TSRNQDeletedWS { get; set; }

        public override string GetFieldPrefix()
        {
            return "TSRNQ";
        }

        public static TSRuanXMLQueue[] FetchAllByQueueFlagNumber(long queueFlagNumber)
        {
            TSRuanXMLQueue[] results = null;

            using (SharedAppsDataContext db = new SharedAppsDataContext())
            {
                string sql = @"
                    SELECT *
                      FROM TSRuanXMLQueue
                     WHERE SMQFNumber = {1}
";

                results = db.ExecuteQuery<TSRuanXMLQueue>(sql, queueFlagNumber).ToArray();
            }

            return results;
        }
    }
}
