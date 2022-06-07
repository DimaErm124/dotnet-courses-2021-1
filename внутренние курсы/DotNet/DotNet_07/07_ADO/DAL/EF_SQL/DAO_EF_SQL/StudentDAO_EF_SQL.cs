using Model;
using System.Collections.Generic;
using System.Linq;

namespace DAL.EF_SQL
{
    public class StudentDAO_EF_SQL : IStudentDAO
    {
        private string _connectionString;

        public StudentDAO_EF_SQL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Student student)
        {
            using (StudentsAttendanceContext context = new(_connectionString))
            {
                context.Students.Add(student);
                context.SaveChanges();
            }
        }

        public void Edit(Student student)
        {
            Student oldStudent;

            using (StudentsAttendanceContext context = new(_connectionString))
            {
                oldStudent = context.Students.FirstOrDefault(x => x.StudentId == student.StudentId);

                oldStudent.Name = student.Name;

                context.SaveChanges();
            }
        }

        public List<Student> GetStudents()
        {
            List<Student> students = new();

            using (StudentsAttendanceContext context = new(_connectionString))
            {
                students = context.Students.ToList();
            }

            return students;
        }

        public void Remove(int id)
        {
            using (StudentsAttendanceContext context = new(_connectionString))
            {
                Student student = context.Students.FirstOrDefault(x => x.StudentId == id);

                if (student != null)
                {
                    context.Students.Remove(student);
                    context.SaveChanges();
                }
            }
        }
    }
}