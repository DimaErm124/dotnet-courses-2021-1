using Values;

namespace DAL
{
    public class InitTablesHandler
    {
        private ITableDAO _tableDAO;

        public InitTablesHandler(ITableDAO tableDAO)
        {
            _tableDAO = tableDAO;
        }

        public void CreateAllTables()
        {
            _tableDAO.CreateTable(TablesName.Students, Requests_SQL.CreateStudentTable);
            _tableDAO.CreateTable(TablesName.Lectures,Requests_SQL.CreateLectureTable);
            _tableDAO.CreateTable(TablesName.Attendances, Requests_SQL.CreateAttendanceTable);
        }
    }
}