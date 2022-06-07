using Downloader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DownloaderUI
{
    public partial class DownloaderForm : Form
    {
        private int _total;
        private int _inQueue;
        private int _inProgress;
        private int _completed;
        private int _error;

        private ToolStripLabel _totalLabel;
        private ToolStripLabel _inQueueLabel;
        private ToolStripLabel _inProgressLabel;
        private ToolStripLabel _completedLabel;
        private ToolStripLabel _errorLabel;

        private const string TextHelper = "  press ENTER after input";

        private Dictionary<string, FileDownloader> _downloaders;

        public DownloaderForm()
        {
            InitializeComponent();

            InitDataGridView();

            Init();

            InitStatusStrip();
        }

        private void InitDataGridView()
        {
            int index = FilesDataGridView.Columns.Add(new DataGridViewTextBoxColumn());
            FilesDataGridView.Columns[index].HeaderText = "File";
            index = FilesDataGridView.Columns.Add(new DataGridViewTextBoxColumn());
            FilesDataGridView.Columns[index].HeaderText = "Status";
            index = FilesDataGridView.Columns.Add(new DataGridViewTextBoxColumn());
            FilesDataGridView.Columns[index].HeaderText = "File size";
            index = FilesDataGridView.Columns.Add(new DataGridViewProgressColumn());
            FilesDataGridView.Columns[index].HeaderText = "Progress";
            index = FilesDataGridView.Columns.Add(new DataGridViewTextBoxColumn());
            FilesDataGridView.Columns[index].HeaderText = "Url";
        }

        private void InitStatusStrip()
        {
            _totalLabel = new ToolStripLabel();
            _completedLabel = new ToolStripLabel();
            _inProgressLabel = new ToolStripLabel();
            _inQueueLabel = new ToolStripLabel();
            _errorLabel = new ToolStripLabel();

            StatusStrip.Items.Add(_totalLabel);
            StatusStrip.Items.Add(_completedLabel);
            StatusStrip.Items.Add(_inProgressLabel);
            StatusStrip.Items.Add(_inQueueLabel);
            StatusStrip.Items.Add(_errorLabel);

            StatusStrip.ForeColor = Color.White;
        }

        private void Init()
        {
            _downloaders = new();
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(URLTextBox.Text) || URLTextBox.Text == TextHelper)
            {
                MessageBox.Show("URL shouldn`t be empty!");
                return;
            }

            if (string.IsNullOrEmpty(FileNameTextBox.Text))
            {
                MessageBox.Show("File name shouldn`t be empty!");
                return;
            }

            if (File.Exists(FileNameTextBox.Text))
            {
                MessageBox.Show("File with this name already exist!");
                return;
            }

            try
            {
                FileDownloader downloader = new();

                downloader.OnDownloadStarted += Downloader_OnDownloadStarted;
                downloader.OnDownloadProgressChanged += Downloader_OnDownloadProgressChanged;
                downloader.OnDownloadImageCompleted += Downloader_OnDownloadImageCompleted;

                _downloaders.Add(FileNameTextBox.Text, downloader);
                
                _total++;
                _inQueue++;

                UpdateStatusStrip();

                downloader.GetResponse(URLTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Downloader_OnDownloadImageCompleted(Exception exception, string fileName)
        {
            if (exception != null)
            {
                foreach (DataGridViewRow row in FilesDataGridView.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(fileName))
                    {
                        row.Cells[1].Value = DownloadStatus.Error;
                        _error++;
                    }
                }
                MessageBox.Show(exception.ToString());
            }
            else
            {
                foreach (DataGridViewRow row in FilesDataGridView.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(fileName))
                    {
                        row.Cells[1].Value = DownloadStatus.Completed;
                        _completed++;
                    }
                }
            }

            _inProgress--;
            UpdateStatusStrip();
        }

        private void Downloader_OnDownloadProgressChanged(double progressPercentage, string fileName)
        {
            foreach (DataGridViewRow row in FilesDataGridView.Rows)
            {
                if (row.Cells[0].Value.ToString().Equals(fileName))
                {
                    row.Cells[1].Value = DownloadStatus.InProgress;
                    row.Cells[3].Value = (int)progressPercentage;
                }
            }
        }

        private async void Downloader_OnDownloadStarted(long length)
        {
            FilesDataGridView.Rows.Add(FileNameTextBox.Text, DownloadStatus.InQueue, GetFileSizeString(length), 0, URLTextBox.Text);

            _inQueue--;
            _inProgress++;

            UpdateStatusStrip();

            if (_downloaders.TryGetValue(FileNameTextBox.Text, out FileDownloader downloader))
            {
                await downloader.DownFile(URLTextBox.Text, FileNameTextBox.Text, length);
            }
        }

        private string GetFileSizeString(long length)
        {
            string result;
            int count = 0;

            while (length > 1000)
            {
                length /= 1024;
                count++;
            }

            switch (count)
            {
                case 0:
                    result = length.ToString() + " B";
                    break;
                case 1:
                    result = length.ToString() + " KB";
                    break;
                case 2:
                    result = length.ToString() + " MB";
                    break;
                case 3:
                    result = length.ToString() + " GB";
                    break;
                default:
                    result = length.ToString();
                    break;
            }

            return result;
        }

        private string GetFileName(string text)
        {
            string[] strs = text.Split('/');

            return strs[strs.Length - 1];
        }

        private void UpdateStatusStrip()
        {
            _totalLabel.Text = (_total > 0) ? string.Format("Total: {0}", _total) : string.Empty;
            _completedLabel.Text = (_completed > 0) ? string.Format("Completed: {0}", _completed) : string.Empty;
            _inProgressLabel.Text = (_inProgress > 0) ? string.Format("In Progress: {0}", _inProgress) : string.Empty;
            _inQueueLabel.Text = (_inQueue > 0) ? string.Format("In Queue: {0}", _inQueue) : string.Empty;
            _errorLabel.Text = (_error > 0) ? string.Format("Error: {0}", _error) : string.Empty;
        }

        private void URLTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (sender is TextBox textBox)
                {
                    FileNameTextBox.Text = GetFileName(textBox.Text);
                }
            }
        }

        private void URLHelp()
        {
            if (string.IsNullOrEmpty(URLTextBox.Text))
            {
                URLTextBox.Text = TextHelper;
                URLTextBox.ForeColor = Color.Gray;
                URLTextBox.Font = new Font(URLTextBox.Font, URLTextBox.Font.Style | FontStyle.Italic);
            }
        }

        private void DownloaderForm_Load(object sender, EventArgs e)
        {
            URLHelp();
        }

        private void URLTextBox_Enter(object sender, EventArgs e)
        {
            if (URLTextBox.Text == TextHelper)
            {
                URLTextBox.Text = null;
                URLTextBox.ForeColor = Color.Black;
                URLTextBox.Font = new Font(URLTextBox.Font, URLTextBox.Font.Style ^ FontStyle.Italic);
            }

            TextBox textBox = sender as TextBox;
            textBox.BeginInvoke(new Action(textBox.SelectAll));
        }

        private void URLTextBox_Leave(object sender, EventArgs e)
        {
            URLHelp();
        }
    }
}