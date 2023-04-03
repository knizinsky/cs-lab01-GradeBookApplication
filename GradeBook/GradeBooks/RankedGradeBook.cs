using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool weighted) : base(name, weighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked grading requires at least 5 students.");
            }

            var twentyPercent = (int)Math.Ceiling(Students.Count * 0.2);
            var sortedStudents = Students.OrderByDescending(s => s.AverageGrade).ToList();

            var index = sortedStudents.FindIndex(s => s.AverageGrade == averageGrade);

            if (index < twentyPercent)
            {
                return 'A';
            }
            else if (index < twentyPercent * 2)
            {
                return 'B';
            }
            else if (index < twentyPercent * 3)
            {
                return 'C';
            }
            else if (index < twentyPercent * 4)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
}