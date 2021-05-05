namespace StratixRuanBusinessLogic.Ruan.Serialization
{
    [System.Runtime.Serialization.DataContract]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class APIReleaseOrder
    {
        [System.Runtime.Serialization.DataMember]
        public string TransmissionType { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string SenderTransmissionNo { get; set; }

        [System.Runtime.Serialization.DataMember]
        [System.Xml.Serialization.XmlArrayItemAttribute("ReleaseOrder", IsNullable = false)]
        public System.Collections.Generic.List<ReleaseOrder> ReleaseOrders { get; set; }
    }
}