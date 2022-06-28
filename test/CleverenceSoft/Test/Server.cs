using System;
using System.Threading;

namespace Test
{
    public static class Server
    {
        private static int _count;

        private static ReaderWriterLockSlim _rwLock = new();

        public static int GetCount()
        {
            _rwLock.EnterReadLock();
            try
            {
                return _count;
            }
            finally
            {
                _rwLock.ExitReadLock();
            }
        }

        public static void AddToCount(int value)
        {
            _rwLock.EnterWriteLock();
            try
            {
                _count += value;
            }
            finally
            {
                _rwLock.ExitWriteLock();
            }
        }
    }

    public class AsyncCaller
    {
        private EventHandler _handler;
        private Thread thread;

        public AsyncCaller(EventHandler handler)
        {
            _handler = handler;
        }

        private void Aborter(IAsyncResult ar)
        {
            thread.Abort();
        }

        private void SpinWait(object timeout)
        {
            Thread.Sleep((int)timeout);
        }

        public bool Invoke(int timeout, object sender, EventArgs e)
        {
            thread = new(SpinWait);

            IAsyncResult asyncResult = _handler?.BeginInvoke(sender, e, Aborter, this);

            thread.Start(timeout);
            thread.Join();
            thread = null;

            return asyncResult.IsCompleted;
        }
    }
}
