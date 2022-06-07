using BinarySearch;
using DataHandler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamResultUI
{
    public partial class ExamResultForm : Form
    {
        public string Title { get; set; }

        public Student Student { get; set; }

        public DateTime ExamTime { get; set; }

        public int Result { get; set; }

        public ExamResultForm(string functionName, object[] students)
        {
            InitializeComponent();

            CreateExamResultButton.Text = functionName;

            Text = functionName + " new exam result";

            StudentsComboBox.Items.AddRange(students);
        }

        public ExamResultForm(string functionName, object[] students, ExamResult examResult)
        {
            InitializeComponent();

            CreateExamResultButton.Text = functionName;

            Text = functionName + " " + examResult;

            StudentsComboBox.Items.AddRange(students);

            TitleTextBox.Text = examResult.Title;
            ExamDateTimePicker.Value = examResult.ExamTime;
            ResultNumericUpDown.Value = examResult.Result;
            StudentsComboBox.SelectedItem = examResult.Student;
        }

        private void ExamResultForm_Load(object sender, EventArgs e)
        {
            ExamDateTimePicker.MaxDate = DateTime.Now;

            ResultNumericUpDown.Minimum = InputHandlerValue.MinResult;
            ResultNumericUpDown.Maximum = InputHandlerValue.MaxResult;
        }

        private void CreateExamResultButton_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
                DialogResult = DialogResult.OK;
        }

        private void TitleTextBox_Validated(object sender, EventArgs e)
        {
            Title = TitleTextBox.Text;
        }

        private void ExamDateTimePicker_Validated(object sender, EventArgs e)
        {
            ExamTime = ExamDateTimePicker.Value;
        }

        private void ResultNumericUpDown_Validated(object sender, EventArgs e)
        {
            Result = (int)ResultNumericUpDown.Value;
        }
        
        private void StudentsComboBox_Validated(object sender, EventArgs e)
        {
            Student = (Student)StudentsComboBox.SelectedItem;
        }

        private void TitleTextBox_Validating(object sender, CancelEventArgs e)
        {
            ExamResultErrorProvider.Clear();

            if (string.IsNullOrEmpty(TitleTextBox.Text))
            {
                ExamResultErrorProvider.SetError(TitleTextBox, ErrorStringValue.Empty);
                e.Cancel = true;
            }
            else if (string.IsNullOrWhiteSpace(TitleTextBox.Text))
            {
                ExamResultErrorProvider.SetError(TitleTextBox, ErrorStringValue.Whitespace);
                e.Cancel = true;
            }
            else if (TitleTextBox.Text.Length >= InputHandlerValue.MaxLengthName)
            {
                ExamResultErrorProvider.SetError(TitleTextBox, ErrorStringValue.Length + InputHandlerValue.MaxLengthName);
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void ExamDateTimePicker_Validating(object sender, CancelEventArgs e)
        {
            ExamResultErrorProvider.Clear();

            if (ExamDateTimePicker.Value > DateTime.Now)
            {
                ExamResultErrorProvider.SetError(ExamDateTimePicker, ErrorStringValue.Date);
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void ResultNumericUpDown_Validating(object sender, CancelEventArgs e)
        {
            ExamResultErrorProvider.Clear();

            if (ResultNumericUpDown.Value > InputHandlerValue.MaxResult
                || ResultNumericUpDown.Value < InputHandlerValue.MinResult)
            {
                ExamResultErrorProvider.SetError(ResultNumericUpDown, ErrorStringValue.OutOfRange);
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void StudentsComboBox_Validating(object sender, CancelEventArgs e)
        {
            ExamResultErrorProvider.Clear();

            if (StudentsComboBox.SelectedItem == null)
            {
                ExamResultErrorProvider.SetError(StudentsComboBox, ErrorStringValue.Empty);
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }
    }
}