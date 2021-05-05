namespace StratixRuanBusinessLogic.Ruan.Serialization
{
    [System.Runtime.Serialization.DataContract(Name = "ShipUnit")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class TaShipUnit
    {
        [System.Runtime.Serialization.DataMember]
        public string ShipUnitId { get; set; }

        [System.Runtime.Serialization.DataMember]
        public object ShipUnitNMFC { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ShipUnitCount { get; set; }

        [System.Runtime.Serialization.DataMember(Name = "Contents")]
        [System.Xml.Serialization.XmlArrayItemAttribute("TransportationArrangedShipUnitContent", IsNullable = false)]
        public TaShipUnitContent[] Contents { get; set; }

    }
}