using BLL;
using DAL;
using DAL.EF_SQL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AttendanceUI
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IDBDAO dBDAO = null;

            InitTablesHandler initTablesHandler = null;

            StoredProcedureHandler storedProcedureHandler = null;


            IStudentDAO studentDAO;

            ILectureDAO lectureDAO;

            IAttendanceDAO attendanceDAO;

            string context = (ConfigurationManager.AppSettings["context"]).ToString();

            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            string masterConnectionString = ConfigurationManager.ConnectionStrings["MasterConnectionString"].ConnectionString;

            switch (context)
            {
                case "SQL":
                    dBDAO = new DBDAO_SQL(masterConnectionString);
                    initTablesHandler = new InitTablesHandler(new TableDAO_SQL(connectionString));
                    storedProcedureHandler = new StoredProcedureHandler(new StoredProcedureDAO_SQL(connectionString),
                                                                        new StudentRequestHandler_SQL(),
                                                                        new LectureRequestHandler_SQL(),
                                                                        new AttendanceRequestHandler_SQL());
                    Init(dBDAO, initTablesHandler, storedProcedureHandler);
                    studentDAO = new StudentDAO_SQL(connectionString);
                    lectureDAO = new LectureDAO_SQL(connectionString);
                    attendanceDAO = new AttendanceDAO_SQL(connectionString);
                    break;
                case "OLEDB":
                    dBDAO = new DBDAO_OLEDB(masterConnectionString);
                    initTablesHandler = new InitTablesHandler(new TableDAO_OLEDB(connectionString));
                    storedProcedureHandler = new StoredProcedureHandler(new StoredProcedureDAO_OLEDB(connectionString),
                                                    new StudentRequestHandler_SQL(),
                                                    new LectureRequestHandler_SQL(),
                                                    new AttendanceRequestHandler_SQL());
                    Init(dBDAO, initTablesHandler, storedProcedureHandler);
                    studentDAO = new StudentDAO_OLEDB(connectionString);
                    lectureDAO = new LectureDAO_OLEDB(connectionString);
                    attendanceDAO = new AttendanceDAO_OLEDB(connectionString);
                    break;
                default:
                    studentDAO = new StudentDAO_EF_SQL(connectionString);
                    lectureDAO = new LectureDAO_EF_SQL(connectionString);
                    attendanceDAO = new AttendanceDAO_EF_SQL(connectionString);
                    break;
            }

            StudentAttendanceBL bl = new StudentAttendanceBL(studentDAO, lectureDAO, attendanceDAO);

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(bl));
        }

        private static void Init(IDBDAO dBDAO, InitTablesHandler initTablesHandler, StoredProcedureHandler storedProcedureHandler)
        {
            dBDAO.CreateDB();

            initTablesHandler.CreateAllTables();

            storedProcedureHandler.CreateAllProcedure();
        }
    }
}