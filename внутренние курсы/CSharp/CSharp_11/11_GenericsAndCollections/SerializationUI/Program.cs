using BinarySearch;
using BinarySearchTreeFilters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace SerializationUI
{
    class Program
    {
        private static readonly ExamResult[] _examResults =
        {
            new ExamResult("Math operations",new Student("Dmitriy","Ermakov","Sergeevich",643),new DateTime(2017,9,4),5),
            new ExamResult("English articles",new Student("Sam","Johnson","Pots",345),new DateTime(2021,9,4),3),
            new ExamResult("English articles",new Student("Dmitriy","Ermakov","Sergeevich",643),new DateTime(2021,9,4),4)
        };

        private static readonly int[] numbers =
        {
            5,1,2,3,4,6,7,8,9,10
        };

        static void Main(string[] args)
        {
            Run(_examResults, nameof(_examResults));
            Run(numbers, nameof(numbers));

            RunFilters();
        }

        public static void RunFilters()
        {
            IterativeTree<ExamResult> tree = new IterativeTree<ExamResult>(_examResults);
            Filters<ExamResult> filters = new Filters<ExamResult>(tree);

            Console.WriteLine("1");
            filters.ElementsBetweenItems("Result", 3, 5, true);

            OutputCollection(filters.Apply());

            Console.WriteLine("\n2");
            filters.ElementsContainsSubstring("Title", "Math");

            OutputCollection(filters.Apply());

            Console.WriteLine("\n3");
            filters.ElementsWithRegexPattern("Title", new Regex(@"Math \w*"));

            OutputCollection(filters.Apply());
        }

        public static void OutputCollection(IEnumerable<ExamResult> collection)
        {
            foreach(var el in collection)
            {
                Console.WriteLine(el);
            }
        }

        public static void Run<T>(T[] array, string fileName)
            where T : IComparable<T>
        {
            IterativeTree<T> tree = new IterativeTree<T>(array);

            IterativeTree<T> newXmlTree = XmlSerializeAndDeserializeTree<T>(tree, fileName);
            IterativeTree<T> newBinTree = BinSerializeAndDeserializeTree<T>(tree, fileName);
        }

        public static IterativeTree<T> XmlSerializeAndDeserializeTree<T>(IterativeTree<T> tree, string fileName)
            where T : IComparable<T>
        {
            XmlSerializer xmlFormatter = new XmlSerializer(typeof(IterativeTree<T>));

            using (FileStream fs = new FileStream(fileName + ".xml", FileMode.OpenOrCreate))
                xmlFormatter.Serialize(fs, tree);

            using (FileStream fs = new FileStream(fileName + ".xml", FileMode.OpenOrCreate))
                return (IterativeTree<T>)xmlFormatter.Deserialize(fs);
        }

        public static IterativeTree<T> BinSerializeAndDeserializeTree<T>(IterativeTree<T> tree, string fileName)
            where T : IComparable<T>
        {
            BinaryFormatter binFormatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(fileName + ".dat", FileMode.OpenOrCreate))
                binFormatter.Serialize(fs, tree);


            using (FileStream fs = new FileStream(fileName + ".dat", FileMode.OpenOrCreate))
                return (IterativeTree<T>)binFormatter.Deserialize(fs);
        }
    }
}