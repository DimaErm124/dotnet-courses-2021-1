using System.Data.SqlClient;
using Values;

namespace DAL
{
    public class TableDAO_SQL : ITableDAO
    {
        private readonly string _connectionString;

        public TableDAO_SQL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void CreateTable(string tableName, string request)
        {
            if (!ExistTable(tableName))
            {
                using (SqlConnection connection = new(_connectionString))
                using (SqlCommand command = new(request, connection))
                {
                    connection.Open();

                    command.ExecuteNonQuery();
                }
            }
        }

        public bool ExistTable(string tableName)
        {
            int result;

            using (SqlConnection connection = new(_connectionString))
            using (SqlCommand command = new(string.Format(Requests_SQL.ExistTable, tableName), connection))
            {
                connection.Open();

                result = (int)command.ExecuteScalar();
            }

            return result > 0;
        }
    }
}