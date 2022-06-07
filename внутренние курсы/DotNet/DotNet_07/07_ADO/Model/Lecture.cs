using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Values;

namespace Model
{
    public class Lecture : IComparable
    {
        private string _topic;

        private DateTime _date;

        public int LectureId { get; set; }

        public string Topic
        {
            get { return _topic; }
            set
            {
                if (value.Length > BoundaryEntityValues.MaxLengthTopic)
                {
                    throw new ArgumentException();
                }

                _topic = value;
            }
        }

        public DateTime LectureDate
        {
            get { return _date; }
            set
            {
                var today = DateTime.Now;

                if (value > today)
                {
                    throw new ArgumentException();
                }

                _date = value;
            }
        }

        public List<Attendance> Attendances { get; set; }

        public Lecture() { }

        public Lecture(int id, string topic, DateTime lectureDate)
        {
            LectureId = id;
            Topic = topic;
            LectureDate = lectureDate;
        }

        public override string ToString()
        {
            return Topic + " " + LectureDate;
        }

        public int CompareTo(object obj)
        {
            return LectureId.CompareTo(((Lecture)obj).LectureId);
        }
    }
}
