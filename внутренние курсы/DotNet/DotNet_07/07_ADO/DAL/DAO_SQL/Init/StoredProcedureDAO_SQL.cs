using System.Data.SqlClient;

namespace DAL
{
    public class StoredProcedureDAO_SQL : IStoredProcedureDAO
    {
        private readonly string _connectionString;

        public StoredProcedureDAO_SQL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void CreateStoredProcedure(string request)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(request, connection))
            {
                connection.Open();

                command.ExecuteNonQuery();
            }
        }
    }
}