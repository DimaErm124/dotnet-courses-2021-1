using System.Data.OleDb;
using Values;

namespace DAL
{
    public class TableDAO_OLEDB : ITableDAO
    {
        private readonly string _connectionString;

        public TableDAO_OLEDB(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void CreateTable(string tableName, string request)
        {
            if (!ExistTable(tableName))
            {
                using (OleDbConnection connection = new(_connectionString))
                using (OleDbCommand command = new(request, connection))
                {
                    connection.Open();

                    command.ExecuteNonQuery();
                }
            }
        }

        public bool ExistTable(string tableName)
        {
            int result;

            using (OleDbConnection connection = new(_connectionString))
            using (OleDbCommand command = new(string.Format(Requests_SQL.ExistTable, tableName), connection))
            {
                connection.Open();

                result = (int)command.ExecuteScalar();
            }

            return result > 0;
        }
    }
}