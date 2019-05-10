using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bike_Rental_Application
{
    class StorageClass
    {
        internal static void StoreXML<T>(string file, T data)
        {
            FileStream stream;
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            stream = new FileStream(file, FileMode.Create);
            serializer.Serialize(stream, data);
            stream.Close();
        }

        internal static T ReadXML<T>(string file)
        {
            try
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    XmlSerializer xmlser = new XmlSerializer(typeof(T));
                    return (T)xmlser.Deserialize(sr);
                }
            }
            catch
            {
                return default(T);
            }
        }
    }
}

