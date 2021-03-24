namespace Task2
{
    public class Person
    {
        public string Name { get; private set; }

        public Person(string name)
        {
            Name = name;
        }

        public void Greeting(Person person, OfficeEventArgs personEventArgs, Displayer drawer)
        {
            var hour = personEventArgs.ArrivalTime.Hour;

            var greetingString = string.Empty;

            if (hour < 12)
            {
                greetingString += "- Доброе утро, ";
            }
            if (hour >= 12 && hour < 17)
            {
                greetingString += "- Добрый день, ";
            }
            if (hour >= 17)
            {
                greetingString += "- Добрый вечер, ";
            }

            drawer.Dislay(greetingString + person.Name + "!,- сказал " + this.Name);
        }

        public void Parting(Person person, Displayer drawer)
        {
            drawer.Dislay("- Пока, " + person.Name + "!,- сказал " + this.Name);
        }
    }
}