using BinarySearch;
using BinarySearchTreeFilters;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BinarySearchTreeFiltersTests
{
    public class ExamResultFiltersTests
    {
        private static readonly ExamResult[] _examResults =
        {
            new ExamResult("HTML-300",new Student("Dmitriy","Ermakov","Sergeevich",643),new DateTime(2017,9,4),4),
            new ExamResult("HTML-300",new Student("Sam","Johnson","Pots",345),new DateTime(2021,9,4),4),
            new ExamResult("HTML-300",new Student("Dmitriy","Ermakov","Sergeevich",643),new DateTime(2021,9,4),4),
            new ExamResult("SQL-300",new Student("David","Merliyn","Johnson",363),new DateTime(2016,9,4),2),
            new ExamResult("Math",new Student("Andrey","Ivanov","Petrovich",263),new DateTime(2020,9,4),2),
            new ExamResult("SQL-300",new Student("David","Merliyn","Johnson",363),new DateTime(2018,9,4),5),
            new ExamResult("HTML-100",new Student("Andrey","Ivanov","Petrovich",263),new DateTime(2020,1,4),5)
        };

        [Test]
        public void Test_GetFirstExamDate_Success()
        {
            var tree = new IterativeTree<ExamResult>(_examResults);

            var actual = ExamResultFilters.GetFirstExamDate(tree);

            var expected = new DateTime(2016, 9, 4);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_Get2021YearExamCount_Success()
        {
            var tree = new IterativeTree<ExamResult>(_examResults);

            var actual = ExamResultFilters.GetThisYearExamCount(tree, 2021);

            var expected = 2;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_GetThreeFirstMaxResultExam_Success()
        {
            var tree = new IterativeTree<ExamResult>(_examResults);

            var actual = ExamResultFilters.GetFirstMaxResultExam(tree, 3);

            var expected = new List<ExamResult>
            {
                new ExamResult("HTML-100",new Student("Andrey","Ivanov","Petrovich",263),new DateTime(2020,1,4),5),
                new ExamResult("SQL-300",new Student("David","Merliyn","Johnson",363),new DateTime(2018,9,4),5),
                new ExamResult("HTML-300",new Student("Dmitriy","Ermakov","Sergeevich",643),new DateTime(2017,9,4),4)
            };

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_GetGetFullNameStudents_Success()
        {
            var tree = new IterativeTree<ExamResult>(_examResults);

            var actual = ExamResultFilters.GetFullNameStudents(tree);

            var expected = new List<string>
            {
                "Andrey Ivanov Petrovich",
                "David Merliyn Johnson",
                "Dmitriy Ermakov Sergeevich",
                "Sam Johnson Pots"
            };

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_GetStudentsWith4And5Score_Success()
        {
            var tree = new IterativeTree<ExamResult>(_examResults);

            var actual = ExamResultFilters.GetMoreThanScoreResultStudents(tree, 3);

            var expected = new List<Student>
            {
                new Student("Dmitriy","Ermakov","Sergeevich",643),
                new Student("Sam","Johnson","Pots",345)
            };

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_Get2ScoreExam_Success()
        {
            var tree = new IterativeTree<ExamResult>(_examResults);

            var actual = ExamResultFilters.GetCertainScoreExam(tree, 2);

            var expected = new List<ExamResult>
            {
                new ExamResult("Math",new Student("Andrey","Ivanov","Petrovich",263),new DateTime(2020,9,4),2),
                new ExamResult("SQL-300",new Student("David","Merliyn","Johnson",363),new DateTime(2016,9,4),2)
            };

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_GetStudentAverageScore_Success()
        {
            var tree = new IterativeTree<ExamResult>(_examResults);

            var actual = ExamResultFilters.GetStudentAverageScore(tree);

            var expected = new Dictionary<Student, double>
            {
                { new Student("Andrey","Ivanov","Petrovich",263),3.5},
                { new Student("Dmitriy","Ermakov","Sergeevich",643),4},
                { new Student("Sam","Johnson","Pots",345),4},
                { new Student("David","Merliyn","Johnson",363),3.5}
            };

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_Get9Month2021YearExam_Success()
        {
            var tree = new IterativeTree<ExamResult>(_examResults);

            var actual = ExamResultFilters.GetCertainMonthYearExam(tree, 2021, 9);

            var expected = new List<ExamResult>
            {
                new ExamResult("HTML-300",new Student("Dmitriy","Ermakov","Sergeevich",643),new DateTime(2021,9,4),4),
                new ExamResult("HTML-300",new Student("Sam","Johnson","Pots",345),new DateTime(2021,9,4),4)
            };

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_GetNotPatternExamTitle_Success()
        {
            var tree = new IterativeTree<ExamResult>(_examResults);

            var actual = ExamResultFilters.GetNotPatternExamTitle(tree);

            var expected = new List<string>
            {
                "Math"
            };

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_GetAllExamStudents_Success()
        {
            var tree = new IterativeTree<ExamResult>(_examResults);

            var actual = ExamResultFilters.GetAllExamStudents(tree);

            var expected = new Dictionary<string, string[]>
            {
                { "Andrey Ivanov Petrovich",new string[]{ "HTML-100","Math" } },
                { "David Merliyn Johnson", new string[]{ "SQL-300" } },
                { "Dmitriy Ermakov Sergeevich", new string[]{ "HTML-300" } },
                { "Sam Johnson Pots", new string[]{ "HTML-300" } }
            };

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_GetStudentsRetookExams_Success()
        {
            var tree = new IterativeTree<ExamResult>(_examResults);

            var actual = ExamResultFilters.GetStudentsRetookExams(tree);

            var expected = new Dictionary<Student, string[]>
            {
                { new Student("Dmitriy","Ermakov","Sergeevich",643),new string[]{ "HTML-300" }},
                { new Student("David","Merliyn","Johnson",363),new string[]{ "SQL-300" }}
            };

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_GetNot2021YearExam_Success()
        {
            var tree = new IterativeTree<ExamResult>(_examResults);

            var actual = ExamResultFilters.GetNotCertainYearExam(tree, 2021);

            var expected = new List<ExamResult>
            {
                new ExamResult("HTML-100",new Student("Andrey","Ivanov","Petrovich",263),new DateTime(2020,1,4),5),
                new ExamResult("HTML-300",new Student("Dmitriy","Ermakov","Sergeevich",643),new DateTime(2017,9,4),4),
                new ExamResult("Math",new Student("Andrey","Ivanov","Petrovich",263),new DateTime(2020,9,4),2),
                new ExamResult("SQL-300",new Student("David","Merliyn","Johnson",363),new DateTime(2016,9,4),2),
                new ExamResult("SQL-300",new Student("David","Merliyn","Johnson",363),new DateTime(2018,9,4),5)
            };

            Assert.AreEqual(expected, actual);
        }
    }
}