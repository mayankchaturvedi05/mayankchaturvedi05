namespace StratixRuanBusinessLogic.Ruan.Serialization
{
    [System.Runtime.Serialization.DataContract]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class ReferenceNumber
    {
        [System.Runtime.Serialization.DataMember]
        public string DomainName { get; set; }
        public bool ShouldSerializeDomainName => !string.IsNullOrEmpty(DomainName);

        [System.Runtime.Serialization.DataMember]
        public string ReferenceNumberType { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ReferenceNumberValue { get; set; }
    }
}