using System;

namespace Task2
{
    public class OfficeEventArgs : EventArgs
    {
        public string Name { get; set; }

        public DateTime ArrivalTime { get; set; }

        public OfficeEventArgs(string name, DateTime dateTime)
        {
            Name = name;
            ArrivalTime = dateTime;
        }
    }
}