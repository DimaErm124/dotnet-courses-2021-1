using System.Data.OleDb;
using Values;

namespace DAL
{
    public class DBDAO_OLEDB : IDBDAO
    {
        private readonly string _connectionString;

        public DBDAO_OLEDB(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool ExistDB()
        {
            int result;

            using (OleDbConnection connection = new(_connectionString))
            using (OleDbCommand command = new(Requests_SQL.ExistDB, connection))
            {
                connection.Open();

                result = (int)command.ExecuteScalar();
            }

            return result > 0;
        }

        public void CreateDB()
        {
            if (!ExistDB())
            {
                using (OleDbConnection connection = new(_connectionString))
                using (OleDbCommand command = new(Requests_SQL.CreateDB, connection))
                {
                    connection.Open();

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}