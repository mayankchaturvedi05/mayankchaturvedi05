namespace StratixRuanBusinessLogic.Ruan.Serialization
{
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.DataContract(Name ="OrderLineCost")]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class TransportationArrangedOrderLineCost
    {
        [System.Runtime.Serialization.DataMember]
        public string OrderId { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string OrderLineId { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string OrderLineItem { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string CostTypeId { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string CostAmount { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string CostCurrency { get; set; }

    }
}