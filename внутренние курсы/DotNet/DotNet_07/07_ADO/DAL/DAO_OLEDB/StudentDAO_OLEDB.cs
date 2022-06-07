﻿using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using Values;

namespace DAL
{
    public class StudentDAO_OLEDB : IStudentDAO
    {
        private readonly string _connectionString;

        public StudentDAO_OLEDB(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Student student)
        {
            if (student == null)
                throw new ArgumentNullException();

            int id = 0;

            using (OleDbConnection connection = new(_connectionString))
            using (OleDbCommand command = new(CommandName.InsertStudent, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue($"@{FieldsName.Name}", student.Name);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public void Edit(Student student)
        {
            if (student == null)
                throw new ArgumentNullException();

            using (OleDbConnection connection = new(_connectionString))
            using (OleDbCommand command = new(CommandName.UpdateStudent, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue($"@{FieldsName.StudentId}", student.StudentId);
                command.Parameters.AddWithValue($"@{FieldsName.Name}", student.Name);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public void Remove(int id)
        {
            RemoveAttendance(id);
            RemoveStudent(id);
        }

        private void RemoveStudent(int id)
        {
            using (OleDbConnection connection = new(_connectionString))
            using (OleDbCommand command = new(CommandName.DeleteStudent, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue($"@{FieldsName.StudentId}", id);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        private void RemoveAttendance(int id)
        {
            using (OleDbConnection connection = new(_connectionString))
            using (OleDbCommand command = new(CommandName.DeleteAttendanceOfStudent, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue($"@{FieldsName.StudentId}", id);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public List<Student> GetStudents()
        {
            List<Student> students = new();

            using (OleDbConnection connection = new(_connectionString))
            using (OleDbCommand command = new(CommandName.GetStudents, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                var studentsString = command.ExecuteReader();

                while (studentsString.Read())
                {
                    int id = studentsString.GetInt32(0);
                    string name = studentsString.GetString(1);

                    Student student = new(id, name);

                    students.Add(student);
                }
            }

            return students;
        }
    }
}