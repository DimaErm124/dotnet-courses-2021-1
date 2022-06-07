namespace DAL
{
    public interface ILectureRequestHandler
    {
        string GetRequestInsertLecture();

        string GetRequestUpdateLecture();

        string GetRequestDeleteLecture();

        string GetRequestGetLectures();

        string GetRequestGetLecture();
    }
}