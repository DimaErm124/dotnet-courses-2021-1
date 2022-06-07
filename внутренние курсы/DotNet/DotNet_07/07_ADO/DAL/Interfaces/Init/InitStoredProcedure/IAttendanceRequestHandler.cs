namespace DAL
{
    public interface IAttendanceRequestHandler
    {
        string GetRequestInsertAttendance();

        string GetRequestUpdateAttendance();

        string GetRequestDeleteAttendanceOfStudent();

        string GetRequestDeleteAttendanceOfLecture();

        string GetRequestDeleteAttendance();

        string GetRequestGetMarks();

        string GetRequestGetMark();
    }
}