using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Values;

namespace DAL
{
    public class LectureDAO_SQL : ILectureDAO
    {
        private readonly string _connectionString;

        public LectureDAO_SQL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Lecture lecture)
        {
            if (lecture == null)
                throw new ArgumentNullException();

            using (SqlConnection connection = new(_connectionString))
            using (SqlCommand command = new(CommandName.InsertLecture, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue($"@{FieldsName.Topic}", lecture.Topic);
                command.Parameters.AddWithValue($"@{FieldsName.LectureDate}", lecture.LectureDate);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public void Edit(Lecture lecture)
        {
            if (lecture == null)
                throw new ArgumentNullException();

            using (SqlConnection connection = new(_connectionString))
            using (SqlCommand command = new(CommandName.UpdateLecture, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue($"@{FieldsName.LectureId}", lecture.LectureId);
                command.Parameters.AddWithValue($"@{FieldsName.Topic}", lecture.Topic);
                command.Parameters.AddWithValue($"@{FieldsName.LectureDate}", lecture.LectureDate);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public void Remove(int id)
        {
            RemoveAttendance(id);
            RemoveLecture(id);
        }

        private void RemoveLecture(int id)
        {

            using (SqlConnection connection = new(_connectionString))
            using (SqlCommand command = new(CommandName.DeleteLecture, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue($"@{FieldsName.LectureId}", id);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        private void RemoveAttendance(int id)
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

        public List<Lecture> GetLectures()
        {
            List<Lecture> Lectures = new();

            using (SqlConnection connection = new(_connectionString))
            using (SqlCommand command = new(CommandName.GetLectures, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                var lecturesString = command.ExecuteReader();

                while (lecturesString.Read())
                {
                    int id = lecturesString.GetInt32(0);
                    string topic = lecturesString.GetString(1);
                    DateTime lectureDate = lecturesString.GetDateTime(2);

                    Lecture lecture = new(id, topic, lectureDate);

                    Lectures.Add(lecture);
                }
            }

            return Lectures;
        }
    }
}