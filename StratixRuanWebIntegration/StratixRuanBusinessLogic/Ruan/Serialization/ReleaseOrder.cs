namespace StratixRuanBusinessLogic.Ruan.Serialization
{
    [System.Runtime.Serialization.DataContract]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class ReleaseOrder
    {
        [System.Runtime.Serialization.DataMember]
        public OrderHeader OrderHeader { get; set; }

        [System.Runtime.Serialization.DataMember]
        public ShipFrom ShipFrom { get; set; }

        [System.Runtime.Serialization.DataMember]
        public ShipTo ShipTo { get; set; }

        [System.Runtime.Serialization.DataMember]
        public ShippingAndDeliveryDates ShippingAndDeliveryDates { get; set; }

        [System.Runtime.Serialization.DataMember]
        public OrderRouting OrderRouting { get; set; }
        public bool ShouldSerializeOrderRouting => OrderRouting.ShouldSerializeShipWithGroupId;

        [System.Runtime.Serialization.DataMember]
        [System.Xml.Serialization.XmlArrayItem("LineItem")]
        public System.Collections.Generic.List<LineItem> LineItems { get; set; }

        [System.Runtime.Serialization.DataMember]
        public ShipUnits ShipUnits { get; set; }
    }
}