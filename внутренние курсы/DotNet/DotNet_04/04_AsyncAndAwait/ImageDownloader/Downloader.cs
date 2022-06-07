using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ImageDownloader
{
    public class Downloader
    {
        private static string[] _knownImageHeaders = new[] { "image/jpg", "image/jpeg", "image/x-png", "image/png", };

        private bool _isMoreToRead = true;

        private bool _cancelled = false;

        public delegate void HttpWebResponseEventHandler(HttpWebResponse response);

        public delegate void AsyncCompletedImageEventHandler(Exception exception, bool cancelled);

        public delegate void ProgressChangedHandler(long? totalFileSize, long totalBytesDownloaded, double? progressPercentage);

        public event HttpWebResponseEventHandler OnDownloadStarted;

        public event AsyncCompletedImageEventHandler OnDownloadImageCompleted;

        public event ProgressChangedHandler OnDownloadProgressChanged;

        public async Task DownloadImage(string url, string fileName)
        {
            HttpClient httpClient = new HttpClient();

            using (var response = await httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
                await DownloadFileFromHttpResponseMessage(response, fileName);

            OnDownloadImageCompleted(null, _cancelled);
        }

        private async Task DownloadFileFromHttpResponseMessage(HttpResponseMessage response, string fileName)
        {
            long? totalBytes = response.Content.Headers.ContentLength;

            using (var contentStream = await response.Content.ReadAsStreamAsync())
                await ProcessContentStream(totalBytes, contentStream, fileName);
        }

        private async Task ProcessContentStream(long? totalDownloadSize, Stream contentStream, string fileName)
        {   
            long totalBytesRead = 0L;
            int onePart = (int)totalDownloadSize / 100;
            byte[] buffer = new byte[onePart];
            int bytesRead;

            using FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None, onePart, true);
            do
            {
                bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length);
                
                if (bytesRead == 0)
                {
                    _isMoreToRead = false;
                    TriggerProgressChanged(totalDownloadSize, totalBytesRead);
                    continue;
                }

                await fileStream.WriteAsync(buffer, 0, bytesRead);

                totalBytesRead += bytesRead;

                TriggerProgressChanged(totalDownloadSize, totalBytesRead);
            }
            while (_isMoreToRead);
        }

        private void TriggerProgressChanged(long? totalDownloadSize, long totalBytesRead)
        {
            if (OnDownloadProgressChanged == null)
                return;

            int? progressPercentage = null;
            if (totalDownloadSize.HasValue)
                progressPercentage = (int)Math.Round((double)totalBytesRead / totalDownloadSize.Value * 100);

            OnDownloadProgressChanged(totalDownloadSize, totalBytesRead, progressPercentage);
        }

        public void GetResponse(string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new Exception("URL is empty");

            WebRequest request = null;
            HttpWebResponse response = null;

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

            if (!Array.Exists(_knownImageHeaders, x => x == response.ContentType))
                    throw new Exception("No pictures");
            
            OnDownloadStarted(response);
        }

        public void Cancel()
        {
            _isMoreToRead = false;
            _cancelled = true;
        }

        private string GetFormatType(string type)
        {
            return "." + type[(type.IndexOf('/') + 1)..];
        }
    }
}