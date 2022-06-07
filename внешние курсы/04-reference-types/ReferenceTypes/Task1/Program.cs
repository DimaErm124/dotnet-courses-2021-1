using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User("User", "Smith", "Johnson", new DateTime(2013, 10, 12));

            Console.WriteLine("Age of this user: {0}", user.Age);
        }
    }
}
