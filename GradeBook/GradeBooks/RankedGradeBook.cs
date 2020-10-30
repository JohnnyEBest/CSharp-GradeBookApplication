using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighed) :base(name, isWeighed)
        {
            Type = GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("You must have atleast 5 students to rank by grades.");
            }
            var dropLetterGrade = (int)Math.Ceiling(Students.Count * 0.2);
            var grades = Students.OrderByDescending(x => x.AverageGrade).Select(x => x.AverageGrade).ToList();
            if (grades[dropLetterGrade-1] <= averageGrade)
                return 'A';
            else if (grades[(dropLetterGrade * 2) - 1] <= averageGrade)
                return 'B';
            else if (grades[(dropLetterGrade * 3) - 1] <= averageGrade)
                return 'C';
            else if (grades[(dropLetterGrade * 4) - 1] <= averageGrade)
                return 'D';
            else
                return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }
    }

}
