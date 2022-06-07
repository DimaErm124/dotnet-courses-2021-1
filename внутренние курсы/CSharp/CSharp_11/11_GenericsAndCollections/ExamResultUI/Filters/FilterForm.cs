using DataHandler;
using FilterModel;
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
    public partial class FilterForm : Form
    {
        private readonly string _addStudentFilterName = "add student filter";

        private readonly string _editStudentFilterName = "edit student filter";

        public string Title { get; set; }

        public bool UseTitle { get; set; }

        public StudentFilter Student { get; set; }

        public bool UseStudent { get; set; }

        public ModelFilter<DateTime> ExamDate { get; set; }

        public bool UseExamDate { get; set; }

        public ModelFilter<int> Result { get; set; }

        public bool UseResult { get; set; }

        public FilterForm(string functionName)
        {
            InitializeComponent();

            Init();

            AddFilterButton.Text = functionName;

            Text = functionName + " new exam result filter";

            Student = new StudentFilter() { Name = string.Empty, Surname = string.Empty, MiddleName = string.Empty, GroupNumber = new ModelFilter<int>() };
            ExamDate = new ModelFilter<DateTime>();
            Result = new ModelFilter<int>();

            StudentFilterLabel.Text = string.Empty;
            AddStudentFilterButton.Text = _addStudentFilterName;

            EqualDateRadioButton.Checked = true;
            EqualNumberRadioButton.Checked = true;

            MinDateTimePicker.Value = MinDateTimePicker.MaxDate;
            //MaxDateTimePicker.Value = DateTime.Now;

            MinNumericUpDown.Value = MinNumericUpDown.Minimum;
            MaxNumericUpDown.Value = MaxNumericUpDown.Maximum;
        }

        public FilterForm(string functionName, ExamResultFilter examResultFilter)
        {
            InitializeComponent();

            Init();

            AddFilterButton.Text = functionName;

            Text = functionName + " " + examResultFilter;

            Student = new StudentFilter();
            ExamDate = new ModelFilter<DateTime>();
            Result = new ModelFilter<int>();

            TitleCheckBox.Checked = examResultFilter.UseTitle;
            StudentCheckBox.Checked = examResultFilter.UseStudent;
            ExamDateCheckBox.Checked = examResultFilter.UseExamDate;
            ResultCheckBox.Checked = examResultFilter.UseResult;

            TitleTextBox.Text = examResultFilter.Title;

            if (!examResultFilter.Student.IsEmpty)
            {
                Student = examResultFilter.Student;
                StudentFilterLabel.Text = Student.ToString();
                AddStudentFilterButton.Text = _editStudentFilterName;
            }
            else
            {
                StudentFilterLabel.Text = string.Empty;
                AddStudentFilterButton.Text = _addStudentFilterName;
            }

            if (examResultFilter.ExamDate.UseEqual)
                EqualDateRadioButton.Checked = true;
            else
                BetweenDateRadioButton.Checked = true;

            EqualDateTimePicker.Value = examResultFilter.ExamDate.EqualFilter;
            MinDateTimePicker.Value = examResultFilter.ExamDate.MinBorderFilter;
            MaxDateTimePicker.Value = examResultFilter.ExamDate.MaxBorderFilter;

            if (examResultFilter.Result.UseEqual)
                EqualNumberRadioButton.Checked = true;
            else
                BetweenNumberRadioButton.Checked = true;

            EqualNumericUpDown.Value = examResultFilter.Result.EqualFilter;
            MinNumericUpDown.Value = examResultFilter.Result.MinBorderFilter;
            MaxNumericUpDown.Value = examResultFilter.Result.MaxBorderFilter;
        }

        private void Init()
        {
            DateTime today = DateTime.Today;

            EqualDateTimePicker.MaxDate = today;
            MinDateTimePicker.MaxDate = today;
            MaxDateTimePicker.MaxDate = today;

            EqualNumericUpDown.Minimum = InputHandlerValue.MinResult;
            EqualNumericUpDown.Maximum = InputHandlerValue.MaxResult;

            MinNumericUpDown.Minimum = InputHandlerValue.MinResult;
            MinNumericUpDown.Maximum = InputHandlerValue.MaxResult;

            MaxNumericUpDown.Minimum = InputHandlerValue.MinResult;
            MaxNumericUpDown.Maximum = InputHandlerValue.MaxResult;
        }

        private void TitleCheckBox_Validated(object sender, EventArgs e)
        {
            UseTitle = TitleCheckBox.Checked;
        }

        private void StudentCheckBox_Validated(object sender, EventArgs e)
        {
            UseStudent = StudentCheckBox.Checked;
        }

        private void ExamDateCheckBox_Validated(object sender, EventArgs e)
        {
            UseExamDate = ExamDateCheckBox.Checked;
        }

        private void ResultCheckBox_Validated(object sender, EventArgs e)
        {
            UseResult = ResultCheckBox.Checked;
        }

        private void TitleTextBox_Validated(object sender, EventArgs e)
        {
            Title = TitleTextBox.Text;
        }

        private void EqualDateRadioButton_Validated(object sender, EventArgs e)
        {
            ExamDate.UseEqual = EqualDateRadioButton.Checked;
        }

        private void EqualDateTimePicker_Validated(object sender, EventArgs e)
        {
            ExamDate.EqualFilter = EqualDateTimePicker.Value;
        }

        private void MinDateTimePicker_Validated(object sender, EventArgs e)
        {
            ExamDate.MinBorderFilter = MinDateTimePicker.Value;
        }

        private void MaxDateTimePicker_Validated(object sender, EventArgs e)
        {
            ExamDate.MaxBorderFilter = MaxDateTimePicker.Value;
        }

        private void EqualNumberRadioButton_Validated(object sender, EventArgs e)
        {
            Result.UseEqual = EqualNumberRadioButton.Checked;
        }

        private void EqualNumericUpDown_Validated(object sender, EventArgs e)
        {
            Result.EqualFilter = (int)EqualNumericUpDown.Value;
        }

        private void MinNumericUpDown_Validated(object sender, EventArgs e)
        {
            Result.MinBorderFilter = (int)MinNumericUpDown.Value;
        }

        private void MaxNumericUpDown_Validated(object sender, EventArgs e)
        {
            Result.MaxBorderFilter = (int)MaxNumericUpDown.Value;
        }

        private void MinDateTimePicker_Validating(object sender, CancelEventArgs e)
        {
            FilterFormErrorProvider.Clear();

            if (BetweenDateRadioButton.Checked && (MinDateTimePicker.Value > MaxDateTimePicker.Value|| MinDateTimePicker.Value == MaxDateTimePicker.Value))
            {
                FilterFormErrorProvider.SetError(MinDateTimePicker, ErrorStringValue.IncorrectRange);
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void MaxDateTimePicker_Validating(object sender, CancelEventArgs e)
        {
            FilterFormErrorProvider.Clear();

            if (BetweenDateRadioButton.Checked && (MinDateTimePicker.Value > MaxDateTimePicker.Value || MinDateTimePicker.Value == MaxDateTimePicker.Value))
            {
                FilterFormErrorProvider.SetError(MaxDateTimePicker, ErrorStringValue.IncorrectRange);
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void MinNumericUpDown_Validating(object sender, CancelEventArgs e)
        {
            FilterFormErrorProvider.Clear();

            if (BetweenNumberRadioButton.Checked && (MinNumericUpDown.Value > MaxNumericUpDown.Value || MinNumericUpDown.Value == MaxNumericUpDown.Value))
            {
                FilterFormErrorProvider.SetError(MinNumericUpDown, ErrorStringValue.IncorrectRange);
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void MaxNumericUpDown_Validating(object sender, CancelEventArgs e)
        {
            FilterFormErrorProvider.Clear();

            if (BetweenNumberRadioButton.Checked && (MinNumericUpDown.Value > MaxNumericUpDown.Value || MinNumericUpDown.Value == MaxNumericUpDown.Value))
            {
                FilterFormErrorProvider.SetError(MaxNumericUpDown, ErrorStringValue.IncorrectRange);
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void StudentFilterButton_Click(object sender, EventArgs e)
        {
            if (AddStudentFilterButton.Text == _addStudentFilterName)
            {
                AddStudentFilterButton_Click(sender, e);
            }
            else
            {
                EditStudentFilterButton_Click(sender, e);
            }
        }

        private void AddStudentFilterButton_Click(object sender, EventArgs e)
        {
            StudentFilterForm form = new StudentFilterForm("Add");

            AddStudentFilter(form);
        }

        private void EditStudentFilterButton_Click(object sender, EventArgs e)
        {
            StudentFilterForm form = new StudentFilterForm("Edit", Student);

            AddStudentFilter(form);
        }

        private void AddStudentFilter(StudentFilterForm form)
        {
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.UseName || form.UseSurname || form.UseMiddleName || form.UseGroupNumber)
                {
                    StudentFilter studentFilter = new StudentFilter(form.FirstName, form.UseName, form.Surname, form.UseSurname, form.MiddleName, form.UseMiddleName, form.GroupNumber, form.UseGroupNumber);

                    Student = studentFilter;

                    StudentFilterLabel.Text = studentFilter.ToString();

                    AddStudentFilterButton.Text = _editStudentFilterName;
                }
                else
                {
                    Student = new StudentFilter();

                    StudentFilterLabel.Text = string.Empty;

                    AddStudentFilterButton.Text = _addStudentFilterName;
                }
            }
        }

        private void AddFilterButton_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
                DialogResult = DialogResult.OK;
        }

        private void FilterForm_Load(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;

            EqualDateTimePicker.MaxDate = today;
            MinDateTimePicker.MaxDate = today;
            MaxDateTimePicker.MaxDate = today;

            EqualNumericUpDown.Minimum = InputHandlerValue.MinResult;
            EqualNumericUpDown.Maximum = InputHandlerValue.MaxResult;

            MinNumericUpDown.Minimum = InputHandlerValue.MinResult;
            MinNumericUpDown.Maximum = InputHandlerValue.MaxResult;

            MaxNumericUpDown.Minimum = InputHandlerValue.MinResult;
            MaxNumericUpDown.Maximum = InputHandlerValue.MaxResult;
        }
    }
}