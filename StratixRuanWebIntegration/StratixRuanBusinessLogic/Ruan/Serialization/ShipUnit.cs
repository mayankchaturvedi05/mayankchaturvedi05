using System.Linq;

namespace StratixRuanBusinessLogic.Ruan.Serialization
{
    [System.Runtime.Serialization.DataContract]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class ShipUnit
    {
        [System.Runtime.Serialization.DataMember]
        public string ShipFromLocationDomainName { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ShipFromLocation { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ShipToLocationDomainName { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ShipToLocation { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string DomainName { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string TransactionCode { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ShipUnitNumber { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ShipUnitKey { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ShipUnitCount { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ShipUnitType { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string Weight { get; set; }
        public bool ShouldSerializeWeight()
        {
            return !string.IsNullOrEmpty(Weight);
        }

        [System.Runtime.Serialization.DataMember]
        public string WeightUnitOfMeasure { get; set; }
        public bool ShouldSerializeWeightUnitOfMeasure()
        {
            return !string.IsNullOrEmpty(WeightUnitOfMeasure);
        }

        [System.Runtime.Serialization.DataMember]
        public string Volume { get; set; }
        public bool ShouldSerializeVolume()
        {
            return !string.IsNullOrEmpty(Volume);
        }

        [System.Runtime.Serialization.DataMember]
        public string VolumeUnitOfMeasure { get; set; }
        public bool ShouldSerializeVolumeUnitOfMeasure()
        {
            return !string.IsNullOrEmpty(VolumeUnitOfMeasure);
        }

        [System.Runtime.Serialization.DataMember]
        public string WeightGross { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string WeightGrossUnitOfMeasure { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string VolumeGross { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string VolumeGrossUnitOfMeasure { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string IsSplitAllowed { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string IsCountSplittable { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string IsRepackAllowed { get; set; }

        [System.Runtime.Serialization.DataMember]
        [System.Xml.Serialization.XmlArrayItem("ShipUnitContent")]
        public System.Collections.Generic.List<ShipUnitContent> ShipUnitContents { get; set; } = new System.Collections.Generic.List<ShipUnitContent>();

        [System.Runtime.Serialization.DataMember]
        [System.Xml.Serialization.XmlArrayItem("ReferenceNumber")]
        public System.Collections.Generic.List<ReferenceNumber> ReferenceNumbers { get; set; }
        public bool ShouldSerializeReferenceNumbers => ReferenceNumbers.Any();

        [System.Runtime.Serialization.DataMember]
        public ShipUnitDimensions ShipUnitDimensions { get; set; }
    }
}