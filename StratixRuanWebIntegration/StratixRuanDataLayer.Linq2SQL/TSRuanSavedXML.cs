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
    public class TSRuanSavedXML : SharedAppsDataObject<TSRuanSavedXML>
    {
        [Column(DbType = "BIGINT IDENTITY (1, 1) NOT NULL", IsPrimaryKey = true, IsDbGenerated = true)]
        public long TSRUXNumber { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public long SMXMLNumber { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public long? TSLACNumber { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public long? TSMFHNumber { get; set; }

        [Column(DbType = "XML", UpdateCheck = UpdateCheck.Never)]
        public string TSRUXXML { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public DateTime? TSRUXCreatedOn { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public DateTime? TSRUXCreatedAt { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public long? TSRUXCreatedBy { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public long? TSRUXCreatedWS { get; set; }

        [Column(CanBeNull = true)]
        public DateTime? TSRUXLastChgOn { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public DateTime? TSRUXLastChgAt { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public long? TSRUXLastChgBy { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public long? TSRUXLastChgWS { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public DateTime? TSRUXDeletedOn { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public DateTime? TSRUXDeletedAt { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public long? TSRUXDeletedBy { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public long? TSRUXDeletedWS { get; set; }

        public override string GetFieldPrefix()
        {
            return "TSRUX";
        }

        

    }
}
