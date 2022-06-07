using System;

namespace Task1
{
    public class Reward : IComparable
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public object this[string fieldName]
        {
            get
            {
                switch (fieldName)
                {
                    case "Title":
                        return Title;
                    case "Description":
                        return Description;                    
                    default:
                        return ID;
                }
            }
        }

        public Reward(int id, string title, string description = "")
        {
            ID = id;
            Title = title;
            Description = description;
        }

        public override string ToString()
        {
            return Title;
        }
         
        public int CompareTo(object obj)
        {
            return ID.CompareTo(((Reward)obj).ID);
        }
    }
}
