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
    public partial class StudentFilterForm : Form
    {
        public string FirstName { get; set; }

        public bool UseName { get; set; }

        public string Surname { get; set; }

        public bool UseSurname { get; set; }

        public string MiddleName { get; set; }

        public bool UseMiddleName { get; set; }

        public ModelFilter<int> GroupNumber { get; set; }

        public bool UseGroupNumber { get; set; }

        public StudentFilterForm(string functionName)
        {
            InitializeComponent();

            Init();

            AddFilterButton.Text = functionName;

            Text = functionName + " new student filter";

            GroupNumber = new ModelFilter<int>();

            EqualNumberRadioButton.Checked = true;

            MinNumericUpDown.Value = MinNumericUpDown.Minimum;
            MaxNumericUpDown.Value = MaxNumericUpDown.Maximum;
        }

        public StudentFilterForm(string functionName, StudentFilter studentFilter)
        {
            InitializeComponent();

            Init();

            AddFilterButton.Text = functionName;

            Text = functionName + " " + studentFilter;

            GroupNumber = new ModelFilter<int>();

            NameCheckBox.Checked = studentFilter.UseName;
            SurnameCheckBox.Checked = studentFilter.UseSurname;
            MiddleNameCheckBox.Checked = studentFilter.UseMiddleName;
            GroupNumberCheckBox.Checked = studentFilter.UseGroupNumber;

            NameTextBox.Text = studentFilter.Name;
            SurnameTextBox.Text = studentFilter.Surname;
            MiddleNameTextBox.Text = studentFilter.MiddleName;

            if (studentFilter.GroupNumber.UseEqual)
                EqualNumberRadioButton.Checked = true;
            else
                BetweenNumberRadioButton.Checked = true;

            EqualNumericUpDown.Value = studentFilter.GroupNumber.EqualFilter;
            MinNumericUpDown.Value = studentFilter.GroupNumber.MinBorderFilter;
            MaxNumericUpDown.Value = studentFilter.GroupNumber.MaxBorderFilter;
        }

        private void Init()
        {
            EqualNumericUpDown.Minimum = InputHandlerValue.MinGroupNumber;
            EqualNumericUpDown.Maximum = InputHandlerValue.MaxGroupNumber;

            MinNumericUpDown.Minimum = InputHandlerValue.MinGroupNumber;
            MinNumericUpDown.Maximum = InputHandlerValue.MaxGroupNumber;

            MaxNumericUpDown.Minimum = InputHandlerValue.MinGroupNumber;
            MaxNumericUpDown.Maximum = InputHandlerValue.MaxGroupNumber;
        }

        private void NameCheckBox_Validated(object sender, EventArgs e)
        {
            UseName = NameCheckBox.Checked;
        }

        private void SurnameCheckBox_Validated(object sender, EventArgs e)
        {
            UseSurname = SurnameCheckBox.Checked;
        }

        private void MiddleNameCheckBox_Validated(object sender, EventArgs e)
        {
            UseMiddleName = MiddleNameCheckBox.Checked;
        }

        private void GroupNumberCheckBox_Validated(object sender, EventArgs e)
        {
            UseGroupNumber = GroupNumberCheckBox.Checked;
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

        private void NumberRadioButton_Validated(object sender, EventArgs e)
        {
            GroupNumber.UseEqual = EqualNumberRadioButton.Checked;
        }

        private void EqualNumericUpDown_Validated(object sender, EventArgs e)
        {
            GroupNumber.EqualFilter = (int)EqualNumericUpDown.Value;
        }

        private void MinNumericUpDown_Validated(object sender, EventArgs e)
        {
            GroupNumber.MinBorderFilter = (int)MinNumericUpDown.Value;
        }

        private void MaxNumericUpDown_Validated(object sender, EventArgs e)
        {
            GroupNumber.MaxBorderFilter = (int)MaxNumericUpDown.Value;
        }

        private void MinNumericUpDown_Validating(object sender, CancelEventArgs e)
        {
            if (BetweenNumberRadioButton.Checked && (MinNumericUpDown.Value > MaxNumericUpDown.Value || MinNumericUpDown.Value == MaxNumericUpDown.Value))
            {
                StudentFilterFormErrorProvider.SetError(MinNumericUpDown, ErrorStringValue.IncorrectRange);
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void MaxNumericUpDown_Validating(object sender, CancelEventArgs e)
        {

            if (BetweenNumberRadioButton.Checked && (MinNumericUpDown.Value > MaxNumericUpDown.Value || MinNumericUpDown.Value == MaxNumericUpDown.Value))
            {
                StudentFilterFormErrorProvider.SetError(MaxNumericUpDown, ErrorStringValue.IncorrectRange);
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void AddFilterButton_Click(object sender, EventArgs e)
        {
            StudentFilterFormErrorProvider.Clear();

            if (ValidateChildren())
                DialogResult = DialogResult.OK;
        }

        private void StudentFilterForm_Load(object sender, EventArgs e)
        {
        }

        private void NameTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (NameCheckBox.Checked && NameTextBox.Text == string.Empty)
            {
                StudentFilterFormErrorProvider.SetError(NameTextBox, ErrorStringValue.Empty);
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void SurnameTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (SurnameCheckBox.Checked && SurnameTextBox.Text == string.Empty)
            {
                StudentFilterFormErrorProvider.SetError(SurnameTextBox, ErrorStringValue.Empty);
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void MiddleNameTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (MiddleNameCheckBox.Checked && MiddleNameTextBox.Text == string.Empty)
            {
                StudentFilterFormErrorProvider.SetError(MiddleNameTextBox, ErrorStringValue.Empty);
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }
    }
}