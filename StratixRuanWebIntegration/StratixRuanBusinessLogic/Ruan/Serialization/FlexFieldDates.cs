namespace StratixRuanBusinessLogic.Ruan.Serialization
{
    [System.Runtime.Serialization.DataContract]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class FlexFieldDates
    {
        [System.Runtime.Serialization.DataMember]
        public AttributeDate AttributeDate1 { get; set; } = new AttributeDate();
        public bool ShouldSerializeAttributeDate1 ()
        {
            return AttributeDate1.ShouldSerializeGLogDate();
        }

        [System.Runtime.Serialization.DataMember]
        public AttributeDate AttributeDate2 { get; set; }
        public bool ShouldSerializeAttributeDate2 => AttributeDate2.GLogDate.HasValue;

        [System.Runtime.Serialization.DataMember]
        public AttributeDate AttributeDate3 { get; set; }
        public bool ShouldSerializeAttributeDate3 => AttributeDate3.GLogDate.HasValue;

        [System.Runtime.Serialization.DataMember]
        public AttributeDate AttributeDate4 { get; set; }
        public bool ShouldSerializeAttributeDate4 => AttributeDate4.GLogDate.HasValue;

        [System.Runtime.Serialization.DataMember]
        public AttributeDate AttributeDate5 { get; set; }
        public bool ShouldSerializeAttributeDate5 => AttributeDate5.GLogDate.HasValue;

        [System.Runtime.Serialization.DataMember]
        public AttributeDate AttributeDate6 { get; set; }
        public bool ShouldSerializeAttributeDate6 => AttributeDate6.GLogDate.HasValue;

        [System.Runtime.Serialization.DataMember]
        public AttributeDate AttributeDate7 { get; set; }
        public bool ShouldSerializeAttributeDate7 => AttributeDate7.GLogDate.HasValue;

        [System.Runtime.Serialization.DataMember]
        public AttributeDate AttributeDate8 { get; set; }
        public bool ShouldSerializeAttributeDate8 => AttributeDate8.GLogDate.HasValue;

        [System.Runtime.Serialization.DataMember]
        public AttributeDate AttributeDate9 { get; set; }
        public bool ShouldSerializeAttributeDate9 => AttributeDate9.GLogDate.HasValue;

        [System.Runtime.Serialization.DataMember]
        public AttributeDate AttributeDate10 { get; set; }
        public bool ShouldSerializeAttributeDate10 => AttributeDate10.GLogDate.HasValue;
    }
}