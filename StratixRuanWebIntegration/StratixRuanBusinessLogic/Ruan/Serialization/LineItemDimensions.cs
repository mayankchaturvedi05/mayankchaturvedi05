// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming
namespace StratixRuanBusinessLogic.Ruan.Serialization
{
    [System.Runtime.Serialization.DataContract]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class LineItemDimensions
    {
        [System.Runtime.Serialization.DataMember]
        public string Length { get; set; }
        public bool ShouldSerializeLength => !string.IsNullOrEmpty(Length);

        [System.Runtime.Serialization.DataMember]
        public string Width { get; set; }
        public bool ShouldSerializeWidth => !string.IsNullOrEmpty(Width);

        [System.Runtime.Serialization.DataMember]
        public string Height { get; set; }
        public bool ShouldSerializeHeight => !string.IsNullOrEmpty(Height);

        [System.Runtime.Serialization.DataMember]
        public string UnitOfMeasure { get; set; }
        public bool ShouldSerializeUnitOfMeasure => !string.IsNullOrEmpty(UnitOfMeasure);
        
        [System.Runtime.Serialization.DataMember]
        public string Weight { get; set; }
        public bool ShouldSerializeWeight => !string.IsNullOrEmpty(Weight);

        [System.Runtime.Serialization.DataMember]
        public string WeightUnitOfMeasure { get; set; }
        public bool ShouldSerializeWeightUnitOfMeasure => !string.IsNullOrEmpty(WeightUnitOfMeasure);

        [System.Runtime.Serialization.DataMember]
        public string Volume { get; set; }
        public bool ShouldSerializeVolume => !string.IsNullOrEmpty(Volume);

        [System.Runtime.Serialization.DataMember]
        public string VolumeUnitOfMeasure { get; set; }
        public bool ShouldSerializeVolumeUnitOfMeasure => !string.IsNullOrEmpty(VolumeUnitOfMeasure);

        [System.Runtime.Serialization.DataMember]
        public string NMFCCode { get; set; }
        public bool ShouldSerializeNMFCCode => !string.IsNullOrEmpty(NMFCCode);

        [System.Runtime.Serialization.DataMember]
        public string UserDefinedCommodity { get; set; }
        public bool ShouldSerializeUserDefinedCommodity()
        {
            return !string.IsNullOrEmpty(UserDefinedCommodity);
        }
    }
}