using System;
using System.Collections.Generic;

namespace CarRental
{
    public class XmlFileHandler<T> : IFileHandler<T>
    {
        private readonly string _fileName;

        public XmlFileHandler(string fileName)
        {
            _fileName = fileName;
        }

        public List<T> Read()
        {
            return XmlSerializationHandler<T>.XmlDeserialize(_fileName);
        }

        public bool Write(T user)
        {
            List<T> listOfT = XmlSerializationHandler<T>.XmlDeserialize(_fileName);

            if (listOfT == null)
                listOfT = new List<T>();

            listOfT.Add(user);

            try
            {
                XmlSerializationHandler<T>.XmlSerialize(listOfT, _fileName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool WriteAll(List<T> entities)
        {
            try
            {
                XmlSerializationHandler<T>.XmlSerialize(entities, _fileName);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}