using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Values;

namespace AttendanceUI
{
    public partial class LectureForm : Form
    {
        public string Topic { get; set; }

        public DateTime LectureDate { get; set; }

        public LectureForm()
        {
            InitializeComponent();

            LectureButton.Text = "Add";

            Text = "Add new lecture";
        }

        public LectureForm(Lecture lecture)
        {
            InitializeComponent();

            TopicTextBox.Text = lecture.Topic;

            LectureDateTimePicker.Value = lecture.LectureDate;

            LectureButton.Text = "Edit";

            Text = "Edit " + lecture;
        }

        private void LectureForm_Load(object sender, EventArgs e)
        {
            LectureDateTimePicker.MaxDate = DateTime.Now;
        }

        private void LectureButton_Click(object sender, EventArgs e)
        {
            LectureErrorProvider.Clear();

            if (ValidateChildren())
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void TopicTextBox_Validated(object sender, EventArgs e)
        {
            Topic = TopicTextBox.Text;
        }

        private void LectureDateTimePicker_Validated(object sender, EventArgs e)
        {
            LectureDate = LectureDateTimePicker.Value;
        }

        private void TopicTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TopicTextBox.Text)
                || string.IsNullOrWhiteSpace(TopicTextBox.Text))
            {
                LectureErrorProvider.SetError(TopicTextBox, "Empty!");
                e.Cancel = true;
            }
            else if (TopicTextBox.Text.Length >= BoundaryEntityValues.MaxLengthTopic)
            {
                LectureErrorProvider.SetError(TopicTextBox, "Size more than " + BoundaryEntityValues.MaxLengthTopic);
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void LectureDateTimePicker_Validating(object sender, CancelEventArgs e)
        {
            if (LectureDateTimePicker.Value > DateTime.Now)
            {
                LectureErrorProvider.SetError(LectureDateTimePicker, "More than now!");
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }
    }
}