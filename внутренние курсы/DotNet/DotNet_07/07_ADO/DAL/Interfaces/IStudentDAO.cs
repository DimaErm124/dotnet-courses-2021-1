using Model;
using System.Collections.Generic;

namespace DAL
{
    public interface IStudentDAO
    {
        void Add(Student student);
        
        void Edit(Student student);

        void Remove(int id);

        List<Student> GetStudents();
    }
}