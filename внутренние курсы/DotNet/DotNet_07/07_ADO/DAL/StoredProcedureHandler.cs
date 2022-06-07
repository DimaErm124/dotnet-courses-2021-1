namespace DAL
{
    public class StoredProcedureHandler
    {
        private IStoredProcedureDAO _storedProcedureDAO;

        private IStudentRequestHandler _studentRequestHandler;

        private ILectureRequestHandler _lectureRequestHandler;

        private IAttendanceRequestHandler _attendanceRequestHandler;

        public StoredProcedureHandler(IStoredProcedureDAO storedProcedureDAO,
                                      IStudentRequestHandler studentRequestHandler,
                                      ILectureRequestHandler lectureRequestHandler,
                                      IAttendanceRequestHandler attendanceRequestHandler)
        {
            _storedProcedureDAO = storedProcedureDAO;

            _studentRequestHandler = studentRequestHandler;
            _lectureRequestHandler = lectureRequestHandler;
            _attendanceRequestHandler = attendanceRequestHandler;
        }

        public void CreateStudentTableProcedure()
        {
            _storedProcedureDAO.CreateStoredProcedure(_studentRequestHandler.GetRequestInsertStudent());
            _storedProcedureDAO.CreateStoredProcedure(_studentRequestHandler.GetRequestUpdateStudent());
            _storedProcedureDAO.CreateStoredProcedure(_studentRequestHandler.GetRequestDeleteStudent());
            _storedProcedureDAO.CreateStoredProcedure(_studentRequestHandler.GetRequestGetStudents());
            _storedProcedureDAO.CreateStoredProcedure(_studentRequestHandler.GetRequestGetStudent());
        }

        public void CreateLectureTableProcedure()
        {
            _storedProcedureDAO.CreateStoredProcedure(_lectureRequestHandler.GetRequestInsertLecture());
            _storedProcedureDAO.CreateStoredProcedure(_lectureRequestHandler.GetRequestUpdateLecture());
            _storedProcedureDAO.CreateStoredProcedure(_lectureRequestHandler.GetRequestDeleteLecture());
            _storedProcedureDAO.CreateStoredProcedure(_lectureRequestHandler.GetRequestGetLectures());
            _storedProcedureDAO.CreateStoredProcedure(_lectureRequestHandler.GetRequestGetLecture());
        }

        public void CreateAttendanceTableProcedure()
        {
            _storedProcedureDAO.CreateStoredProcedure(_attendanceRequestHandler.GetRequestInsertAttendance());
            _storedProcedureDAO.CreateStoredProcedure(_attendanceRequestHandler.GetRequestUpdateAttendance());
            _storedProcedureDAO.CreateStoredProcedure(_attendanceRequestHandler.GetRequestDeleteAttendance());
            _storedProcedureDAO.CreateStoredProcedure(_attendanceRequestHandler.GetRequestGetMarks());
            _storedProcedureDAO.CreateStoredProcedure(_attendanceRequestHandler.GetRequestDeleteAttendanceOfStudent());
            _storedProcedureDAO.CreateStoredProcedure(_attendanceRequestHandler.GetRequestDeleteAttendanceOfLecture());
        }

        public void CreateAllProcedure()
        {
            CreateStudentTableProcedure();
            CreateLectureTableProcedure();
            CreateAttendanceTableProcedure();
        }
    }
}