using ImageDownloader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageDownloaderUI
{
    public partial class ImageDownloaderForm : Form
    {
        private Downloader _downloader;

        private string _fileName;

        public ImageDownloaderForm()
        {
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            _downloader = new Downloader();

            _downloader.OnDownloadStarted += Downloader_OnDownloadStarted;
            _downloader.OnDownloadProgressChanged += Downloader_OnDownloadProgressChanged;
            _downloader.OnDownloadImageCompleted += Downloader_OnDownloadImageCompleted;
        }

        private void Downloader_OnDownloadImageCompleted(Exception error, bool cancelled)
        {
            if (cancelled)
            {
                MessageBox.Show("Image download cancelled.");
            }
            else if (error != null)
            {
                MessageBox.Show(error.ToString());
            }
            else
            {
                PictureBox.Image = Image.FromFile(_fileName);
                FileInfoLabel.Text = string.Format("Width: {0}; Heigth: {1}", PictureBox.Image.Width, PictureBox.Image.Height);
                MessageBox.Show("Complete!");
            }

            DownloadButton.Enabled = true;
            ClearButton.Enabled = true;
            ProgressBar.Value = 0;
        }

        private void Downloader_OnDownloadProgressChanged(long? totalFileSize, long totalBytesDownloaded, double? progressPercentage)
        {
            ProgressBar.Value = (int)progressPercentage;
        }

        private async void Downloader_OnDownloadStarted(HttpWebResponse response)
        {
            string type = FormatType(response.ContentType);

            _fileName = response.ResponseUri.Segments[response.ResponseUri.Segments.Length - 1] + "." + type;

            ImageInfoLabel.Text = string.Format("Type: {0}; Length: {1}", type, response.ContentLength);
            ClearButton.Enabled = false;
            DownloadButton.Enabled = false;

            await _downloader.DownloadImage(URLTextBox.Text, _fileName);
        }

        private static string FormatType(string type)
        {
            return type[(type.IndexOf('/') + 1)..];
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            Clear();

            try
            {
                _downloader.GetResponse(URLTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            _downloader.Cancel();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            Clear();
            URLTextBox.Text = string.Empty;
        }

        private void Clear()
        {
            Init();

            if (PictureBox.Image != null)
            {
                PictureBox.Image.Dispose();
                PictureBox.Image = null;
            }
            ImageInfoLabel.Text = string.Empty;
            FileInfoLabel.Text = string.Empty;
        }

        private void URLTextBox_Enter(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.BeginInvoke(new Action(textBox.SelectAll));
        }
    }
}