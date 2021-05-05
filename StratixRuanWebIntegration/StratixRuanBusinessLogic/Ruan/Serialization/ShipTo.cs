// ReSharper disable InconsistentNaming
namespace StratixRuanBusinessLogic.Ruan.Serialization
{
    [System.Runtime.Serialization.DataContract]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class ShipTo
    {
        [System.Runtime.Serialization.DataMember]
        public string DomainName { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string Id { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string Name { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string AddressLine1 { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string AddressLine2 { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string City { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string State { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string Zip { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string Country { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string Role { get; set; }

        [System.Runtime.Serialization.DataMember]
        public Contact Contact { get; set; }
        public bool ShouldSerializeContact => Contact.ShouldSerializeName;

        [System.Runtime.Serialization.DataMember]
        public string PostLocationToOTM { get; set; } = "true";
        public bool ShouldSerializePostLocationToOTM => !string.IsNullOrEmpty(PostLocationToOTM);
    }
}