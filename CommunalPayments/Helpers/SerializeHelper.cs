using System.IO;
using System.Xml.Serialization;

namespace CommunalPayments.Helpers
{
    public static class SerializeHelper<T>
    {
        public static void Save(T parameter)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(T));
            if (!Directory.Exists("Database"))
            {
                Directory.CreateDirectory("Database");
            }
            //TODO удалить CommunalPayments.Models. из начала названия файла
            using (FileStream fs = new FileStream($"Database//{parameter.GetType()}.xml", FileMode.Create))
            {
                formatter.Serialize(fs, parameter);
            }
        }

        public static T Get()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(T));
            using (FileStream fs = new FileStream($"Database//{Get().GetType()}.xml", FileMode.OpenOrCreate))
            {
                T dataCost = (T)formatter.Deserialize(fs);
                return dataCost;
            }
        }
    }
}
