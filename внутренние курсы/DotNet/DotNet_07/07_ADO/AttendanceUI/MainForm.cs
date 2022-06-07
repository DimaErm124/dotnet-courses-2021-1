using BLL;
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

namespace AttendanceUI
{
    public partial class MainForm : Form
    {
        private int _studentsCounter;
        private int _lecturesCounter;
        private int _marksCounter;

        private StudentAttendanceBL _studentAttendanceBL;

        public MainForm(StudentAttendanceBL studentAttendanceBL)
        {
            InitializeComponent();

            _studentAttendanceBL = studentAttendanceBL;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {            
            InitStudentDGV();
            InitLectureDGV();
            InitAttendanceDGV();
            
            UpdateStudents();
            UpdateLectures();
            UpdateAttendance();

            StudentDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LectureDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            MarksDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void InitStudentDGV()
        {
            int index = StudentDataGridView.Columns.Add(new DataGridViewTextBoxColumn());
            StudentDataGridView.Columns[index].HeaderText = "ID";
            index = StudentDataGridView.Columns.Add(new DataGridViewTextBoxColumn());
            StudentDataGridView.Columns[index].HeaderText = "Name";
        }

        private void InitLectureDGV()
        {
            int index = LectureDataGridView.Columns.Add(new DataGridViewTextBoxColumn());
            LectureDataGridView.Columns[index].HeaderText = "ID";
            index = LectureDataGridView.Columns.Add(new DataGridViewTextBoxColumn());
            LectureDataGridView.Columns[index].HeaderText = "Topic";
            index = LectureDataGridView.Columns.Add(new DataGridViewTextBoxColumn());
            LectureDataGridView.Columns[index].HeaderText = "Lecture date";
        }

        private void InitAttendanceDGV()
        {
            int index = MarksDataGridView.Columns.Add(new DataGridViewTextBoxColumn());
            MarksDataGridView.Columns[index].HeaderText = "ID";
            index = MarksDataGridView.Columns.Add(new DataGridViewTextBoxColumn());
            MarksDataGridView.Columns[index].HeaderText = "Student";
            index = MarksDataGridView.Columns.Add(new DataGridViewTextBoxColumn());
            MarksDataGridView.Columns[index].HeaderText = "Lecture";
            index = MarksDataGridView.Columns.Add(new DataGridViewTextBoxColumn());
            MarksDataGridView.Columns[index].HeaderText = "Mark";
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (MainTabControl.SelectedTab == StudentTabPage)
            {
                AddStudentButton_Click(sender, e);
            }
            else if (MainTabControl.SelectedTab == LectureTabPage)
            {
                AddLectureButton_Click(sender, e);
            }
            else if (MainTabControl.SelectedTab == MarkTabPage)
            {
                AddAttendanceButton_Click(sender, e);
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (MainTabControl.SelectedTab == StudentTabPage)
            {
                EditStudentButton_Click(sender, e);
            }
            else if (MainTabControl.SelectedTab == LectureTabPage)
            {
                EditLectureButton_Click(sender, e);
            }
            else if (MainTabControl.SelectedTab == MarkTabPage)
            {
                EditAttendanceButton_Click(sender, e);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (MainTabControl.SelectedTab == StudentTabPage)
            {
                DeleteStudentButton_Click(sender, e);
            }
            else if (MainTabControl.SelectedTab == LectureTabPage)
            {
                DeleteLectureButton_Click(sender, e);
            }
            else if (MainTabControl.SelectedTab == MarkTabPage)
            {
                DeleteAttendanceButton_Click(sender, e);
            }
        }

        private void AddStudentButton_Click(object sender, EventArgs e)
        {
            StudentForm form = new();

            if (form.ShowDialog() == DialogResult.OK)
            {
                _studentsCounter++;

                Student user = new(_studentsCounter, form.StudentName);

                _studentAttendanceBL.AddStudent(user);

                UpdateStudents();
            }
        }

        private void AddLectureButton_Click(object sender, EventArgs e)
        {
            LectureForm form = new();

            if (form.ShowDialog() == DialogResult.OK)
            {
                _lecturesCounter++;

                Lecture lecture = new(_lecturesCounter, form.Topic, form.LectureDate);

                _studentAttendanceBL.AddLecture(lecture);

                UpdateLectures();
            }
        }

        private void AddAttendanceButton_Click(object sender, EventArgs e)
        {
            AttendanceForm form = new(_studentAttendanceBL.GetStudents().ToArray(),_studentAttendanceBL.GetLectures().ToArray());

            if (form.ShowDialog() == DialogResult.OK)
            {
                _marksCounter++;

                Attendance attendance = new(_marksCounter, form.Student, form.Lecture, form.Mark);

                _studentAttendanceBL.AddAttendance(attendance, form.Student, form.Lecture);

                UpdateAttendance();
            }
        }

        private void EditStudentButton_Click(object sender, EventArgs e)
        {
            int id = (int)StudentDataGridView.CurrentRow.Cells[0].Value;
            string name = (string)StudentDataGridView.CurrentRow.Cells[1].Value;

            Student student = new(id, name);

            if (student == null)
                return;

            StudentForm form = new(student);

            if (form.ShowDialog() == DialogResult.OK)
            {
                Student newStudent = new(student.StudentId, form.StudentName);

                _studentAttendanceBL.EditStudent(newStudent);

                UpdateStudents();
                UpdateAttendance();
            }
        }

        private void EditLectureButton_Click(object sender, EventArgs e)
        {
            int id = (int)LectureDataGridView.CurrentRow.Cells[0].Value;
            string topic = (string)LectureDataGridView.CurrentRow.Cells[1].Value;
            DateTime lectureDate = (DateTime)LectureDataGridView.CurrentRow.Cells[2].Value;

            Lecture lecture = new(id, topic, lectureDate);

            if (lecture == null)
                return;

            LectureForm form = new(lecture);

            if (form.ShowDialog() == DialogResult.OK)
            {
                Lecture newLecture = new(lecture.LectureId, form.Topic, form.LectureDate);

                _studentAttendanceBL.EditLecture(newLecture);

                UpdateLectures();
                UpdateAttendance();
            }
        }

        private void EditAttendanceButton_Click(object sender, EventArgs e)
        {
            int id = (int)MarksDataGridView.CurrentRow.Cells[0].Value;
            Student student = (Student)MarksDataGridView.CurrentRow.Cells[1].Value;
            Lecture lecture = (Lecture)MarksDataGridView.CurrentRow.Cells[2].Value;
            int mark = (int)MarksDataGridView.CurrentRow.Cells[3].Value;

            Attendance attendance = new(id, student, lecture, mark);

            if (attendance == null)
                return;

            AttendanceForm form = new(_studentAttendanceBL.GetStudents().ToArray(),_studentAttendanceBL.GetLectures().ToArray(), attendance);

            if (form.ShowDialog() == DialogResult.OK)
            {
                Attendance newAttendance = new(attendance.AttendanceId, form.Student, form.Lecture, form.Mark);

                _studentAttendanceBL.EditAttendance(newAttendance);

                UpdateAttendance();
            }
        }

        private void DeleteStudentButton_Click(object sender, EventArgs e)
        {
            int id = (int)StudentDataGridView.CurrentRow.Cells[0].Value;
            string name = (string)StudentDataGridView.CurrentRow.Cells[1].Value;

            Student student = new(id, name);

            if (student == null)
                return;

            _studentAttendanceBL.RemoveStudent(student.StudentId);

            UpdateStudents();
            UpdateAttendance();
        }

        private void DeleteLectureButton_Click(object sender, EventArgs e)
        {
            int id = (int)LectureDataGridView.CurrentRow.Cells[0].Value;
            string topic = (string)LectureDataGridView.CurrentRow.Cells[1].Value;
            DateTime lectureDate = (DateTime)LectureDataGridView.CurrentRow.Cells[2].Value;

            Lecture lecture = new(id, topic, lectureDate);

            if (lecture == null)
                return;

            _studentAttendanceBL.RemoveLecture(lecture.LectureId);

            UpdateLectures();
            UpdateAttendance();
        }

        private void DeleteAttendanceButton_Click(object sender, EventArgs e)
        {
            int id = (int)MarksDataGridView.CurrentRow.Cells[0].Value;
            Student student = (Student)MarksDataGridView.CurrentRow.Cells[1].Value;
            Lecture lecture = (Lecture)MarksDataGridView.CurrentRow.Cells[2].Value;
            int mark = (int)MarksDataGridView.CurrentRow.Cells[3].Value;

            Attendance attendance = new(id, student, lecture, mark);

            if (attendance == null)
                return;

            _studentAttendanceBL.RemoveAttendance(attendance.AttendanceId);

            UpdateAttendance();
        }

        private void UpdateStudents()
        {
            StudentDataGridView.Rows.Clear();

            List<Student> students= _studentAttendanceBL.GetStudents();

            foreach(Student student in students)
            {
                StudentDataGridView.Rows.Add(student.StudentId, student.Name);
            }
        }

        private void UpdateLectures()
        {
            LectureDataGridView.Rows.Clear();

            List<Lecture> lectures = _studentAttendanceBL.GetLectures();

            foreach (Lecture lecture in lectures)
            {
                LectureDataGridView.Rows.Add(lecture.LectureId, lecture.Topic, lecture.LectureDate);
            }
        }

        private void UpdateAttendance()
        {
            MarksDataGridView.Rows.Clear();

            List<Attendance> attendances = _studentAttendanceBL.GetAttendances();

            foreach (Attendance attendance in attendances)
            {
                MarksDataGridView.Rows.Add(attendance.AttendanceId, attendance.Student, attendance.Lecture, attendance.Mark);
            }
        }
    }
}