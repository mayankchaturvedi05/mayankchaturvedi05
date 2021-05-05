using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace StratixRuanBusinessLogic.Ruan.Serialization
{
    [Serializable()]
    [System.Runtime.Serialization.DataContract]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    [System.Xml.Serialization.XmlRoot(Namespace = "", IsNullable = false)]
    public class APITransportationShipment : IRuanStratixClass
    {
        #region Fields

        [System.Runtime.Serialization.DataMember]
        public string DomainName { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ContactName { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ContactEmail { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ContactPhone { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ShipmentNumber { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string TransactionType { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string CarrierScac { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string CarrierName { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ModeOfTransport { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string CurrencyCode { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string Equipment { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ShipmentBeginDate { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ShipmentEndDate { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string TotalCost { get; set; }

        [System.Runtime.Serialization.DataMember]
        [System.Xml.Serialization.XmlArrayItemAttribute("ReferenceNumber", IsNullable = false)]
        public ReferenceNumber[] References { get; set; }

        [System.Runtime.Serialization.DataMember]
        [System.Xml.Serialization.XmlArrayItemAttribute("TransportationArrangedStop", IsNullable = false)]
        public TransportationArrangedStop[] Stops { get; set; }

        [System.Runtime.Serialization.DataMember(Name = "ShipmentUnits")]
        [System.Xml.Serialization.XmlArrayItemAttribute("TransportationArrangedShipUnit", IsNullable = false)]
        public TaShipUnit[] ShipmentUnits { get; set; }

        [System.Runtime.Serialization.DataMember(Name="OrderCosts")]
        [System.Xml.Serialization.XmlArrayItemAttribute("TransportationArrangedOrderCost", IsNullable = false)]
        public TransportationArrangedOrderCost[] OrderCosts { get; set; }

        #endregion
    }
}

