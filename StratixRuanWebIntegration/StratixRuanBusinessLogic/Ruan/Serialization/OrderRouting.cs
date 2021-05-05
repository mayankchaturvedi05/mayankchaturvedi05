namespace StratixRuanBusinessLogic.Ruan.Serialization
{
    [System.Runtime.Serialization.DataContract]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class OrderRouting
    {
        [System.Runtime.Serialization.DataMember]
        public string ShipWithGroupId { get; set; }
        public bool ShouldSerializeShipWithGroupId => !string.IsNullOrEmpty(ShipWithGroupId);

        [System.Runtime.Serialization.DataMember]
        public string PreferredTransportationMode { get; set; }
        public bool ShouldSerializePreferredTransportationMode => !string.IsNullOrEmpty(PreferredTransportationMode);

        [System.Runtime.Serialization.DataMember]
        public string EquipmentGroup { get; set; }
        public bool ShouldSerializeEquipmentGroup => !string.IsNullOrEmpty(EquipmentGroup);
    }
}