namespace StratixRuanBusinessLogic.Ruan.Serialization
{
    [System.Runtime.Serialization.DataContract]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class CustomerServiceRepInfo
    {
        [System.Runtime.Serialization.DataMember]
        public string CustomerServiceRepName { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string CustomerServiceRepPhone { get; set; }
        public bool ShouldSerializeCustomerServiceRepPhone => !string.IsNullOrEmpty(CustomerServiceRepPhone);

        [System.Runtime.Serialization.DataMember]
        public string CustomerServiceRepEmail { get; set; }
    }
}