namespace CarRental
{
    public class BaseRecorder<T> : IRecorder<T>
    {
        private readonly IFileHandler<T> _userFileHandler;

        public BaseRecorder(IFileHandler<T> userFileHandler)
        {
            _userFileHandler = userFileHandler;
        }

        public bool Add(T entity)
        {
            try
            {
                return _userFileHandler.Write(entity);
            }
            catch
            {
                return false;
            }
        }
    }
}