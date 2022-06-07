using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Values;

namespace Model
{
    public class Student : IComparable
    {
        private string _name;

        public int StudentId { get; set; }

        public string Name 
        {
            get { return _name; }
            set
            {
                if (value.Length > BoundaryEntityValues.MaxLengthName)
                {
                    throw new ArgumentException();
                }

                _name = value;
            } 
        }

        public List<Attendance> Attendances { get; set; }

        public Student() { }

        public Student(int id, string name)
        {
            StudentId = id;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

        public int CompareTo(object obj)
        {
            return StudentId.CompareTo(((Student)obj).StudentId);
        }
    }
}
