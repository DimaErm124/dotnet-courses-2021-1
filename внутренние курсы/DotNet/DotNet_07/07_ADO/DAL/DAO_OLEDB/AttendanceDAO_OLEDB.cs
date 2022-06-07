using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using Values;

namespace DAL
{
    public class AttendanceDAO_OLEDB : IAttendanceDAO
    {
        private readonly string _connectionString;

        public AttendanceDAO_OLEDB(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Attendance attendance)
        {
            if (attendance == null)
                throw new ArgumentNullException();

            using (OleDbConnection connection = new(_connectionString))
            using (OleDbCommand command = new(CommandName.InsertAttendance, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue($"@{FieldsName.StudentId}", attendance.Student.StudentId);
                command.Parameters.AddWithValue($"@{FieldsName.LectureId}", attendance.Lecture.LectureId);
                command.Parameters.AddWithValue($"@{FieldsName.Mark}", attendance.Mark);

                connection.Open();

                command.ExecuteNonQuery();
            }

        }

        public void Edit(Attendance attendance)
        {
            if (attendance == null)
                throw new ArgumentNullException();

            using (OleDbConnection connection = new(_connectionString))
            using (OleDbCommand command = new(CommandName.UpdateAttendance, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue($"@{FieldsName.AttendanceId}", attendance.AttendanceId);
                command.Parameters.AddWithValue($"@{FieldsName.StudentId}", attendance.Student.StudentId);
                command.Parameters.AddWithValue($"@{FieldsName.LectureId}", attendance.Lecture.LectureId);
                command.Parameters.AddWithValue($"@{FieldsName.Mark}", attendance.Mark);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public void Remove(int id)
        {
            using (OleDbConnection connection = new(_connectionString))
            using (OleDbCommand command = new(CommandName.DeleteAttendance, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue($"@{FieldsName.AttendanceId}", id);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public List<Attendance> GetMarks()
        {
            List<Attendance> attendances = new();
            OleDbDataReader attendancesString;

            using (OleDbConnection connection = new(_connectionString))
            using (OleDbCommand command = new(CommandName.GetMarks, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                attendancesString = command.ExecuteReader();
            }

            while (attendancesString.Read())
            {
                int id = attendancesString.GetInt32(0);
                int studentId = attendancesString.GetInt32(1);
                int lectureId = attendancesString.GetInt32(2);
                int mark = attendancesString.GetInt32(3);

                Student student;
                string name;

                Lecture lecture;
                string topic;
                DateTime dateTime;

                using (OleDbConnection connection = new(_connectionString))
                using (OleDbCommand studentCommand = new(CommandName.GetStudent, connection))
                {
                    studentCommand.CommandType = CommandType.StoredProcedure;

                    studentCommand.Parameters.AddWithValue($"@{FieldsName.StudentId}", studentId);

                    connection.Open();

                    OleDbDataReader studentsString = studentCommand.ExecuteReader();

                    studentsString.Read();

                    name = studentsString.GetString(1);

                    student = new(studentId, name);
                }

                using (OleDbConnection connection = new(_connectionString))
                using (OleDbCommand lectureCommand = new(CommandName.GetLecture, connection))
                {
                    lectureCommand.CommandType = CommandType.StoredProcedure;

                    lectureCommand.Parameters.AddWithValue($"@{FieldsName.StudentId}", lectureId);

                    connection.Open();

                    OleDbDataReader studentsString = lectureCommand.ExecuteReader();

                    studentsString.Read();

                    topic = studentsString.GetString(1);
                    dateTime = studentsString.GetDateTime(2);

                    lecture = new(lectureId, topic, dateTime);
                }

                Attendance attendance = new Attendance(id, student, lecture, mark);

                attendances.Add(attendance);
            }

            return attendances;
        }
    }
}