namespace DAL
{
    public interface ITableDAO
    {
        void CreateTable(string tableName, string request);

        bool ExistTable(string tableName);
    }
}