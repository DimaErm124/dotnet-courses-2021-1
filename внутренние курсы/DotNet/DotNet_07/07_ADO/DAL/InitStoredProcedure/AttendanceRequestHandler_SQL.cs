using Values;

namespace DAL
{
    public class AttendanceRequestHandler_SQL : IAttendanceRequestHandler
    {
        public string GetRequestDeleteAttendance()
        {
            return Requests_SQL.Delete(CommandName.DeleteAttendance,
                                       $"@{FieldsName.AttendanceId} {UsingTypes_SQL.Int}",
                                       TablesName.Attendances,
                                       $"{FieldsName.AttendanceId} = @{FieldsName.AttendanceId}");
        }

        public string GetRequestDeleteAttendanceOfLecture()
        {
            return Requests_SQL.Delete(CommandName.DeleteAttendanceOfLecture,
                                       $"@{FieldsName.LectureId} {UsingTypes_SQL.Int}",
                                       TablesName.Attendances,
                                       $"{FieldsName.LectureId} = @{FieldsName.LectureId}");
        }

        public string GetRequestDeleteAttendanceOfStudent()
        {
            return Requests_SQL.Delete(CommandName.DeleteAttendanceOfStudent,
                                       $"@{FieldsName.StudentId} {UsingTypes_SQL.Int}",
                                       TablesName.Attendances,
                                       $"{FieldsName.StudentId} = @{FieldsName.StudentId}");
        }

        public string GetRequestGetMark()
        {
            return Requests_SQL.Get($"{CommandName.GetMark}(@{FieldsName.AttendanceId} {UsingTypes_SQL.Int})",
                                    TablesName.Attendances,
                                    $"{FieldsName.AttendanceId} = @{FieldsName.AttendanceId}");
        }

        public string GetRequestGetMarks()
        {
            return Requests_SQL.Get(CommandName.GetMarks,
                                    TablesName.Attendances,"1=1");
        }

        public string GetRequestInsertAttendance()
        {
            return Requests_SQL.Insert(CommandName.InsertAttendance,
                                       $"@{FieldsName.StudentId} {UsingTypes_SQL.Int}, @{FieldsName.LectureId} {UsingTypes_SQL.Int}, @{FieldsName.Mark} {UsingTypes_SQL.Int}",
                                       TablesName.Attendances,
                                       $"{FieldsName.StudentId},{FieldsName.LectureId},{FieldsName.Mark}",
                                       $"@{FieldsName.StudentId},@{FieldsName.LectureId},@{FieldsName.Mark}");
        }

        public string GetRequestUpdateAttendance()
        {
            return Requests_SQL.Update(CommandName.UpdateAttendance,
                                       $"@{FieldsName.AttendanceId} {UsingTypes_SQL.Int}, @{FieldsName.StudentId} {UsingTypes_SQL.Int}, @{FieldsName.LectureId} {UsingTypes_SQL.Int}, @{FieldsName.Mark} {UsingTypes_SQL.Int}",
                                       TablesName.Attendances,
                                       $"{FieldsName.StudentId} = @{FieldsName.StudentId}, {FieldsName.LectureId} = @{FieldsName.LectureId}, {FieldsName.Mark} = @{FieldsName.Mark}",
                                       $"{FieldsName.AttendanceId} = @{FieldsName.AttendanceId}");
        }
    }
}