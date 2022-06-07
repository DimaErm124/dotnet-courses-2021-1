using Model;
using System;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF_SQL
{
    public class StudentsAttendanceContext : DbContext
    {
        public StudentsAttendanceContext(string connectionString) : base(connectionString)
        { }

        public DbSet<Student> Students { get; set; }

        public DbSet<Lecture> Lectures { get; set; }

        public DbSet<Attendance> Attendances { get; set; }
    }
}