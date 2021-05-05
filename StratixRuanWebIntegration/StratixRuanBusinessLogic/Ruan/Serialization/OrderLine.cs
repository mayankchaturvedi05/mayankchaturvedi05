using System.Runtime.Serialization;

namespace StratixRuanBusinessLogic.Ruan.Serialization
{
    [System.SerializableAttribute(), DataContract]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class OrderLine
    {
        [DataMember]
        public string OrderLineId { get; set; }

        [DataMember]
        public string OrderLineItem { get; set; }

        [DataMember]
        public string OrderLineItemName { get; set; }

        [DataMember]
        public string PackagedItemCount { get; set; }

    }
}