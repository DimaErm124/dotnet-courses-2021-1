using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Downloader
{
    public class FileDownloader
    {
        private double _progress;

        public delegate void HttpWebResponseEventHandler(long length);

        public delegate void AsyncCompletedImageEventHandler(Exception exception, string fileName);

        public delegate void ProgressChangedHandler(double progressPercentage, string fileName);

        public event HttpWebResponseEventHandler OnDownloadStarted;

        public event AsyncCompletedImageEventHandler OnDownloadImageCompleted;

        public event ProgressChangedHandler OnDownloadProgressChanged;

        private long GetPart(long fileSize)
        {
            long part;

            if (fileSize < DownloaderValues._512KB)
                part = fileSize;
            else
                part = DownloaderValues._512KB;

            while (fileSize / part > DownloaderValues.MaxCountOfParts)
                part *= 2;

            return part;
        }

        public async Task DownFile(string url, string fileName, long fileSize)
        {
            long from;
            long to;

            long part = GetPart(fileSize);
            long parts = fileSize / part;
            long partRemainder = fileSize % part;

            if (partRemainder > 0)
                parts++;

            try
            {
                for (int i = 0; i < parts; i++)
                {
                    if (i == parts - 1)
                    {
                        from = i * partRemainder + i;
                        to = from + partRemainder;
                    }
                    else
                    {
                        from = i * part + i;
                        to = from + part;
                    }

                    await ThreadDownFile(url, fileName, fileSize, from, to);
                }
                
                OnDownloadImageCompleted(null, fileName);
            }
            catch(Exception e)
            {
                OnDownloadImageCompleted(e, fileName);
            }
        }

        public async Task ThreadDownFile(string url, string fileName, long fileSize, long from, long to)
        {
            bool isMoreToRead = true;
            
            int newByte = DownloaderValues._512KB;
            byte[] inBuf = new byte[newByte];
            int bytesReadTotal = 0;
            int bytesRead;
            
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.AddRange(from, to);

            WebResponse response = request.GetResponse();

            using (Stream str = response.GetResponseStream())
            {
                using (FileStream fstr = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    fstr.Position = fstr.Length;
                    isMoreToRead = true;

                    do
                    {
                        bytesRead = await str.ReadAsync(inBuf, 0, newByte);
                        if (bytesRead == 0)
                        {
                            isMoreToRead = false;
                            TriggerProgressChanged(fileSize, bytesRead, fileName);
                            continue;
                        }

                        await fstr.WriteAsync(inBuf, 0, bytesRead);

                        bytesReadTotal += bytesRead;

                        TriggerProgressChanged(fileSize, bytesRead, fileName);
                    }
                    while (isMoreToRead);
                }
            }
        }

        private void TriggerProgressChanged(long? totalDownloadSize, long bytesRead, string fileName)
        {
            if (OnDownloadProgressChanged == null)
                return;

            double progressPercentage;
            if (totalDownloadSize.HasValue)
            {
                progressPercentage = (double)bytesRead / totalDownloadSize.Value * 100;
                _progress += progressPercentage;
            }

            OnDownloadProgressChanged(_progress, fileName);
        }

        public void GetResponse(string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new Exception("URL is empty");

            WebRequest request;
            HttpWebResponse response;

            try
            {
                request = WebRequest.Create(url);
                request.Method = "HEAD";
            }
            catch
            {
                throw new Exception("Invalid URL");
            }

            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch
            {
                throw new Exception("No web files");
            }

            OnDownloadStarted(response.ContentLength);
        }

        private string GetFormatType(string type)
        {
            return "." + type[(type.IndexOf('/') + 1)..];
        }

    }
}