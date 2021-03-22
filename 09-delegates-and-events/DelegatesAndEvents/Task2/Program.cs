using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {       
        static void Main(string[] args)
        {
            var people = GetPeople("Джэк", "Джон", "Сэм", "Фред", "Боб", "Ричард");

            var office = new Office();

            var consoleDisplayer = new ConsoleDisplayer();

            foreach(var person in people)
            {
                Console.WriteLine("[В офис пришел {0}]", person.Name);
                office.Come(person, consoleDisplayer);
                Console.WriteLine();
            }

            foreach (var person in people)
            {
                Console.WriteLine("[Офис покинул {0}]", person.Name);
                office.Leave(person, consoleDisplayer);
                Console.WriteLine();
            }
        }

        public static List<Person> GetPeople(params string[] names)
        {
            var people = new List<Person>();

            foreach (var name in names)
            {
                people.Add(new Person(name));
            }

            return people;
        }
    }
}