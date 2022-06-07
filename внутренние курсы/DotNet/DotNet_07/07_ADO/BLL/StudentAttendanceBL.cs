using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class StudentAttendanceBL
    {
        private IStudentDAO _studentDAO;

        private ILectureDAO _lectureDAO;

        private IAttendanceDAO _attendanceDAO;

        public StudentAttendanceBL(IStudentDAO studentDAO, ILectureDAO lectureDAO, IAttendanceDAO attendanceDAO)
        {
            _studentDAO = studentDAO;
            _lectureDAO = lectureDAO;
            _attendanceDAO = attendanceDAO;
        }

        public void AddStudent(Student student)
        {
            if (student == null)
                throw new ArgumentNullException();

            _studentDAO.Add(student);
        }

        public void AddLecture(Lecture lecture)
        {
            if (lecture == null)
                throw new ArgumentNullException();

            _lectureDAO.Add(lecture);
        }

        public void AddAttendance(Attendance attendance, Student student, Lecture lecture)
        {
            if (attendance == null)
                throw new ArgumentNullException();

            _attendanceDAO.Add(attendance);
        }

        public void RemoveStudent(int id)
        {
            _studentDAO.Remove(id);
        }

        public void RemoveLecture(int id)
        {
            _lectureDAO.Remove(id);
        }

        public void RemoveAttendance(int id)
        {
            _attendanceDAO.Remove(id);
        }

        public void EditStudent(Student student)
        {
            if (student == null)
                throw new ArgumentNullException();

            _studentDAO.Edit(student);
        }

        public void EditLecture(Lecture lecture)
        {
            if (lecture == null)
                throw new ArgumentNullException();

            _lectureDAO.Edit(lecture);
        }

        public void EditAttendance(Attendance attendance)
        {
            if (attendance == null)
                throw new ArgumentNullException();

            _attendanceDAO.Edit(attendance);
        }

        public List<Student> GetStudents()
        {
            return _studentDAO.GetStudents();
        }

        public List<Lecture> GetLectures()
        {
            return _lectureDAO.GetLectures();
        }

        public List<Attendance> GetAttendances()
        {
            return _attendanceDAO.GetMarks();
        }
    }
}