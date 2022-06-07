using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Values;

namespace DAL
{
    public class AttendanceDAO_SQL : IAttendanceDAO
    {
        private readonly string _connectionString;

        public AttendanceDAO_SQL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Attendance attendance)
        {
            if (attendance == null)
                throw new ArgumentNullException();

            using (SqlConnection connection = new(_connectionString))
            using (SqlCommand command = new(CommandName.InsertAttendance, connection))
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

            using (SqlConnection connection = new(_connectionString))
            using (SqlCommand command = new(CommandName.UpdateAttendance, connection))
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
            using (SqlConnection connection = new(_connectionString))
            using (SqlCommand command = new(CommandName.DeleteAttendance, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue($"@{FieldsName.AttendanceId}", id);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public void RemoveStudent(int id)
        {
            using (SqlConnection connection = new(_connectionString))
            using (SqlCommand command = new(CommandName.DeleteAttendanceOfStudent, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue($"@{FieldsName.StudentId}", id);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public void RemoveLecture(int id)
        {
            using (SqlConnection connection = new(_connectionString))
            using (SqlCommand command = new(CommandName.DeleteAttendanceOfLecture, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue($"@{FieldsName.LectureId}", id);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public List<Attendance> GetMarks()
        {
            List<Attendance> attendances = new();
            SqlDataReader attendancesString;

            using (SqlConnection connection = new(_connectionString))
            using (SqlCommand command = new(CommandName.GetMarks, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                attendancesString = command.ExecuteReader();

                while (attendancesString.Read())
                {
                    int id = attendancesString.GetInt32(0);
                    int studentId = attendancesString.GetInt32(1);
                    int lectureId = attendancesString.GetInt32(2);
                    int mark = attendancesString.GetInt32(3);

                    Student student = new() { StudentId = studentId };

                    Lecture lecture = new() { LectureId = lectureId };

                    Attendance attendance = new(id, student, lecture, mark);

                    attendances.Add(attendance);
                }
            }

            for (int i = 0; i < attendances.Count; i++)
            {
                using (SqlConnection connection = new(_connectionString))
                using (SqlCommand studentCommand = new(CommandName.GetStudent, connection))
                {
                    studentCommand.CommandType = CommandType.StoredProcedure;

                    studentCommand.Parameters.AddWithValue($"@{FieldsName.StudentId}", attendances[i].Student.StudentId);

                    connection.Open();

                    SqlDataReader studentsString = studentCommand.ExecuteReader();

                    studentsString.Read();

                    attendances[i].Student.Name = studentsString.GetString(1);
                }

                using (SqlConnection connection = new(_connectionString))
                using (SqlCommand lectureCommand = new(CommandName.GetLecture, connection))
                {
                    lectureCommand.CommandType = CommandType.StoredProcedure;

                    lectureCommand.Parameters.AddWithValue($"@{FieldsName.LectureId}", attendances[i].Lecture.LectureId);

                    connection.Open();

                    SqlDataReader lecturesString = lectureCommand.ExecuteReader();

                    lecturesString.Read();

                    attendances[i].Lecture.Topic = lecturesString.GetString(1);
                    attendances[i].Lecture.LectureDate = lecturesString.GetDateTime(2);
                }
            }

            return attendances;
        }
    }
}