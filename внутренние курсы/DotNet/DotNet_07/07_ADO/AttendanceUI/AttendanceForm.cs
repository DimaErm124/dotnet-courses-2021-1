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
    public partial class AttendanceForm : Form
    {
        public Student Student { get; set; }

        public Lecture Lecture { get; set; }

        public int Mark { get; set; }

        public AttendanceForm(object[] students, object[] lectures)
        {
            InitializeComponent();

            StudentComboBox.Items.AddRange(students);
            LectureComboBox.Items.AddRange(lectures);

            AttendanceButton.Text = "Add";

            Text = "Add new lecture";
        }

        public AttendanceForm(object[] students, object[] lectures, Attendance attendance)
        {
            InitializeComponent();

            StudentComboBox.Items.AddRange(students);
            LectureComboBox.Items.AddRange(lectures);

            StudentComboBox.SelectedIndex = StudentComboBox.FindString(attendance.Student.ToString());
            LectureComboBox.SelectedIndex = LectureComboBox.FindString(attendance.Lecture.ToString());

            MarkNumericUpDown.Value = attendance.Mark;

            AttendanceButton.Text = "Edit";

            Text = "Edit " + attendance;
        }

        private void AttendanceButton_Click(object sender, EventArgs e)
        {
            AttendanceErrorProvider.Clear();

            if (ValidateChildren())
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void StudentComboBox_Validated(object sender, EventArgs e)
        {
            Student = (Student)StudentComboBox.SelectedItem;
        }

        private void LectureComboBox_Validated(object sender, EventArgs e)
        {
            Lecture = (Lecture)LectureComboBox.SelectedItem;
        }

        private void MarkNumericUpDown_Validated(object sender, EventArgs e)
        {
            Mark = (int)MarkNumericUpDown.Value;
        }

        private void StudentComboBox_Validating(object sender, CancelEventArgs e)
        {
            if (StudentComboBox.SelectedItem == null)
            {
                AttendanceErrorProvider.SetError(StudentComboBox, "empty!");
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void LectureComboBox_Validating(object sender, CancelEventArgs e)
        {
            if (LectureComboBox.SelectedItem == null)
            {
                AttendanceErrorProvider.SetError(LectureComboBox, "empty!");
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void MarkNumericUpDown_Validating(object sender, CancelEventArgs e)
        {
            if (MarkNumericUpDown.Value <= 0)
            {
                AttendanceErrorProvider.SetError(MarkNumericUpDown, "less or equal zero!");
                e.Cancel = true;
            }
            else if (MarkNumericUpDown.Value > BoundaryEntityValues.MaxMarkValue)
            {
                AttendanceErrorProvider.SetError(MarkNumericUpDown, $"more than {BoundaryEntityValues.MaxMarkValue}!");
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void AttendanceForm_Load(object sender, EventArgs e)
        {
            MarkNumericUpDown.Maximum = BoundaryEntityValues.MaxMarkValue;
        }
    }
}