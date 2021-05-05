using System.IO;
using System.Xml.Serialization;

namespace StratixRuanBusinessLogic
{
    public static class Utilities
    {
        public static string SerializeObjectToString(object obj)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, obj, ns);
                return writer.ToString();
            }
        }
    }
}
