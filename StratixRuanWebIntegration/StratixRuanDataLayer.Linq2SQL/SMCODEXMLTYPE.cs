using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace StratixRuanDataLayer.Linq2SQL
{
    [Table()]
    public class SMCODEXMLTYPE : SharedAppsDataObject<SMCODEXMLTYPE>
    {
        [Column(DbType = "BIGINT IDENTITY (1, 1) NOT NULL", IsPrimaryKey = true, IsDbGenerated = true)]
        public long SMXMLNumber { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never )]
        public string SMXMLCode { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never )]
        public string SMXMLDescription { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public string SMXMLHeaderSpecVersion { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public DateTime? SMXMLCreatedOn { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public DateTime? SMXMLCreatedAt { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public long? SMXMLCreatedBy { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public long? SMXMLCreatedWS { get; set; }

        [Column(CanBeNull = true)]
        public DateTime? SMXMLLastChgOn { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public DateTime? SMXMLLastChgAt { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public long? SMXMLLastChgBy { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public long? SMXMLLastChgWS { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public DateTime? SMXMLPostedOn { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public DateTime? SMXMLPostedAt { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public long? SMXMLPostedBy { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public long? SMXMLPostedWS { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public DateTime? SMXMLDeletedOn { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public DateTime? SMXMLDeletedAt { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public long? SMXMLDeletedBy { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public long? SMXMLDeletedWS { get; set; }
    }
}
