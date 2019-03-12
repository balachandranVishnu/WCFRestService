using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
/// <summary>
/// Generic helper class for serilaze and deserialize
/// </summary>
namespace Harrods.Service.Employees.UnitTest
{
    public class SerializationHelper
    {
        public static string SerializeXml<T>(T obj)
        {
            var serializer = new DataContractSerializer(typeof(T));
            var ms = new MemoryStream();
            serializer.WriteObject(ms, obj);
            string retVal = Encoding.Default.GetString(ms.ToArray());
            ms.Dispose();
            return retVal;
        }

        public static T DeserializeXml<T>(string xml)
        {
            using (var reader = new StringReader(xml))
            {
                using (var xmlReader = XmlReader.Create(reader))
                {
                    var serializer = new DataContractSerializer(typeof(T));
                    var obj = (T)serializer.ReadObject(xmlReader);
                    return obj;
                }
            }
        }

        public static string SerializeJson<T>(T obj)
        {
            var serializer = new DataContractJsonSerializer(typeof(T));
            var ms = new MemoryStream();
            serializer.WriteObject(ms, obj);
            string retVal = Encoding.Default.GetString(ms.ToArray());
            ms.Dispose();
            return retVal;
        }

        public static T DeserializeJson<T>(string json)
        {
            var ms = new MemoryStream(Encoding.Unicode.GetBytes(json));
            var serializer = new DataContractJsonSerializer(typeof(T));
            var obj = (T)serializer.ReadObject(ms);
            ms.Close();
            ms.Dispose();
            return obj;
        }
    }
}
