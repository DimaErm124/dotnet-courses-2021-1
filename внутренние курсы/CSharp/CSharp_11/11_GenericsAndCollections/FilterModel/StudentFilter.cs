using BinarySearch;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilterModel
{
    [Serializable]
    public class StudentFilter: Filter<Student>, IComparable<StudentFilter>, IEquatable<StudentFilter>
    {
        public string Name { get; set; }

        public bool UseName { get; set; }

        public string Surname { get; set; }

        public bool UseSurname { get; set; }

        public string MiddleName { get; set; }

        public bool UseMiddleName { get; set; }

        public ModelFilter<int> GroupNumber { get; set; }

        public bool UseGroupNumber { get; set; }
        
        public bool IsEmpty
        {
            get
            {
                return Name == string.Empty
                    && Surname == string.Empty
                    && MiddleName == string.Empty
                    && (GroupNumber == null || !GroupNumber.UseEqual);
            }
        }

        public StudentFilter()
        {
        }
        public StudentFilter(string name, bool useName, string surname, bool useSurname, string middleName, bool useMiddleName, ModelFilter<int> groupNumber, bool useGroupNumber)
        {
            Name = name;
            UseName = useName;
            Surname = surname;
            UseSurname = useSurname;
            MiddleName = middleName;
            UseMiddleName = useMiddleName;
            GroupNumber = groupNumber;
            UseGroupNumber = useGroupNumber;
        }

        public override IEnumerable<Student> Apply(IEnumerable<Student> students)
        {
            if (UseName)
                students = students.Where(x => x.Name.Contains(Name));

            if (UseSurname)
                students = students.Where(x => x.Surname.Contains(Surname));

            if (UseMiddleName)
                students = students.Where(x => x.MiddleName.Contains(MiddleName));

            if (UseGroupNumber)
                if (GroupNumber.UseEqual)
                    students = students.Where(x => x.GroupNumber == GroupNumber.EqualFilter);
                else
                    students = students.Where(x => x.GroupNumber > GroupNumber.MinBorderFilter && x.GroupNumber < GroupNumber.MaxBorderFilter);

            return students;
        }

        public int CompareTo(StudentFilter other)
        {
            if (other == null)
                throw new ArgumentNullException();

            if (UseName.CompareTo(other.UseName) == 0)
                if (Name.CompareTo(other.Name) == 0)
                    if (UseSurname.CompareTo(other.UseSurname) == 0)
                        if (Surname.CompareTo(other.Surname) == 0)
                            if (UseMiddleName.CompareTo(other.UseMiddleName) == 0)
                                if (MiddleName.CompareTo(other.MiddleName) == 0)
                                    if (UseGroupNumber.CompareTo(other.UseGroupNumber) == 0)
                                        if (GroupNumber.CompareTo(other.GroupNumber) == 0)
                                            return 0;
                                        else
                                            return GroupNumber.CompareTo(other.GroupNumber);
                                    else
                                        return UseGroupNumber.CompareTo(other.UseGroupNumber);
                                else
                                    return MiddleName.CompareTo(other.MiddleName);
                            else
                                return UseMiddleName.CompareTo(other.UseMiddleName);
                        else
                            return Surname.CompareTo(other.Surname);
                    else
                        return UseSurname.CompareTo(other.UseSurname);
                else
                    return Name.CompareTo(other.Name);
            else
                return UseName.CompareTo(other.UseName);
        }

        public bool Equals(StudentFilter other)
        {
            if (other == null)
                return false;

            if (CompareTo(other) != 0)
                return false;

            return true;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as StudentFilter);
        }

        public override string ToString()
        {
            string returningString = "{";

            if (UseName)
                returningString += Name;

            returningString += ";";

            if (UseSurname)
                returningString += Surname;

            returningString += ";";

            if (UseMiddleName)
                returningString += MiddleName;

            returningString += ";";

            if (UseGroupNumber)
                returningString += GroupNumber.ToString();

            return returningString + "}";
        }
    }
}