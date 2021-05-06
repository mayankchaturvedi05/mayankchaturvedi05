namespace StratixRuanBusinessLogic.Ruan.Serialization
{
    [System.Runtime.Serialization.DataContract]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class FinancialAmount
    {
        [System.Runtime.Serialization.DataMember]
        public string GlobalCurrencyCode { get; set; }
        public bool ShouldSerializeGlobalCurrencyCode()
        {
            return !string.IsNullOrEmpty(GlobalCurrencyCode);
        }

        [System.Runtime.Serialization.DataMember]
        public string MonetaryAmount { get; set; }
        public bool ShouldSerializeMonetaryAmount => !string.IsNullOrEmpty(MonetaryAmount);

        [System.Runtime.Serialization.DataMember]
        public string RateToBase { get; set; }
        public bool ShouldSerializeRateToBase => !string.IsNullOrEmpty(RateToBase);

        [System.Runtime.Serialization.DataMember]
        public string FuncCurrencyAmount { get; set; }
        public bool ShouldSerializeFuncCurrencyAmount => !string.IsNullOrEmpty(FuncCurrencyAmount);
    }
}