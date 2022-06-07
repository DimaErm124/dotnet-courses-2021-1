using Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.EF_SQL
{
    public class AttendanceDAO_EF_SQL : IAttendanceDAO
    {
        private string _connectionString;

        public AttendanceDAO_EF_SQL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Attendance attendance)
        {
            attendance.StudentId = attendance.Student.StudentId;
            attendance.LectureId = attendance.Lecture.LectureId;
            attendance.Student = null;
            attendance.Lecture = null;

            using (StudentsAttendanceContext context = new(_connectionString))
            {
                context.Attendances.Add(attendance);
                context.SaveChanges();
            }
        }

        public void Edit(Attendance attendance)
        {
            Attendance oldAttendance;

            using (StudentsAttendanceContext context = new(_connectionString))
            {
                oldAttendance = context.Attendances.FirstOrDefault(x => x.AttendanceId == attendance.AttendanceId);

                oldAttendance.StudentId = attendance.Student.StudentId;
                oldAttendance.LectureId = attendance.Lecture.LectureId;
                oldAttendance.Mark = attendance.Mark;

                context.SaveChanges();
            }
        }

        public List<Attendance> GetMarks()
        {
            List<Attendance> attendances = new();

            using (StudentsAttendanceContext context = new(_connectionString))
            {
                attendances = context.Attendances.Include(x=>x.Student).Include(x=>x.Lecture).ToList();
            }

            return attendances;
        }

        public void Remove(int id)
        {
            using (StudentsAttendanceContext context = new(_connectionString))
            {
                Attendance attendance = context.Attendances.FirstOrDefault(x => x.AttendanceId == id);

                if (attendance != null)
                {
                    context.Attendances.Remove(attendance);
                    context.SaveChanges();
                }
            }
        }
    }
}