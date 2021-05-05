namespace StratixRuanBusinessLogic.Ruan.Serialization
{ 
    [System.Runtime.Serialization.DataContract]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class APIActualShipment
    {
        [System.Runtime.Serialization.DataMember]
        public string TransmissionType { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string SenderTransmissionNo { get; set; }

        [System.Runtime.Serialization.DataMember]
        [System.Xml.Serialization.XmlArrayItem("ActualShipment")]
        public System.Collections.Generic.List<ActualShipment> ActualShipments { get; set; } = new System.Collections.Generic.List<ActualShipment>();
    }
}
