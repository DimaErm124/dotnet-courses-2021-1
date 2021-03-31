using System;
using System.IO;

namespace Task2
{
    public class Logger
    {
        private Log _log;

        private FileSystemWatcher _watcher;

        public Logger(string catalog, string pattern)
        {
            _log = new Log(catalog, pattern);

            WatcherInit(catalog, pattern);
        }

        private void WatcherInit(string catalog, string pattern)
        {
            _watcher = new FileSystemWatcher(catalog);

            _watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName;
            _watcher.IncludeSubdirectories = true;

            _watcher.Changed += _watcher_Changed;
            _watcher.Deleted += _watcher_Changed;
            _watcher.Filter = pattern;
        }

        public void LogEnable(bool enable)
        {
            _watcher.EnableRaisingEvents = enable;
        }

        public void Pull(DateTime dateTime)
        {
            _log.Pull(dateTime);
        }

        private void _watcher_Changed(object sender, FileSystemEventArgs e)
        {
            _log.Push();
        }
    }
}
