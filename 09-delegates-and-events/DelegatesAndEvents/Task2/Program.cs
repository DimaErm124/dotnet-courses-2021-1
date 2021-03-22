using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        public event EventHandler<PersonEventArgs> inOffice;

        public event EventHandler outOffice;

        static void Main(string[] args)
        {
            Person jack = new Person("Джэк");
            Person john = new Person("Джон");
            Person sam = new Person("Сэм");
            Person fred = new Person("Фред");
        }

        public void GoIn(Person person)
        {
            inOffice(person, new PersonEventArgs(DateTime.Now));
            inOffice += person.Greeting;
        }

        public void GoOut(Person person)
        {
            outOffice(person, new EventArgs());
        }
    }

    public class Person
    {
        public string Name { get; set; }

        public Person(string name)
        {
            Name = name;
        }

        public void Greeting(Person person, PersonEventArgs personEventArgs)
        {
            var hour = personEventArgs.ArrivalTime.Hour;

            var greetingString = string.Empty;

            if (hour < 12)
            {
                greetingString += "Доброе утро, ";
            }
            if (hour >= 12 || hour < 17)
            {
                greetingString += "Добрый день, ";
            }
            if (hour >= 17)
            {
                greetingString += "Добрый вечер, ";
            }

            var str = greetingString + person.Name;
        }

        public string Parting(Person person)
        {
            return "Пока, " + person.Name;
        }

    }

    public class PersonEventArgs : EventArgs
    {
        public DateTime ArrivalTime { get; set; }

        public PersonEventArgs(DateTime dateTime)
        {
            ArrivalTime = dateTime;
        }
    }
}