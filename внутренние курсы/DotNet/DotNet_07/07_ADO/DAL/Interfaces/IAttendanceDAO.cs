using Model;
using System.Collections.Generic;

namespace DAL
{
    public interface IAttendanceDAO
    {
        void Add(Attendance attendance);

        void Edit(Attendance attendance);

        void Remove(int id);

        List<Attendance> GetMarks();
    }
}