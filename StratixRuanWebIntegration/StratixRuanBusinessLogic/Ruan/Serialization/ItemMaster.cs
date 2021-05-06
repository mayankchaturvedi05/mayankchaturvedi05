using System.Linq;

namespace StratixRuanBusinessLogic.Ruan.Serialization
{
    [System.Runtime.Serialization.DataContract]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class ItemMaster
    {
        [System.Runtime.Serialization.DataMember]
        [System.Xml.Serialization.XmlArrayItem("ReferenceNumber")]
        public System.Collections.Generic.List<ReferenceNumber> ReferenceNumbers { get; set; }
        public bool ShouldSerializeReferenceNumbers => ReferenceNumbers.Any();
    }
}