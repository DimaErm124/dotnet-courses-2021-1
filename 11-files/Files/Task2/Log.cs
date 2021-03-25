using System.IO;

namespace Task2
{
    public class Log
    {
        private string _catalog;

        private string _catalogBackUp;

        private string _pattern;

        public Log(string catalog, string pattern)
        {
            _catalog = catalog;
            _catalogBackUp = _catalog + @"\Log\";
            _pattern = pattern;
            
            Directory.CreateDirectory(_catalogBackUp);
        }

        public bool Push()
        {
            try
            {
                var fileNames = Directory.GetFiles(_catalog, _pattern, SearchOption.AllDirectories);

                foreach (var el in fileNames)
                {
                    byte[] bytes;

                    string logFileName = GetFileName(el.Replace(Path.GetFileName(el), ""), '\\', '_');

                    using (var fileStream = new FileStream(el, FileMode.Open))
                    {
                        bytes = new byte[fileStream.Length];
                        fileStream.Read(bytes, 0, bytes.Length);
                    }

                    using (var fileStream = new FileStream(_catalogBackUp + logFileName + Path.GetFileName(el).Replace(".txt", ".log"), FileMode.Create))
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

        public bool Pull()
        {
            try
            {
                var fileNames = Directory.GetFiles(_catalogBackUp, "*.log", SearchOption.AllDirectories);

                foreach (var el in fileNames)
                {
                    byte[] bytes;

                    string fileName = "C:\\" + Path.GetFileName(el).Replace('_', '\\');
                    fileName = fileName.Replace(".log", ".txt");

                    using (var fileStream = new FileStream(el, FileMode.Open))
                    {
                        bytes = new byte[fileStream.Length];
                        fileStream.Read(bytes, 0, bytes.Length);
                    }

                    using (var fileStream = new FileStream(fileName, FileMode.Open))
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

        private string GetFileName(string fileName, char spliter, char jumper)
        {
            var logFileNameArray = fileName.Split(spliter);

            string logFileName = string.Empty;
            for (int i = 1; i < logFileNameArray.Length; i++) 
            {
                logFileName += logFileNameArray[i] + jumper;
            }

            return logFileName;
        }
    }
}
