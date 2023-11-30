using System;
using System.IO;
using System.Xml.Serialization;

namespace CommunalPayments.Helpers
{
    public static class SerializeHelper<T>
    {
        private static Type typeOfT = typeof(T);
        private static string xmlFileName = typeOfT.Name.Replace("Model", String.Empty);

        public static void Save(T parameter)
        {
            XmlSerializer formatter = new XmlSerializer(typeOfT);
            if (!Directory.Exists("Database"))
            {
                Directory.CreateDirectory("Database");
            }
            using (FileStream fs = new FileStream($"Database//{xmlFileName}.xml", FileMode.Create))
            {
                formatter.Serialize(fs, parameter);
            }
        }

        public static T Get()
        {
            XmlSerializer formatter = new XmlSerializer(typeOfT);
            using (FileStream fs = new FileStream($"Database//{xmlFileName}.xml", FileMode.OpenOrCreate))
            {
                T dataCost = (T)formatter.Deserialize(fs);
                return dataCost;
            }
        }

        public static void CheckDataFile(T parameter)
        {
            if (!File.Exists($"Database//{xmlFileName}.xml"))
            {
                Save(parameter);
            }
        }
    }
}
