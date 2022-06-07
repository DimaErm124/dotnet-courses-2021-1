using BinarySearch;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace SerializationHandler
{
    public static class XmlSerializationHandler<T> where T : IComparable<T>
    {
        private static readonly XmlSerializer _xmlFormatter = new XmlSerializer(typeof(IterativeTree<T>));

        public static void XmlSerializeTree(IterativeTree<T> tree, string fileName)
        {
            FileStream fs = new FileStream(fileName + ".xml", FileMode.Open);

            try
            {
                _xmlFormatter.Serialize(fs, tree);
            }
            catch
            {
                fs.Dispose();
                FileStream fsc = new FileStream(fileName + ".xml", FileMode.Create);

                try
                {
                    _xmlFormatter.Serialize(fsc, tree);
                }
                finally
                {
                    fsc.Dispose();
                }
            }
            finally
            {
                fs.Dispose();
            }
        }

        public static IterativeTree<T> XmlDeserializeTree(string fileName)
        {
            FileStream fs = new(fileName + ".xml", FileMode.Open);

            try
            {
                IterativeTree<T> tree = (IterativeTree<T>)_xmlFormatter.Deserialize(fs);

                if (tree.IsEmpty)
                    return null;

                return tree;
            }
            catch
            {
                fs.Dispose();
                FileStream fsc = new(fileName + ".xml", FileMode.Create);

                try
                {
                    IterativeTree<T> tree = (IterativeTree<T>)_xmlFormatter.Deserialize(fs);

                    if (tree.IsEmpty)
                        return null;

                    return tree;
                }
                catch
                {
                    return null;
                }
                finally
                {
                    fsc.Dispose();
                }
            }
            finally
            {
                fs.Dispose();
            }
        }
    }
}