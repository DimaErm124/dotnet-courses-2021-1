using HandlerValue;
using System;

namespace EntityLibrary
{
    public class Reward : IComparable
    {
        private string _title;

        private string _description;

        public int ID { get; set; }

        public string Title 
        {
            get { return _title; }
            set
            {
                if (value.Length > InputHandlerValue.MAX_LENGTH_TITLE)
                {
                    throw new ArgumentException();
                }

                _title = value;
            }
        }

        public string Description 
        {
            get { return _description; }
            set
            {
                if (value == null)
                {
                    value = "";
                }
                if (value.Length > InputHandlerValue.MAX_LENGTH_DESCRIPTION)
                {
                    throw new ArgumentException();
                }
                
                _description = value;
            }
        }

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
