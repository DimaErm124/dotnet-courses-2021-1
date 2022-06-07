using System.Data.OleDb;

namespace DAL
{
    public class StoredProcedureDAO_OLEDB : IStoredProcedureDAO
    {
        private readonly string _connectionString;

        public StoredProcedureDAO_OLEDB(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void CreateStoredProcedure(string request)
        {
            using (OleDbConnection connection = new(_connectionString))
            using (OleDbCommand command = new(request, connection))
            {
                connection.Open();

                command.ExecuteNonQuery();
            }
        }
    }
}