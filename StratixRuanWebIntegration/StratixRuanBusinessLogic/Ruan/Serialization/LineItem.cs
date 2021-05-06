using System.Linq;

namespace StratixRuanBusinessLogic.Ruan.Serialization
{
    [System.Runtime.Serialization.DataContract]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class LineItem
    {
        [System.Runtime.Serialization.DataMember]
        public string AutoCreateItem { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string AutoCreateItemMaster { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string LineItemNumber { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string TransportUnitKey { get; set; }

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
        public LineItemDimensions LineItemDimensions { get; set; }
        public bool ShouldSerializeLineItemDimensions => LineItemDimensions.ShouldSerializeWidth;

        [System.Runtime.Serialization.DataMember]
        public ItemMaster ItemMaster { get; set; }
        public bool ShouldSerializeItemMaster => ItemMaster.ReferenceNumbers.Any();
    }
}