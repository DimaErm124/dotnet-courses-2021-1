using System;
using System.IO;

namespace Task2
{
    public class Log
    {
        private string _catalog;

        private string _catalogBackUp;

        private string _extension;

        private string _extensionLog;

        private string _pattern;

        private string _patternLog;

        public Log(string catalog, string pattern, string patternLog = "*.log", string logCatalogName = @"\Log\")
        {
            _extension = Path.GetExtension(pattern);
            _extensionLog = Path.GetExtension(patternLog);

            _pattern = pattern;
            _patternLog = patternLog;

            _catalog = catalog;
            _catalogBackUp = _catalog + logCatalogName;

            Directory.CreateDirectory(_catalogBackUp);
        }

        public bool Push()
        {
            try
            {
                var fileNames = Directory.GetFiles(_catalog, _pattern, SearchOption.AllDirectories);

                var catalogOnDateTime = _catalogBackUp
                    + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + "\\";

                Directory.CreateDirectory(catalogOnDateTime);

                foreach (var el in fileNames)
                {
                    byte[] bytes;

                    string logFileNameWithoutRoot = el.Replace(Directory.GetDirectoryRoot(el), "");
                    string logFileName = logFileNameWithoutRoot.Replace("\\", "_");

                    using (var fileStream = new FileStream(el, FileMode.Open))
                    {
                        bytes = new byte[fileStream.Length];
                        fileStream.Read(bytes, 0, bytes.Length);
                    }

                    using (var fileStream = new FileStream(catalogOnDateTime + logFileName.Replace(_extension, _extensionLog), FileMode.Create))
                    {
                        fileStream.Write(bytes, 0, bytes.Length);
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Pull(DateTime dateTime)
        {
            try
            {
                ClearCatalog();

                var fileNames = Directory.GetFiles(_catalogBackUp, _patternLog, SearchOption.AllDirectories);

                foreach (var el in fileNames)
                {
                    var info = new FileInfo(el);

                    if (!CompareFileDateTime(dateTime, info.LastWriteTime))
                        continue;                    

                    byte[] bytes;

                    string fileName = Directory.GetDirectoryRoot(el) + Path.GetFileName(el).Replace('_', '\\');

                    using (var fileStream = new FileStream(el, FileMode.Open))
                    {
                        bytes = new byte[fileStream.Length];
                        fileStream.Read(bytes, 0, bytes.Length);
                    }

                    Directory.CreateDirectory(Path.GetDirectoryName(fileName));

                    using (var fileStream = new FileStream(fileName.Replace(_extensionLog, _extension), FileMode.Create))
                    {
                        fileStream.Position = 0;
                        fileStream.Write(bytes, 0, bytes.Length);
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        private void ClearCatalog()
        {
            var catalogs = Directory.GetDirectories(_catalog);

            foreach (var el in catalogs) 
            {
                if (el != Path.GetDirectoryName(_catalogBackUp))
                {
                    Directory.Delete(el, true);
                }
            }

            var files = Directory.GetFiles(_catalog, _pattern, SearchOption.AllDirectories);

            foreach (var el in files) 
            {
                File.Delete(el);
            }

        }

        private bool CompareFileDateTime(DateTime dateTime1, DateTime dateTime2)
        {
            return new DateTime(dateTime1.Year, dateTime1.Month, dateTime1.Day, dateTime1.Hour, dateTime1.Minute, 0)
                == new DateTime(dateTime2.Year, dateTime2.Month, dateTime2.Day, dateTime2.Hour, dateTime2.Minute, 0);
        }
    }
}
