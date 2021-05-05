using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratixRuanBusinessLogic.Ruan.Serialization
{
    [System.Runtime.Serialization.DataContract]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class ShipUnitDimensions
    {
        [System.Runtime.Serialization.DataMember]
        public string Length { get; set; }
        public bool ShouldSerializeLength => !string.IsNullOrEmpty(Length);

        [System.Runtime.Serialization.DataMember]
        public string LengthUnitOfMeasure { get; set; }
        public bool ShouldSerializeLengthUnitOfMeasure => !string.IsNullOrEmpty(LengthUnitOfMeasure);

        [System.Runtime.Serialization.DataMember]
        public string Width { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string WidthUnitOfMeasure { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string Height { get; set; }
        public bool ShouldSerializeHeight => !string.IsNullOrEmpty(Height);

        [System.Runtime.Serialization.DataMember]
        public string HeightUnitOfMeasure { get; set; }
        public bool ShouldSerializeHeightUnitOfMeasure => !string.IsNullOrEmpty(HeightUnitOfMeasure);
    }
}
