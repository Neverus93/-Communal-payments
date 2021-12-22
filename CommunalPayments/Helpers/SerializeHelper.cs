using System.IO;
using System.Xml.Serialization;

namespace CommunalPayments.Helpers
{
    public static class SerializeHelper<T>
    {
        public static void Save(T parameter)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(T));
            using (FileStream fs = new FileStream($"{typeof(T).GetType()}.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, parameter);
            }
        }

        public static T Get()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(T));
            using (FileStream fs = new FileStream($"{typeof(T).GetType()}.xml", FileMode.OpenOrCreate))
            {
                T dataCost = (T)formatter.Deserialize(fs);
                return dataCost;
            }
        }
    }
}
