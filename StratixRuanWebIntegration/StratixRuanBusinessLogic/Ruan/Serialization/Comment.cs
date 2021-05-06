namespace StratixRuanBusinessLogic.Ruan.Serialization
{
    [System.Runtime.Serialization.DataContract]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class Comment
    {
        [System.Runtime.Serialization.DataMember]
        public string CommentType { get; set; }

        [System.Runtime.Serialization.DataMember]
        public string CommentValue { get; set; }
    }
}