namespace StratixRuanBusinessLogic.Ruan.Serialization
{
    [System.Runtime.Serialization.DataContract]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class ActualShipment
    {
        [System.Runtime.Serialization.DataMember]
        public ShipmentHeader ShipmentHeader { get; set; }

        [System.Runtime.Serialization.DataMember]
        [System.Xml.Serialization.XmlArrayItemAttribute("ReleaseOrder", IsNullable = false)]
        public System.Collections.Generic.List<ReleaseOrder> ReleaseOrders { get; set; }
    }
}