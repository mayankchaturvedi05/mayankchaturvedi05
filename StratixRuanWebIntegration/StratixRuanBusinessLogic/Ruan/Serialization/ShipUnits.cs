namespace StratixRuanBusinessLogic.Ruan.Serialization
{
    [System.Runtime.Serialization.DataContract]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class ShipUnits
    {
        [System.Runtime.Serialization.DataMember]
        [System.Xml.Serialization.XmlElementAttribute("ShipUnit")]
        public System.Collections.Generic.List<ShipUnit> ShipUnitList { get; set; } = new System.Collections.Generic.List<ShipUnit>();
        //public ShipUnit ShipUnit { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string TotalWeight { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string TotalWeightGross { get; set; }
    }
}
