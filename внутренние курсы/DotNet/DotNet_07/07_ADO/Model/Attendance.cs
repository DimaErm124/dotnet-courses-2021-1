using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Values;

namespace Model
{
    public class Attendance : IComparable
    {
        private Lecture _lecture;

        private Student _student;

        private int _mark;

        public int AttendanceId { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }

        //[Required]
        public Student Student
        {
            get { return _student; }
            set
            {
                //if (value is null)
                //{
                //    throw new ArgumentException();
                //}

                _student = value;
            }
        }

        [ForeignKey("Lecture")]
        public int LectureId { get; set; }

        //[Required]
        public Lecture Lecture
        {
            get { return _lecture; }
            set
            {
                //if (value is null)
                //{
                //    throw new ArgumentException();
                //}

                _lecture = value;
            }
        }

        public int Mark
        {
            get { return _mark; }
            set
            {
                if (value <= 0 && value > BoundaryEntityValues.MaxMarkValue)
                {
                    throw new ArgumentException();
                }

                _mark = value;
            }
        }

        public Attendance() { }

        public Attendance(int id, Student student, Lecture lecture, int mark)
        {
            AttendanceId = id;
            Student = student;
            Lecture = lecture;
            Mark = mark;
        }

        public override string ToString()
        {
            return Student + " " + Lecture + " " + Mark;
        }

        public int CompareTo(object obj)
        {
            return AttendanceId.CompareTo(((Attendance)obj).AttendanceId);
        }
    }
}
