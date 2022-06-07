using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace CarRental
{
    public static class XmlSerializationHandler<T>
    {
        private static readonly XmlSerializer _xmlFormatter = new XmlSerializer(typeof(List<T>));

        public static void XmlSerialize(List<T> listOfT, string fileName)
        {
            using (FileStream fs = new FileStream(fileName + ".xml", FileMode.Create))
            {
                _xmlFormatter.Serialize(fs, listOfT);
            }
        }

        public static List<T> XmlDeserialize(string fileName)
        {
            List<T> listOfT = new List<T>();

            FileStream fs = new FileStream(fileName + ".xml", FileMode.OpenOrCreate);

            try
            {
                
                listOfT = (List<T>)_xmlFormatter.Deserialize(fs);
            }
            catch
            {

            }
            finally
            {
                fs.Dispose();
            }

            return listOfT;
        }
    }
}