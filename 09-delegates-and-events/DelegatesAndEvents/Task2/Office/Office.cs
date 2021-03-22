using System;

namespace Task2
{
    public delegate void OfficeHandler<T>(Person person, T eventArgs, Displayer drawer)
        where T : EventArgs;

    public delegate void OfficeHandler(Person person, Displayer drawer);

    public class Office
    {
        public event OfficeHandler<OfficeEventArgs> PersonCame;

        public event OfficeHandler PersonLeft;
                
        public void Come(Person person, Displayer drawer)
        {
            if (PersonCame != null)
            {
                PersonCame(person, new OfficeEventArgs(person.Name, DateTime.Now), drawer);
            }

            PersonCame += person.Greeting;
            PersonLeft += person.Parting;
        }

        public void Leave(Person person, Displayer drawer)
        {
            PersonCame -= person.Greeting;
            PersonLeft -= person.Parting;

            if (PersonLeft != null)
            {
                PersonLeft(person, drawer);
            }
            
        }
    }
}