using System.IO;
using System.Reflection;
using System.Xml.Serialization;

namespace ConsoleApp.Dao
{
    public static class SerializationHelper
    {
        public static T LoadData<T>(string path)
        {
            path = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\{path}";
            using (var reader = new StreamReader(path))
            {
                return (T) new XmlSerializer(typeof(T)).Deserialize(reader);
            }
        }


        public static void SaveData<T>(T data, string path)
        {
            var path1 = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}{path}";
            var xmlSerializer = new XmlSerializer(typeof(T));
            var streamWriter = new StreamWriter(path1);
            xmlSerializer.Serialize(streamWriter, data);
            streamWriter.Close();
        }
    }
}