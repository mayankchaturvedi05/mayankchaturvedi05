namespace StratixRuanBusinessLogic.Ruan.Serialization
{
    [System.Runtime.Serialization.DataContract]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class AttributeCurrency
    {
        [System.Runtime.Serialization.DataMember]
        public FinancialAmount FinancialAmount { get; set; } = new FinancialAmount();
        public bool ShouldSerializeFinancialAmount()
        {
            return FinancialAmount.ShouldSerializeGlobalCurrencyCode();
        }
    }
}