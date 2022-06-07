using System;

namespace BinarySearch
{
    [Serializable]
    public class ExamResult : IComparable<ExamResult>, IEquatable<ExamResult>
    {
        private string _title;

        private Student _student;

        private DateTime _examTime;

        private Score _result;

        public string Title
        {
            get { return _title; }
            set
            {
                if (value.Equals(string.Empty))
                    throw new ArgumentException();
                _title = value;
            }
        }

        public Student Student
        {
            get { return _student; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();
                _student = value;
            }
        }

        public DateTime ExamTime
        {
            get { return _examTime; }
            set
            {
                if (value >= DateTime.Now)
                    throw new ArgumentException();
                _examTime = value;
            }
        }

        public int Result
        {
            get { return (int)_result; }
            set
            {
                if (!Enum.IsDefined(typeof(Score), value))
                    throw new ArgumentException();
                _result = (Score)value;
            }
        }

        public ExamResult()
        {
        }

        public ExamResult(string examName, Student student, DateTime examTime, int result)
        {
            Title = examName;
            Student = student;
            ExamTime = examTime;
            Result = result;
        }

        public int CompareTo(ExamResult other)
        {
            if (other == null)
                throw new ArgumentNullException();

            if (Title.CompareTo(other.Title) == 0)
                if (Student.CompareTo(other.Student) == 0)
                    if (ExamTime.CompareTo(other.ExamTime) == 0)
                        if (Result.CompareTo(other.Result) == 0)
                            return 0;
                        else
                            return Result.CompareTo(other.Result);
                    else
                        return ExamTime.CompareTo(other.ExamTime);
                else
                    return Student.CompareTo(other.Student);
            else
                return Title.CompareTo(other.Title);
        }

        public bool Equals(ExamResult other)
        {
            if (other == null)
                return false;

            if (CompareTo(other) != 0)
                return false;

            return true;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ExamResult);
        }

        public override string ToString()
        {
            return Title + ": " + Student + " - " + Result + " (" + ExamTime + ")";
        }
    }
}