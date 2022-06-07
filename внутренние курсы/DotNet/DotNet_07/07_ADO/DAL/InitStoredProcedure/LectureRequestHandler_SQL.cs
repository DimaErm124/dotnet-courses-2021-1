using Values;

namespace DAL
{
    public class LectureRequestHandler_SQL : ILectureRequestHandler
    {
        public string GetRequestDeleteLecture()
        {
            return Requests_SQL.Delete(CommandName.DeleteLecture,
                                       $"@{FieldsName.LectureId} {UsingTypes_SQL.Int}",
                                       TablesName.Lectures,
                                       $"{FieldsName.LectureId} = @{FieldsName.LectureId}");
        }

        public string GetRequestGetLecture()
        {
            return Requests_SQL.Get($"{CommandName.GetLecture}(@{FieldsName.LectureId} {UsingTypes_SQL.Int})",
                                    TablesName.Lectures,
                                    $"{FieldsName.LectureId} = @{FieldsName.LectureId}");
        }

        public string GetRequestGetLectures()
        {
            return Requests_SQL.Get(CommandName.GetLectures,
                                    TablesName.Lectures,"1=1");
        }

        public string GetRequestInsertLecture()
        {
            return Requests_SQL.Insert(CommandName.InsertLecture,
                                       $"@{FieldsName.Topic} {string.Format(UsingTypes_SQL.StringWithSize, BoundaryEntityValues.MaxLengthTopic)}, @{FieldsName.LectureDate} {UsingTypes_SQL.Date}",
                                       TablesName.Lectures,
                                       $"{FieldsName.Topic},{FieldsName.LectureDate}",
                                       $"@{FieldsName.Topic},@{FieldsName.LectureDate}");
        }

        public string GetRequestUpdateLecture()
        {
            return Requests_SQL.Update(CommandName.UpdateLecture,
                                       $"@{FieldsName.LectureId} {UsingTypes_SQL.Int}, @{FieldsName.Topic} {string.Format(UsingTypes_SQL.StringWithSize, BoundaryEntityValues.MaxLengthTopic)}, @{FieldsName.LectureDate} {UsingTypes_SQL.Date}",
                                       TablesName.Lectures,
                                       $"{FieldsName.Topic} = @{FieldsName.Topic}, {FieldsName.LectureDate} = @{FieldsName.LectureDate}",
                                       $"{FieldsName.LectureId} = @{FieldsName.LectureId}");
        }
    }
}