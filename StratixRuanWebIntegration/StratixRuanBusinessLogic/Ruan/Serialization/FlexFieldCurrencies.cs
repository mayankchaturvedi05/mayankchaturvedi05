namespace StratixRuanBusinessLogic.Ruan.Serialization
{
    [System.Runtime.Serialization.DataContract]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class FlexFieldCurrencies
    {
        [System.Runtime.Serialization.DataMember]
        public AttributeCurrency AttributeCurrency1 { get; set; } = new AttributeCurrency();
        public bool ShouldSerializeAttributeCurrency1()
        {
            return AttributeCurrency1.ShouldSerializeFinancialAmount();
        }

        [System.Runtime.Serialization.DataMember]
        public AttributeCurrency AttributeCurrency2 { get; set; }
        public bool ShouldSerializeAttributeCurrency2()
        {
            return AttributeCurrency2.ShouldSerializeFinancialAmount();
        }

        [System.Runtime.Serialization.DataMember]
        public AttributeCurrency AttributeCurrency3 { get; set; }
        public bool ShouldSerializeAttributeCurrency3()
        {
            return AttributeCurrency3.ShouldSerializeFinancialAmount();
        }
    }
}