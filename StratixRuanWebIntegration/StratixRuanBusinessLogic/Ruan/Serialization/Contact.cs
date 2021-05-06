namespace StratixRuanBusinessLogic.Ruan.Serialization
{
    [System.Runtime.Serialization.DataContract]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class Contact
    {
        [System.Runtime.Serialization.DataMember]
        public string DomainName { get; set; }
        public bool ShouldSerializeDomainName => !string.IsNullOrEmpty(DomainName);

        [System.Runtime.Serialization.DataMember]
        public string Name { get; set; }
        public bool ShouldSerializeName => !string.IsNullOrEmpty(Name);

        [System.Runtime.Serialization.DataMember]
        public string Phone { get; set; }
        public bool ShouldSerializePhone => !string.IsNullOrEmpty(Phone);

        [System.Runtime.Serialization.DataMember]
        public string Email { get; set; }
        public bool ShouldSerializeEmail => !string.IsNullOrEmpty(Email);
    }
}
