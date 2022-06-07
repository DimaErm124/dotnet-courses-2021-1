using BinarySearch;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilterModel
{
    [Serializable]
    public class ExamResultFilter: Filter<ExamResult>, IComparable<ExamResultFilter>, IEquatable<ExamResultFilter>
    {
        public string Title { get; set; }

        public bool UseTitle { get; set; }

        public StudentFilter Student { get; set; }

        public bool UseStudent { get; set; }

        public ModelFilter<DateTime> ExamDate { get; set; }

        public bool UseExamDate { get; set; }

        public ModelFilter<int> Result { get; set; }

        public bool UseResult { get; set; }

        public ExamResultFilter()
        {
        }

        public ExamResultFilter(string title, bool useTitle, StudentFilter student, bool useStudent, ModelFilter<DateTime> examDate, bool useExamDate, ModelFilter<int> result, bool useResult)
        {
            Title = title;
            UseTitle = useTitle;
            Student = student;
            UseStudent = useStudent;
            ExamDate = examDate;
            UseExamDate = useExamDate;
            Result = result;
            UseResult = useResult;
        }

        public override IEnumerable<ExamResult> Apply(IEnumerable<ExamResult> examResults)
        {
            if (UseTitle)
                examResults = examResults.Where(x => x.Title.Contains(Title));

            if (UseStudent)
                if (Student != null)
                    examResults = UsingStudentFilter(examResults);

            if (UseExamDate)
                if (ExamDate.UseEqual)
                    examResults = examResults.Where(x => x.ExamTime.Day == ExamDate.EqualFilter.Day&& x.ExamTime.Month == ExamDate.EqualFilter.Month&& x.ExamTime.Year == ExamDate.EqualFilter.Year);
                else
                    examResults = examResults.Where(x => x.ExamTime > ExamDate.MinBorderFilter && x.ExamTime < ExamDate.MaxBorderFilter);

            if (UseResult)
                if (Result.UseEqual)
                    examResults = examResults.Where(x => x.Result == Result.EqualFilter);
                else
                    examResults = examResults.Where(x => x.Result > Result.MinBorderFilter && x.Result < Result.MaxBorderFilter);

            return examResults;
        }

        private IEnumerable<ExamResult> UsingStudentFilter(IEnumerable<ExamResult> examResults)
        {
            if (Student.UseName)
                examResults = examResults.Where(x => x.Student.Name.Contains(Student.Name));

            if (Student.UseSurname)
                examResults = examResults.Where(x => x.Student.Surname.Contains(Student.Surname));

            if (Student.UseMiddleName)
                examResults = examResults.Where(x => x.Student.MiddleName.Contains(Student.MiddleName));

            if(Student.UseGroupNumber)
                if (Student.GroupNumber.UseEqual)
                    examResults = examResults.Where(x => x.Student.GroupNumber == Student.GroupNumber.EqualFilter);
                else
                    examResults = examResults.Where(x => x.Student.GroupNumber > Student.GroupNumber.MinBorderFilter && x.Student.GroupNumber < Student.GroupNumber.MaxBorderFilter);

            return examResults;
        }

        public int CompareTo(ExamResultFilter other)
        {
            if (other == null)
                throw new ArgumentNullException();

            if (UseTitle.CompareTo(other.UseTitle) == 0)
                if (Title.CompareTo(other.Title) == 0)
                    if (UseStudent.CompareTo(other.UseStudent) == 0)
                        if (Student.CompareTo(other.Student) == 0)
                            if (UseExamDate.CompareTo(other.UseExamDate) == 0)
                                if (ExamDate.CompareTo(other.ExamDate) == 0)
                                    if (UseResult.CompareTo(other.UseResult) == 0)
                                        if (Result.CompareTo(other.Result) == 0)
                                            return 0;
                                        else
                                            return Result.CompareTo(other.Result);
                                    else
                                        return UseResult.CompareTo(other.UseResult);
                                else
                                    return ExamDate.CompareTo(other.ExamDate);
                            else
                                return UseExamDate.CompareTo(other.UseExamDate);
                        else
                            return Student.CompareTo(other.Student);
                    else
                        return UseStudent.CompareTo(other.UseStudent);
                else
                    return Title.CompareTo(other.Title);
            else
                return UseTitle.CompareTo(other.UseTitle);
        }

        public bool Equals(ExamResultFilter other)
        {
            if (other == null)
                return false;

            if (CompareTo(other) != 0)
                return false;

            return true;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ExamResultFilter);
        }

        public override string ToString()
        {
            string returningString = "{";

            if (UseTitle)
                returningString += Title;

            returningString += ";";

            if (UseStudent)
                returningString += Student.ToString();

            returningString += ";";

            if (UseExamDate)
                returningString += ExamDate.ToString();

            returningString += ";";

            if (UseResult)
                returningString += Result.ToString();

            return returningString + "}";
        }
    }
}