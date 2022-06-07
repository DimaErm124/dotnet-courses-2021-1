using System;
using System.IO;
using System.Threading;

namespace ModelWithSynchronousProperty
{
    public class Logger
    {
        private string _path;

        private object _threadLock = new object();

        public Logger()
        {
            _path = PathName() + ".txt";
        }

        public void Add(string log)
        {
            lock (_threadLock)
            {
                SaveInFile(FormatAdd(log));
            }
        }

        private string FormatAdd(string log)
        {
            DateTime now = DateTime.Now;
            return string.Format("[{0}] [{1}] {2}", now.ToString("yy/MM/dd HH:mm:ss.fff"), Thread.CurrentThread.ManagedThreadId, log);
        }

        private string PathName()
        {
            DateTime now = DateTime.Now;
            return nameof(Logger) + '_' + now.ToString("dd.mm.yyyy-HH/mm/ss");
        }

        private void SaveInFile(string text)
        {
            using (StreamWriter writer = new StreamWriter(_path, true))
            {
                writer.WriteLine(text);
            }
        }
    }
}
