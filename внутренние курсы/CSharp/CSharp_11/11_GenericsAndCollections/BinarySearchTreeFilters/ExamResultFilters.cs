using BinarySearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BinarySearchTreeFilters
{
    public static class ExamResultFilters
    {
        public static DateTime GetFirstExamDate(IEnumerable<ExamResult> examResults)
        {
            return examResults.OrderBy(x => x.ExamTime)
                              .First().ExamTime;
        }

        public static int GetThisYearExamCount(IEnumerable<ExamResult> examResults, int year)
        {
            return examResults.Where(x => x.ExamTime.Year == year)
                              .Count();
        }

        public static IEnumerable<ExamResult> GetFirstMaxResultExam(IEnumerable<ExamResult> examResults, int count)
        {
            return examResults.OrderByDescending(x => x.Result)
                              .Take(count).ToList();
        }

        public static IEnumerable<string> GetFullNameStudents(IEnumerable<ExamResult> examResults)
        {
            return examResults.OrderBy(x => x.Student.ToString())
                              .Select(x => x.Student.ToString())
                              .Distinct();
        }

        public static IEnumerable<Student> GetMoreThanScoreResultStudents(IEnumerable<ExamResult> examResults, int score)
        {
            return examResults.GroupBy(x => x.Student)
                              .Where(x => x.Min(r => r.Result) > score)
                              .Select(x => x.Key)
                              .OrderBy(x => x);
        }

        public static IEnumerable<ExamResult> GetCertainScoreExam(IEnumerable<ExamResult> examResults, int score)
        {
            return examResults.Where(x => x.Result == score);
        }

        public static IDictionary<Student, double> GetStudentAverageScore(IEnumerable<ExamResult> examResults)
        {
            return examResults.GroupBy(x => x.Student)
                              .ToDictionary(x => x.Key,
                                            x => x.Average(x => x.Result));
        }

        public static IEnumerable<ExamResult> GetCertainMonthYearExam(IEnumerable<ExamResult> examResults, int year, int month)
        {
            return examResults.Where(x => x.ExamTime.Year == year)
                              .Where(x => x.ExamTime.Month == month);
        }

        public static IEnumerable<string> GetNotPatternExamTitle(IEnumerable<ExamResult> examResults)
        {
            var regex = new Regex(@"^\w+-\d+$");

            return examResults.Select(x => x.Title)
                              .Where(x => !regex.Match(x).Success).Distinct();
        }

        public static IDictionary<string, string[]> GetAllExamStudents(IEnumerable<ExamResult> examResults)
        {
            return examResults.GroupBy(x => x.Student)
                              .OrderBy(x=>x.Key.ToString())
                              .ToDictionary(x => x.Key.ToString(),
                                            x => x.Select(y => y.Title).Distinct().ToArray());
        }

        public static IDictionary<Student, string[]> GetStudentsRetookExams(IEnumerable<ExamResult> examResults)
        {
            return examResults.GroupBy(x => x.Student)
                              .ToDictionary(x => x.Key,
                                            x => x.GroupBy(x => x.Title)
                                                              .Where(y => y.Count() > 1)
                                                              .Select(y => y.Key)
                                                              .Distinct()
                                                              .ToArray())
                              .Where(x => x.Value.Length > 0)
                              .ToDictionary(x => x.Key, x => x.Value);
        }

        public static IEnumerable<ExamResult> GetNotCertainYearExam(IEnumerable<ExamResult> examResults, int year)
        {
            return examResults.Where(x => x.ExamTime.Year != year);
        }
    }
}