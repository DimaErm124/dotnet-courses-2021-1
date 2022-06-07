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
    public partial class StudentForm : Form
    {
        public string StudentName { get; set; }

        public StudentForm()
        {
            InitializeComponent();

            StudentButton.Text = "Add";

            Text = "Add new user";
        }

        public StudentForm(Student student)
        {
            InitializeComponent();

            StudentNameTextBox.Text = student.Name;

            StudentButton.Text = "Edit";

            Text = "Edit " + student;
        }

        private void StudentButton_Click(object sender, EventArgs e)
        {
            StudentErrorProvider.Clear();

            if (ValidateChildren())
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void StudentNameTextBox_Validated(object sender, EventArgs e)
        {
            StudentName = StudentNameTextBox.Text;
        }

        private void StudentNameTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(StudentNameTextBox.Text)
                || string.IsNullOrWhiteSpace(StudentNameTextBox.Text))
            {
                StudentErrorProvider.SetError(StudentNameTextBox, "empty!");
                e.Cancel = true;
            }
            else if (StudentNameTextBox.Text.Length >= BoundaryEntityValues.MaxLengthName)
            {
                StudentErrorProvider.SetError(StudentNameTextBox, "Size more than " + BoundaryEntityValues.MaxLengthName);
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }
    }
}