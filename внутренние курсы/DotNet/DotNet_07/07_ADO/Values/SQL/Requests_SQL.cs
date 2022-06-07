namespace Values
{
    public static class Requests_SQL
    {
        public static readonly string ExistDB = "DECLARE @result int"
                                               + " IF(EXISTS(SELECT name FROM dbo.sysdatabases WHERE('[' + name + ']' = 'StudentAttendanceDB' OR name = 'StudentAttendanceDB')))"
                                               + " SET @result = 1 ELSE SET @result = 0 SELECT @result";

        public static readonly string CreateDB = "CREATE DATABASE StudentAttendanceDB";

        public static readonly string ExistTable = "DECLARE @result int"
                                               + " IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_CATALOG = 'StudentAttendanceDB' AND  TABLE_NAME = '{0}'))"
                                               + " SET @result = 1 ELSE SET @result = 0 SELECT @result";

        public static readonly string CreateStudentTable = string.Format($"CREATE TABLE {TablesName.Students}("
                                                                       + $"{FieldsName.StudentId} {UsingTypes_SQL.Int} IDENTITY(1,1),"
                                                                       + $"{FieldsName.Name} {string.Format(UsingTypes_SQL.StringWithSize, BoundaryEntityValues.MaxLengthName)} NOT NULL,"
                                                                       + $"CONSTRAINT {FieldsName.StudentId}_PK PRIMARY KEY({FieldsName.StudentId}))");

        public static readonly string CreateLectureTable = string.Format($"CREATE TABLE {TablesName.Lectures}("
                                                                       + $"{FieldsName.LectureId} {UsingTypes_SQL.Int} IDENTITY(1,1),"
                                                                       + $"{FieldsName.Topic} {string.Format(UsingTypes_SQL.StringWithSize, BoundaryEntityValues.MaxLengthTopic)} NOT NULL,"
                                                                       + $"{FieldsName.LectureDate} {UsingTypes_SQL.Date} NOT NULL,"
                                                                       + $"CONSTRAINT {FieldsName.LectureId}_PK PRIMARY KEY({FieldsName.LectureId}))");

        public static readonly string CreateAttendanceTable = string.Format($"CREATE TABLE {TablesName.Attendances}("
                                                                       + $"{FieldsName.AttendanceId} {UsingTypes_SQL.Int} IDENTITY(1,1),"
                                                                       + $"{FieldsName.StudentId} {UsingTypes_SQL.Int} NOT NULL, "
                                                                       + $"{FieldsName.LectureId} {UsingTypes_SQL.Int} NOT NULL, "
                                                                       + $"{FieldsName.Mark} {UsingTypes_SQL.Int} NOT NULL, "
                                                                       + $"CONSTRAINT {FieldsName.AttendanceId}_PK PRIMARY KEY({FieldsName.AttendanceId}),"
                                                                       + $"CONSTRAINT {FieldsName.StudentId}_FK FOREIGN KEY ({FieldsName.StudentId}) REFERENCES {TablesName.Students}({FieldsName.StudentId}),"
                                                                       + $"CONSTRAINT {FieldsName.LectureId}_FK FOREIGN KEY ({FieldsName.LectureId}) REFERENCES {TablesName.Lectures}({FieldsName.LectureId}))");

        public static string Insert(string procedureName, string inputParam, string tableName, string insertingParam, string param)
        {
            return $"CREATE OR ALTER PROCEDURE {procedureName}({inputParam}) AS INSERT INTO {tableName}({insertingParam}) VALUES({param})";
        }

        public static string Update(string procedureName, string inputParam, string tableName, string updatingParam, string condition)
        {
            return $"CREATE OR ALTER PROCEDURE {procedureName}({inputParam}) AS UPDATE {tableName} SET {updatingParam} WHERE {condition}";
        }

        public static string Delete(string procedureName, string inputParam, string tableName, string condition)
        {
            return $"CREATE OR ALTER PROCEDURE {procedureName}({inputParam}) AS DELETE FROM {tableName} WHERE {condition}";
        }

        public static string Get(string procedureName, string tableName, string condition)
        {
            return $"CREATE OR ALTER PROCEDURE {procedureName} AS SELECT * FROM {tableName} WHERE {condition}";
        }
    }
}