using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;


namespace StratixRuanBusinessLogic.Ruan.Serialization
{
    [Serializable()]
    [DataContract]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    [System.Xml.Serialization.XmlRoot(Namespace = "", IsNullable = false)]
    public class APIOrderStatus : IRuanStratixClass
    {
        #region Fields

        [DataMember]
        public string DomainName { get; set; }

        [DataMember]
        public string ContactName { get; set; }

        [DataMember]
        public string ContactEmail { get; set; }

        [DataMember]
        public string ContactPhone { get; set; }

        [DataMember]
        public string Action { get; set; }

        [DataMember]
        public string OrderNumber { get; set; }

        [DataMember]
        public string ShipmentNumber { get; set; }

        [DataMember]
        public string EquipmentType { get; set; }

        [DataMember]
        public string TransactionType { get; set; }

        [DataMember]
        public string StatusDate { get; set; }

        [DataMember]
        public Serialization.Location Location { get; set; }

        [DataMember]
        [System.Xml.Serialization.XmlArrayItemAttribute("ReferenceNumber", IsNullable = false)]
        public ReferenceNumber[] References { get; set; }

        #endregion

        public void UpdateDelivered()
        {
           //TODO : Fill with Stratix specific logic
        }
    }
}
