using System.Data;
using System.Data.SqlClient;
using Values;

namespace DAL
{
    public class DBDAO_SQL : IDBDAO
    {
        private readonly string _connectionString;

        public DBDAO_SQL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool ExistDB()
        {
            int result;

            using (SqlConnection connection = new(_connectionString))
            using (SqlCommand command = new(Requests_SQL.ExistDB, connection))
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
                using (SqlConnection connection = new(_connectionString))
                using (SqlCommand command = new(Requests_SQL.CreateDB, connection))
                {
                    connection.Open();

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}