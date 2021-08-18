using System.IO;
using System.Text;
using System.Xml;
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

        public static string SerializeObjectToStringUtf8(object obj)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            using (StringWriter writer = new Utf8StringWriter())
            {
                serializer.Serialize(writer, obj, ns);
                return writer.ToString();
            }
        }

        //no encoding declaration
        public static string SerializeObjectToStringNoEncoding(object obj)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = true
            };
            using (StringWriter sw = new Utf8StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sw, settings))
                {
                    serializer.Serialize(writer, obj, ns);
                    return sw.ToString();
                }
            }
        }

        public static T DeserializeFromXmlString<T>(string xmlString)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextReader reader = new StringReader(xmlString))
            {
                return (T)serializer.Deserialize(reader);
            }
        }

        public static Stream GenerateStreamFromString(string s)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public class Utf8StringWriter : StringWriter
        {
            public Utf8StringWriter() : base() { }
            public Utf8StringWriter(StringBuilder sb) : base(sb) { }
            public override Encoding Encoding { get { return Encoding.UTF8; } }
        }
    }
}
