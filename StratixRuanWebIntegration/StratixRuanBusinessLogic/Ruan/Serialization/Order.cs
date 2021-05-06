using System.Runtime.Serialization;

namespace StratixRuanBusinessLogic.Ruan.Serialization
{
    [System.SerializableAttribute(), DataContract]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class Order
    {
        [DataMember]
        public string OrderId { get; set; }

        [DataMember]
        public string OrderType { get; set; }

        [DataMember]
        [System.Xml.Serialization.XmlArrayItemAttribute("TransportationArrangedOrderLine", IsNullable = false)]
        public OrderLine[] OrderLines { get; set; }

        [DataMember]
        [System.Xml.Serialization.XmlArrayItemAttribute("ReferenceNumber")]
        public ReferenceNumber[] References { get; set; } = new ReferenceNumber[]{};
    }
}