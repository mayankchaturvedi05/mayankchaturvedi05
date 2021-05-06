namespace StratixRuanBusinessLogic.Ruan.Serialization
{
    [System.Runtime.Serialization.DataContract]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class OrderShipUnits
    {
        [System.Runtime.Serialization.DataMember]
        public ShipUnit ShipUnit { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string TotalWeight { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string TotalWeightGross { get; set; }
    }
}