using Values;

namespace DAL
{
    public class StudentRequestHandler_SQL : IStudentRequestHandler
    {
        public string GetRequestDeleteStudent()
        {
            return Requests_SQL.Delete(CommandName.DeleteStudent,
                                       $"@{FieldsName.StudentId} {UsingTypes_SQL.Int}",
                                       TablesName.Students,
                                       $"{FieldsName.StudentId} = @{FieldsName.StudentId}");
        }

        public string GetRequestGetStudent()
        {
            return Requests_SQL.Get($"{CommandName.GetStudent}(@{FieldsName.StudentId} {UsingTypes_SQL.Int})",
                                    TablesName.Students,
                                    $"{FieldsName.StudentId} = @{FieldsName.StudentId}");
        }

        public string GetRequestGetStudents()
        {
            return Requests_SQL.Get(CommandName.GetStudents,
                                    TablesName.Students, "1=1");
        }

        public string GetRequestInsertStudent()
        {
            return Requests_SQL.Insert(CommandName.InsertStudent,
                                       $"@{FieldsName.Name} {string.Format(UsingTypes_SQL.StringWithSize, BoundaryEntityValues.MaxLengthName)}",
                                       TablesName.Students,
                                       FieldsName.Name,
                                       $"@{FieldsName.Name}");
        }

        public string GetRequestUpdateStudent()
        {
            return Requests_SQL.Update(CommandName.UpdateStudent,
                                       $"@{FieldsName.StudentId} {UsingTypes_SQL.Int}, @{FieldsName.Name} {string.Format(UsingTypes_SQL.StringWithSize, BoundaryEntityValues.MaxLengthName)}",
                                       TablesName.Students,
                                       $"{FieldsName.Name} = @{FieldsName.Name}",
                                       $"{FieldsName.StudentId} = @{FieldsName.StudentId}");
        }
    }
}