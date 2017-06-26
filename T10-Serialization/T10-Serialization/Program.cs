using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace T10_Serialization
{
    public class Program
    {
        static void Main()
        {
            var serializer = new XmlSerializer(typeof(Catalog));
            Catalog catalog;

            // Deserialize
            using (var reader = new StreamReader("books.xml"))
                catalog = (Catalog) serializer.Deserialize(reader);

            // Serialize
            using (var stringWriter = new StreamWriter("test.xml"))
                using (var writer = XmlWriter.Create(stringWriter))
                    serializer.Serialize(writer, catalog);
        }
    }
}