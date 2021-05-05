namespace StratixRuanBusinessLogic.Ruan.Serialization
{
    [System.Runtime.Serialization.DataContract]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class FlexFieldNumbers
    {
        [System.Runtime.Serialization.DataMember]
        public string AttributeNumber1 { get; set; }
        public bool ShouldSerializeAttributeNumber1()
        {
            return !string.IsNullOrEmpty(AttributeNumber1);
        }

        [System.Runtime.Serialization.DataMember]
        public string AttributeNumber2 { get; set; }
        public bool ShouldSerializeAttributeNumber2 => !string.IsNullOrEmpty(AttributeNumber2);

        [System.Runtime.Serialization.DataMember]
        public string AttributeNumber3 { get; set; }
        public bool ShouldSerializeAttributeNumber3 => !string.IsNullOrEmpty(AttributeNumber3);

        [System.Runtime.Serialization.DataMember]
        public string AttributeNumber4 { get; set; }
        public bool ShouldSerializeAttributeNumber4 => !string.IsNullOrEmpty(AttributeNumber4);

        [System.Runtime.Serialization.DataMember]
        public string AttributeNumber5 { get; set; }
        public bool ShouldSerializeAttributeNumber5 => !string.IsNullOrEmpty(AttributeNumber5);

        [System.Runtime.Serialization.DataMember]
        public string AttributeNumber6 { get; set; }
        public bool ShouldSerializeAttributeNumber6 => !string.IsNullOrEmpty(AttributeNumber6);

        [System.Runtime.Serialization.DataMember]
        public string AttributeNumber7 { get; set; }
        public bool ShouldSerializeAttributeNumber7 => !string.IsNullOrEmpty(AttributeNumber7);

        [System.Runtime.Serialization.DataMember]
        public string AttributeNumber8 { get; set; }
        public bool ShouldSerializeAttributeNumber8 => !string.IsNullOrEmpty(AttributeNumber8);

        [System.Runtime.Serialization.DataMember]
        public string AttributeNumber9 { get; set; }
        public bool ShouldSerializeAttributeNumber9 => !string.IsNullOrEmpty(AttributeNumber9);

        [System.Runtime.Serialization.DataMember]
        public string AttributeNumber10 { get; set; }
        public bool ShouldSerializeAttributeNumber10 => !string.IsNullOrEmpty(AttributeNumber10);
    }
}