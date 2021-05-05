namespace StratixRuanBusinessLogic.Ruan.Serialization
{
    [System.Runtime.Serialization.DataContract]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class ShipUnitContent
    {
        [System.Runtime.Serialization.DataMember]
        public string DomainName { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ReleaseLineSequenceNumber { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string OrderNumber { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string LineItemNumber { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ItemNumber { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ItemName { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string ItemDescription { get; set; }
        
        [System.Runtime.Serialization.DataMember]
        public string ItemCommodityGroup { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string Quantity { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string QuantityUnitOfMeasure { get; set; }

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
        public string PackagedItem { get; set; }
        public bool ShouldSerializePackagedItem => !string.IsNullOrEmpty(PackagedItem);
    }
}