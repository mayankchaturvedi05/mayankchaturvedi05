using System.Runtime.Serialization;

namespace StratixRuanBusinessLogic.Ruan.Serialization
{
    [System.SerializableAttribute(), DataContract]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class Location
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string AddressLine1 { get; set; }

        [DataMember]
        public string AddressLine2 { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string State { get; set; }

        [DataMember]
        public string Zip { get; set; }

        [DataMember]
        public string Country { get; set; }

        [DataMember]
        public string Latitude { get; set; }

        [DataMember]
        public string Longitude { get; set; }
    }
}