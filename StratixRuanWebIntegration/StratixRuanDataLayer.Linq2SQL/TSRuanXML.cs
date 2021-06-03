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
    public class TSRuanXML : SharedAppsDataObject<TSRuanXML>
    {
        [Column(DbType = "BIGINT IDENTITY (1, 1) NOT NULL", IsPrimaryKey = true, IsDbGenerated = true)]
        public long TSRNXNumber { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public long SMXMLNumber { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public string TSRNXXML { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public DateTime? TSRNXCreatedOn { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public DateTime? TSRNXCreatedAt { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public long? TSRNXCreatedBy { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public long? TSRNXCreatedWS { get; set; }

        [Column(CanBeNull = true)]
        public DateTime? TSRNXLastChgOn { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public DateTime? TSRNXLastChgAt { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public long? TSRNXLastChgBy { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public long? TSRNXLastChgWS { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public DateTime? TSRNXDeletedOn { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public DateTime? TSRNXDeletedAt { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public long? TSRNXDeletedBy { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public long? TSRNXDeletedWS { get; set; }

        public override string GetFieldPrefix()
        {
            return "TSRNX";
        }
    }
}
