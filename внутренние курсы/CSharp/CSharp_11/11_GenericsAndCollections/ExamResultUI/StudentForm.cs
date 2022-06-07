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
    public partial class StudentForm : Form
    {
        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string MiddleName { get; set; }

        public int GroupNumber { get; set; }

        public StudentForm(string functionName)
        {
            InitializeComponent();

            CreateStudentButton.Text = functionName;

            Text = functionName + " new student";
        }

        public StudentForm(Student student, string functionName)
        {
            InitializeComponent();

            CreateStudentButton.Text = functionName;

            Text = functionName + " " + student;

            NameTextBox.Text = student.Name;
            SurnameTextBox.Text = student.Surname;
            MiddleNameTextBox.Text = student.MiddleName;
            GroupNumberTextBox.Text = student.GroupNumber.ToString();
        }

        private void CreateStudentButton_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
                DialogResult = DialogResult.OK;
        }

        private void NameTextBox_Validated(object sender, EventArgs e)
        {
            FirstName = NameTextBox.Text;
        }

        private void SurnameTextBox_Validated(object sender, EventArgs e)
        {
            Surname = SurnameTextBox.Text;
        }

        private void MiddleNameTextBox_Validated(object sender, EventArgs e)
        {
            MiddleName = MiddleNameTextBox.Text;
        }

        private void GroupNumberTextBox_Validated(object sender, EventArgs e)
        {
            if (int.TryParse(GroupNumberTextBox.Text, out int result))
                GroupNumber = result;
        }

        private void NameTextBox_Validating(object sender, CancelEventArgs e)
        {
            StudentErrorProvider.Clear();

            if (string.IsNullOrEmpty(NameTextBox.Text))
            {
                StudentErrorProvider.SetError(NameTextBox, ErrorStringValue.Empty);
                e.Cancel = true;
            }
            else if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                StudentErrorProvider.SetError(NameTextBox, ErrorStringValue.Whitespace);
                e.Cancel = true;
            }
            else if (NameTextBox.Text.Length >= InputHandlerValue.MaxLengthName)
            {
                StudentErrorProvider.SetError(NameTextBox, ErrorStringValue.Length + InputHandlerValue.MaxLengthName);
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void SurnameTextBox_Validating(object sender, CancelEventArgs e)
        {
            StudentErrorProvider.Clear();

            if (string.IsNullOrEmpty(SurnameTextBox.Text))
            {
                StudentErrorProvider.SetError(SurnameTextBox, ErrorStringValue.Empty);
                e.Cancel = true;
            }
            else if (string.IsNullOrWhiteSpace(SurnameTextBox.Text))
            {
                StudentErrorProvider.SetError(SurnameTextBox, ErrorStringValue.Whitespace);
                e.Cancel = true;
            }
            else if (SurnameTextBox.Text.Length >= InputHandlerValue.MaxLengthSurname)
            {
                StudentErrorProvider.SetError(SurnameTextBox, ErrorStringValue.Length + InputHandlerValue.MaxLengthSurname);
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void MiddleNameTextBox_Validating(object sender, CancelEventArgs e)
        {
            StudentErrorProvider.Clear();

            if (string.IsNullOrEmpty(MiddleNameTextBox.Text))
            {
                StudentErrorProvider.SetError(MiddleNameTextBox, ErrorStringValue.Empty);
                e.Cancel = true;
            }
            else if (string.IsNullOrWhiteSpace(MiddleNameTextBox.Text))
            {
                StudentErrorProvider.SetError(MiddleNameTextBox, ErrorStringValue.Whitespace);
                e.Cancel = true;
            }
            else if (MiddleNameTextBox.Text.Length >= InputHandlerValue.MaxLengthMiddleName)
            {
                StudentErrorProvider.SetError(MiddleNameTextBox, ErrorStringValue.Length + InputHandlerValue.MaxLengthMiddleName);
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void GroupNumberTextBox_Validating(object sender, CancelEventArgs e)
        {
            StudentErrorProvider.Clear();

            if (string.IsNullOrEmpty(GroupNumberTextBox.Text))
            {
                StudentErrorProvider.SetError(GroupNumberTextBox, ErrorStringValue.Empty);
                e.Cancel = true;
            }
            else if (string.IsNullOrWhiteSpace(GroupNumberTextBox.Text))
            {
                StudentErrorProvider.SetError(GroupNumberTextBox, ErrorStringValue.Whitespace);
                e.Cancel = true;
            }
            else if (GroupNumberTextBox.Text.Length != InputHandlerValue.GroupNumberLength)
            {
                StudentErrorProvider.SetError(GroupNumberTextBox, ErrorStringValue.GroupNumber);
                e.Cancel = true;
            }
            else if (!int.TryParse(GroupNumberTextBox.Text, out _))
            {
                StudentErrorProvider.SetError(MiddleNameTextBox, ErrorStringValue.NotIntegerNumber);
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }
    }
}