namespace DAL
{
    public interface IStudentRequestHandler
    {
        string GetRequestInsertStudent();

        string GetRequestUpdateStudent();

        string GetRequestDeleteStudent();

        string GetRequestGetStudents();

        string GetRequestGetStudent();
    }
}