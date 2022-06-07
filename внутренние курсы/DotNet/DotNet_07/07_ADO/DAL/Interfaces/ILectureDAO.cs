using Model;
using System.Collections.Generic;

namespace DAL
{
    public interface ILectureDAO
    {
        void Add(Lecture lecture);

        void Remove(int id);

        void Edit(Lecture lecture);

        List<Lecture> GetLectures();
    }

}
