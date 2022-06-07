using System;

namespace BinarySearch
{
    [Serializable]
    public class Student : IComparable<Student>, IEquatable<Student>
    {
        private int _numberGroup;

        private string _name;

        private string _surname;

        private string _middleName;

        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Equals(string.Empty))
                    throw new ArgumentException();
                _name = value;
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                if (value.Equals(string.Empty))
                    throw new ArgumentException();
                _surname = value;
            }
        }

        public string MiddleName
        {
            get { return _middleName; }
            set
            {
                if (value.Equals(string.Empty))
                    throw new ArgumentException();
                _middleName = value;
            }
        }

        public int GroupNumber
        {
            get { return _numberGroup; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException();
                _numberGroup = value;
            }
        }

        public Student()
        {
        }

        public Student(string name, string surname, string middleName, int groupNumber)
        {
            Name = name;
            Surname = surname;
            MiddleName = middleName;
            GroupNumber = groupNumber;
        }

        public int CompareTo(Student student)
        {
            if (student == null)
                throw new ArgumentNullException();

            if (Surname.CompareTo(student.Surname) == 0)
                if (Name.CompareTo(student.Name) == 0)
                    if (MiddleName.CompareTo(student.MiddleName) == 0)
                        if (GroupNumber.CompareTo(student.GroupNumber) == 0)
                            return 0;
                        else
                           return GroupNumber.CompareTo(student.GroupNumber);
                    else
                        return MiddleName.CompareTo(student.MiddleName);
                else
                    return Name.CompareTo(student.Name);
            else
                return Surname.CompareTo(student.Surname);
        }

        public override int GetHashCode()
        {
            return (Name == null ? string.Empty : Name).GetHashCode()
                ^ (Surname == null ? string.Empty : Surname).GetHashCode()
                ^ (MiddleName == null ? string.Empty : MiddleName).GetHashCode()
                ^ GroupNumber.GetHashCode();
        }
        
        public bool Equals(Student other)
        {
            if (other == null)
                return false;

            if (CompareTo(other) != 0)
                return false;

            return true;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Student);
        }

        public override string ToString()
        {
            return Name + " " + Surname + " " + MiddleName;
        }        
    }
}