namespace StratixRuanBusinessLogic.Ruan.Serialization
{
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.DataContract(Name="OrderCost")]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class TransportationArrangedOrderCost
    {
        [System.Runtime.Serialization.DataMember]
        public string OrderId { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string CostTypeId { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string CostAmount { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string CostCurrency { get; set; }

        [System.Runtime.Serialization.DataMember]
        [System.Xml.Serialization.XmlArrayItemAttribute("TransportationArrangedOrderLineCost", IsNullable = false)]
        public TransportationArrangedOrderLineCost[] OrderLineCosts { get; set; }

    }
}