using Model;
using System.Collections.Generic;
using System.Linq;

namespace DAL.EF_SQL
{
    public class LectureDAO_EF_SQL : ILectureDAO
    {
        private string _connectionString;

        public LectureDAO_EF_SQL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Lecture lecture)
        {
            using (StudentsAttendanceContext context = new(_connectionString))
            {
                context.Lectures.Add(lecture);
                context.SaveChanges();
            }
        }

        public void Edit(Lecture lecture)
        {
            Lecture oldLecture;

            using (StudentsAttendanceContext context = new(_connectionString))
            {
                oldLecture = context.Lectures.FirstOrDefault(x => x.LectureId == lecture.LectureId);

                oldLecture.Topic = lecture.Topic;
                oldLecture.LectureDate = lecture.LectureDate;

                context.SaveChanges();
            }
        }

        public List<Lecture> GetLectures()
        {
            List<Lecture> lectures = new();

            using (StudentsAttendanceContext context = new(_connectionString))
            {
                lectures = context.Lectures.ToList();
            }

            return lectures;
        }

        public void Remove(int id)
        {
            using (StudentsAttendanceContext context = new(_connectionString))
            {
                Lecture lecture = context.Lectures.FirstOrDefault(x => x.LectureId == id);
                context.Lectures.Remove(lecture);
                context.SaveChanges();
            }
        }
    }
}