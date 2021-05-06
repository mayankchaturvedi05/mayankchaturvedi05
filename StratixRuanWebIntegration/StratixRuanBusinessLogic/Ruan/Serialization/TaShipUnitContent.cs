using System.Runtime.Serialization;

namespace StratixRuanBusinessLogic.Ruan.Serialization
{
    [System.SerializableAttribute(), DataContract(Name = "ShipUnitContent")]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class TaShipUnitContent
    {
        [DataMember]
        public string OrderId { get; set; }

        [DataMember]
        public string OrderLineId { get; set; }

        [DataMember]
        public string Item { get; set; }

        [DataMember]
        public string ItemName { get; set; }

        [DataMember]
        public string Weight { get; set; }

        [DataMember]
        public string WeightUnitOfMeasure { get; set; }

        [DataMember]
        public string Volume { get; set; }

        [DataMember]
        public string VolumeUnitOfMeasure { get; set; }

        [DataMember]
        public string PackagedItemCount { get; set; }

    }
}