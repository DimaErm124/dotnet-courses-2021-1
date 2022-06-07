using System.Threading;

namespace ModelWithSynchronousProperty
{
    public class ShareResHandler
    {
        private string _shareRes;

        private ReaderWriterLockSlim _rwLock;

        private Logger _logger;

        public string ShareRes
        {
            get
            {
                return GetShareRes();
            }
            set
            {
                SetShareRes(value);
            }
        }

        public ShareResHandler(ReaderWriterLockSlim readerWriterLockSlim, Logger logger)
        {
            _rwLock = readerWriterLockSlim;
            _logger = logger;
        }

        private string GetShareRes()
        {
            _logger.Add("Start read method");
            _logger.Add("Try enter read lock");
            _rwLock.EnterReadLock();
            try
            {
                _logger.Add("Enter read lock");
                Thread.Sleep(500);
                return _shareRes;
            }
            finally
            {
                _rwLock.ExitReadLock();
                _logger.Add("Exit read lock");
                _logger.Add("Finish read method");
            }
        }

        private void SetShareRes(string value)
        {
            _logger.Add("Start write method");
            _logger.Add("Try enter write lock");
            _rwLock.EnterWriteLock();
            try
            {
                _logger.Add("Enter write lock");
                Thread.Sleep(3000);
                _shareRes = value;
            }
            finally
            {
                _rwLock.ExitWriteLock();
                _logger.Add("Exit write lock");
                _logger.Add("Finish write method");
            }
        }
    }
}
