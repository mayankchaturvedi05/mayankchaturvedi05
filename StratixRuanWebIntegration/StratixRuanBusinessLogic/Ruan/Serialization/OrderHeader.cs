using System.Linq;

namespace StratixRuanBusinessLogic.Ruan.Serialization
{
    [System.Runtime.Serialization.DataContract]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class OrderHeader
    {
        [System.Runtime.Serialization.DataMember]
        public string DomainName { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string OrderNumber { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string TransactionCode { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string IntegrationCommand { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string Priority { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string StatusType { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string StatusValue { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string OrderShippingConfiguration { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string OrderType { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string PaymentMethod { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string TimeWindowEmphasis { get; set; }

        [System.Runtime.Serialization.DataMember]
        public CustomerServiceRepInfo CustomerServiceRepInfo { get; set; }

        [System.Runtime.Serialization.DataMember]
        [System.Xml.Serialization.XmlArrayItem("ReferenceNumber")]
        public System.Collections.Generic.List<ReferenceNumber> ReferenceNumbers { get; set; } = new System.Collections.Generic.List<ReferenceNumber>();
        public bool ShouldSerializeReferenceNumbers()
        {
            return ReferenceNumbers.Any();
        }

        [System.Runtime.Serialization.DataMember]
        [System.Xml.Serialization.XmlArrayItem("Comment")]
        public System.Collections.Generic.List<Comment> Comments { get; set; } = new System.Collections.Generic.List<Comment>();
        public bool ShouldSerializeComments()
        {
            return Comments.Any();
        }
    }
}