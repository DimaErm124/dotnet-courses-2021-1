using BinarySearch;
using FilterModel;
using SerializationHandler;
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
    public partial class MainForm : Form
    {
        private bool _savedData;
        private bool _loadedData;

        private bool _savedFilters;
        private bool _loadedFilters;

        private BindingSource _examResultSource;
        private BindingSource _studentsSource;

        private IterativeTree<ExamResult> _examResults;
        private IterativeTree<Student> _students;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _examResultSource = new BindingSource();
            _studentsSource = new BindingSource();

            _examResultSource.DataSource = _examResults;
            _studentsSource.DataSource = _students;

            ExamResultDGV.DataSource = _examResultSource;
            StudentsDGV.DataSource = _studentsSource;

            ExamResultDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            StudentsDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            StudentsDGVChecking();

            _savedData = false;
            _savedFilters = false;

            _loadedData = true;
            _loadedFilters = true;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (MainTabControl.SelectedTab == ExamResultPage)
            {
                AddExamResultButton_Click(sender, e);
            }
            else if (MainTabControl.SelectedTab == StudentTabPage)
            {
                AddStudentButton_Click(sender, e);
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (MainTabControl.SelectedTab == ExamResultPage)
            {
                EditExamResultButton_Click(sender, e);
            }
            else if (MainTabControl.SelectedTab == StudentTabPage)
            {
                EditStudentButton_Click(sender, e);
            }
        }
        
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (MainTabControl.SelectedTab == ExamResultPage)
            {
                DeleteExamResultButton_Click(sender, e);
            }
            else if (MainTabControl.SelectedTab == StudentTabPage)
            {
                DialogResult result = MessageBox.Show(
                "All exam results of this student will be deleted. Continue?",
                "Message",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.RightAlign);

                if (result == DialogResult.No)
                    return;

                DeleteStudentButton_Click(sender, e);
            }
        }

        private void AddExamResultButton_Click(object sender, EventArgs e)
        {
            ExamResultForm form = new ExamResultForm(AddButton.Text, _students.ToArray());

            if (form.ShowDialog() == DialogResult.OK)
            {
                _savedData = true;

                ExamResult examResult = new ExamResult(form.Title, form.Student, form.ExamTime, form.Result);

                AddExamResult(examResult);

                UpdateExamResult();
            }
        }
        private void EditExamResultButton_Click(object sender, EventArgs e)
        {
            ExamResult examResult = (ExamResult)_examResultSource.Current;

            if (examResult == null)
                return;

            ExamResultForm form = new ExamResultForm(EditButton.Text, _students.ToArray(), examResult);

            if (form.ShowDialog() == DialogResult.OK)
            {
                if (!_examResults.Remove(examResult))
                {
                    MessageBox.Show("Couldn't change this exam result!");
                    return;
                }

                _savedData = true;

                ExamResult newExamResult = new ExamResult(form.Title, form.Student, form.ExamTime, form.Result);

                AddExamResult(newExamResult);

                UpdateExamResult();
            }
        }
        private void AddExamResult(ExamResult newExamResult)
        {
            if (_examResults == null)
                _examResults = new IterativeTree<ExamResult>(new ExamResult[] { newExamResult });
            else
                _examResults.Add(newExamResult);
        }
        private void DeleteExamResultButton_Click(object sender, EventArgs e)
        {
            ExamResult examResult = (ExamResult)_examResultSource.Current;

            if (examResult == null)
                return;

            if (!_examResults.Remove(examResult))
            {
                MessageBox.Show("Couldn't delete this exam result!");
                return;
            }

            _savedData = true;

            UpdateExamResult();
        }

        private void AddStudentButton_Click(object sender, EventArgs e)
        {
            StudentForm form = new StudentForm(AddButton.Text);

            if (form.ShowDialog() == DialogResult.OK)
            {
                _savedData = true;

                Student student = new Student(form.FirstName, form.Surname, form.MiddleName, form.GroupNumber);

                AddStudent(student);

                UpdateStudents();
            }
        }
        private void EditStudentButton_Click(object sender, EventArgs e)
        {
            Student student = (Student)_studentsSource.Current;

            if (student == null)
                return;

            StudentForm form = new StudentForm(student, EditButton.Text);

            if (form.ShowDialog() == DialogResult.OK)
            {
                if (!_students.Remove(student))
                {
                    MessageBox.Show("Couldn't change this student!");
                    return;
                }

                _savedData = true;

                Student newStudent = new Student(form.FirstName, form.Surname, form.MiddleName, form.GroupNumber);

                EditStudentsExamResults(student, newStudent);

                AddStudent(newStudent);

                UpdateStudents();
                UpdateExamResult();
            }
        }
        private void AddStudent(Student newStudent)
        {
            if (_students == null)
                _students = new IterativeTree<Student>(new Student[] { newStudent });
            else
                _students.Add(newStudent);
        }                
        private void EditStudentsExamResults(Student student, Student newStudent)
        {
            if (_examResults != null)
                foreach (var el in _examResults)
                {
                    if (el.Student.CompareTo(student) == 0)
                    {
                        _examResults.Find(el).Data.Student = newStudent;
                    }
                }
        }                        
        private void DeleteStudentButton_Click(object sender, EventArgs e)
        {
            Student student = (Student)_studentsSource.Current;

            if (student == null)
                return;

            DeleteStudentsExamResults(student);

            if (!_students.Remove(student))
            {
                MessageBox.Show("Couldn't delete this student!");
                return;
            }

            _savedData = true;

            UpdateStudents();
            UpdateExamResult();
        }
        private void DeleteStudentsExamResults(Student student)
        {
            if (_examResults != null)
                foreach (var el in _examResults)
                {
                    if (el.Student.CompareTo(student) == 0)
                        _examResults.Remove(el);
                }
        }

        private void UpdateExamResult()
        {
            if (_examResults != null && _examResults.IsEmpty)
                _examResults = null;

            _examResultSource.DataSource = null;

            _examResultSource.DataSource = _examResults;
        }
        private void UpdateStudents()
        {
            if (_students != null && _students.IsEmpty)
                _students = null;

            _studentsSource.DataSource = null;

            _studentsSource.DataSource = _students;
        }

        private void MainTabControl_Selected(object sender, TabControlEventArgs e)
        {
            StudentsDGVChecking();
        }

        private void StudentsDGVChecking()
        {
            if (MainTabControl.SelectedTab == ExamResultPage)
            {
                if (_students == null)
                    AddButton.Enabled = false;
                else
                    AddButton.Enabled = true;
            }
            else if (MainTabControl.SelectedTab == StudentTabPage)
            {
                AddButton.Enabled = true;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_savedData || _savedFilters)
            {
                DialogResult result = MessageBox.Show(
                    "Save data changes?",
                    "Message",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);

                if (result == DialogResult.Yes)
                {
                    SaveAllData();

                    SaveAllFilters();
                }

                if (result == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveAllData();
        }
        private void SaveAllData()
        {
            if (_savedData)
            {
                _savedData = false;
                SaveData<Student>(_students);
                SaveData<ExamResult>(_examResults);
            }
        }
        private void SaveData<T>(IterativeTree<T> tree)
            where T : IComparable<T>
        {
            if (tree != null)
                XmlSerializationHandler<T>.XmlSerializeTree(tree, typeof(T).Name);
        }
        private void LoadButton_Click(object sender, EventArgs e)
        {
            if (_students != null || _examResults != null)
            {
                DialogResult result = MessageBox.Show(
                "The file data will replace the data in the table. Continue?",
                "Message",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);

                if (result != DialogResult.Yes)
                    return;
            }

            _examResults = XmlSerializationHandler<ExamResult>.XmlDeserializeTree(nameof(ExamResult));
            _students = XmlSerializationHandler<Student>.XmlDeserializeTree(nameof(Student));

            _savedData = false;

            UpdateStudents();
            UpdateExamResult();

            StudentsDGVChecking();
        }

        private void AddFiltersButton_Click(object sender, EventArgs e)
        {
            if (MainTabControl.SelectedTab == ExamResultPage)
            {
                AddExamResultFiltersButton_Click(sender, e);
            }
            else if (MainTabControl.SelectedTab == StudentTabPage)
            {
                AddStudentFiltersButton_Click(sender, e);
            }
        }
        private void AddExamResultFiltersButton_Click(object sender, EventArgs e)
        {
            FilterForm form = new FilterForm(AddButton.Text);

            if (form.ShowDialog() == DialogResult.OK)
            {
                AddExamResultFilter(form);
            }
        }
        private void AddStudentFiltersButton_Click(object sender, EventArgs e)
        {
            StudentFilterForm form = new StudentFilterForm(AddButton.Text);

            if (form.ShowDialog() == DialogResult.OK)
            {
                AddStudentFilter(form);
            }
        }
        private void AddStudentFilter(StudentFilterForm form)
        {
            if (form.UseName || form.UseSurname || form.UseMiddleName || form.UseGroupNumber)
            {
                _savedFilters = true;

                StudentFilter studentFilter = new StudentFilter(
                    form.FirstName,
                    form.UseName,
                    form.Surname,
                    form.UseSurname,
                    form.MiddleName,
                    form.UseMiddleName,
                    form.GroupNumber,
                    form.UseGroupNumber);

                StudentFiltersCheckedListBox.Items.Add(studentFilter);
            }
        }
        private void AddExamResultFilter(FilterForm form)
        {
            if (form.UseTitle || form.UseStudent || form.UseExamDate || form.UseResult)
            {
                _savedFilters = true;

                ExamResultFilter examResultFilter = new ExamResultFilter(
                    form.Title,
                    form.UseTitle,
                    form.Student,
                    form.UseStudent,
                    form.ExamDate,
                    form.UseExamDate,
                    form.Result,
                    form.UseResult);

                ExamResultFiltersCheckedListBox.Items.Add(examResultFilter);
            }
        }

        private void EditFiltersButton_Click(object sender, EventArgs e)
        {
            if (MainTabControl.SelectedTab == ExamResultPage)
            {
                EditExamResultFiltersButton_Click(sender, e);
            }
            else if (MainTabControl.SelectedTab == StudentTabPage)
            {
                EditStudentFiltersButton_Click(sender, e);
            }
        }
        private void EditExamResultFiltersButton_Click(object sender, EventArgs e)
        {
            ExamResultFilter examResultFilter = (ExamResultFilter)ExamResultFiltersCheckedListBox.SelectedItem;

            if (examResultFilter == null)
                return;

            FilterForm form = new FilterForm(EditFiltersButton.Text, examResultFilter);

            if (form.ShowDialog() == DialogResult.OK)
            {
                ExamResultFiltersCheckedListBox.Items.Remove(examResultFilter);

                AddExamResultFilter(form);
            }
        }
        private void EditStudentFiltersButton_Click(object sender, EventArgs e)
        {
            StudentFilter studentFilter = (StudentFilter)StudentFiltersCheckedListBox.SelectedItem;

            if (studentFilter == null)
                return;

            StudentFilterForm form = new StudentFilterForm(EditFiltersButton.Text, studentFilter);

            if (form.ShowDialog() == DialogResult.OK)
            {
                StudentFiltersCheckedListBox.Items.Remove(studentFilter);

                AddStudentFilter(form);
            }
        }

        private void DeleteFiltersButton_Click(object sender, EventArgs e)
        {
            if (MainTabControl.SelectedTab == ExamResultPage)
            {
                DeleteExamResultFiltersButton_Click(sender, e);
            }
            else if (MainTabControl.SelectedTab == StudentTabPage)
            {
                DeleteStudentFiltersButton_Click(sender, e);
            }
        }
        private void DeleteExamResultFiltersButton_Click(object sender, EventArgs e)
        {
            ExamResultFilter examResultFilter = (ExamResultFilter)ExamResultFiltersCheckedListBox.SelectedItem;

            if (examResultFilter == null)
                return;

            ExamResultFiltersCheckedListBox.Items.Remove(examResultFilter);

            _savedFilters = true;
        }
        private void DeleteStudentFiltersButton_Click(object sender, EventArgs e)
        {
            StudentFilter studentFilter = (StudentFilter)StudentFiltersCheckedListBox.SelectedItem;

            if (studentFilter == null)
                return;

            StudentFiltersCheckedListBox.Items.Remove(studentFilter);

            _savedFilters = true;
        }

        private void SaveAllFilters()
        {
            if (_savedFilters)
            {
                _savedFilters = false;
                SaveFilter<StudentFilter>(StudentFiltersCheckedListBox);
                SaveFilter<ExamResultFilter>(ExamResultFiltersCheckedListBox);
            }
        }
        private void SaveFiltersButton_Click(object sender, EventArgs e)
        {
            SaveAllFilters();
        }
        private static void SaveFilter<T>(CheckedListBox checkedListBox)
            where T : IComparable<T>
        {
            IterativeTree<T> tree = GetCheckedListBoxItems<T>(checkedListBox);

            if (tree != null && !tree.IsEmpty)
                XmlSerializationHandler<T>.XmlSerializeTree(tree, typeof(T).Name);
        }

        private static IterativeTree<T> GetCheckedListBoxItems<T>(CheckedListBox checkedListBox)
            where T : IComparable<T>
        {
            IterativeTree<T> tree = new IterativeTree<T>();

            foreach (var el in checkedListBox.Items)
            {
                tree.Add((T)el);
            }

            return tree;
        }

        private void LoadFiltersButton_Click(object sender, EventArgs e)
        {
            if (StudentFiltersCheckedListBox.Items.Count != 0 || ExamResultFiltersCheckedListBox.Items.Count != 0)
            {
                DialogResult result = MessageBox.Show(
                "The downloadable filters will replace filters in the table. Continue?",
                "Message",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);

                if (result != DialogResult.Yes)
                    return;
            }

            IterativeTree<ExamResultFilter> examResultFilters = XmlSerializationHandler<ExamResultFilter>.XmlDeserializeTree(nameof(ExamResultFilter));
            IterativeTree<StudentFilter> studentFilters = XmlSerializationHandler<StudentFilter>.XmlDeserializeTree(nameof(StudentFilter));

            if (examResultFilters != null)
            {
                ExamResultFiltersCheckedListBox.Items.Clear();
                ExamResultFiltersCheckedListBox.Items.AddRange(examResultFilters.ToArray());
            }


            if (studentFilters != null)
            {
                StudentFiltersCheckedListBox.Items.Clear();
                StudentFiltersCheckedListBox.Items.AddRange(studentFilters.ToArray());
            }
        }

        private void ExamResultFiltersCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (_examResults != null)
            {
                bool isChecked = e.NewValue == CheckState.Checked;
                int itemNewState = isChecked ? 1 : -1;

                if (ExamResultFiltersCheckedListBox.CheckedItems.Count + itemNewState == 0)
                {
                    UpdateExamResult();
                }
                else
                {
                    _examResultSource.DataSource = Filter<ExamResult>(_examResults, ExamResultFiltersCheckedListBox, e, isChecked);
                }
            }
        }

        private void StudentFiltersCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (_students != null)
            {
                bool isChecked = e.NewValue == CheckState.Checked;
                int itemNewState = isChecked ? 1 : -1;

                if (StudentFiltersCheckedListBox.CheckedItems.Count + itemNewState == 0)
                {
                    UpdateStudents();
                }
                else
                {
                    _studentsSource.DataSource = Filter<Student>(_students, StudentFiltersCheckedListBox, e, isChecked);                    
                }
            }
        }

        private IEnumerable<T> Filter<T>(IterativeTree<T> tree, CheckedListBox checkedListBox, ItemCheckEventArgs e, bool isChecked)
            where T : IComparable<T>
        {
            List<Filter<T>> filters = new List<Filter<T>>();
            IEnumerable<T> list = tree.ToList();

            foreach (var el in checkedListBox.CheckedItems)
                filters.Add(el as Filter<T>);

            if (isChecked)
                filters.Add(checkedListBox.Items[e.Index] as Filter<T>);
            else
                filters.Remove(checkedListBox.Items[e.Index] as Filter<T>);

            foreach (Filter<T> filter in filters)
            {
                list = filter.Apply(list).ToList();
            }
            
            return list;
        }

    }
}