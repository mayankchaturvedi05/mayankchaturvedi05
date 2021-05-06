// ReSharper disable InconsistentNaming
namespace StratixRuanBusinessLogic.Ruan.Serialization
{
    [System.Runtime.Serialization.DataContract]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class AttributeDate
    {
        [System.Runtime.Serialization.DataMember]
        public System.DateTime? GLogDate { get; set; } = null;
        public bool ShouldSerializeGLogDate()
        {
            return GLogDate.HasValue;
        }

        [System.Runtime.Serialization.DataMember]
        public string TZId { get; set; } = "EST";

        [System.Runtime.Serialization.DataMember]
        public string TZOffset { get; set; } = "5";
    }
}