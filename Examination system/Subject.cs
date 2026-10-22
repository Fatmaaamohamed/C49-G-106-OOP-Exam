using System;
using System.Collections.Generic;
using System.Text;


namespace Examination_system
{
    internal class Subject : ICloneable, IComparable<Subject>
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam? Exam { get; private set; }

        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }

     
        public void CreateExam()
        {
            int type;
            Console.WriteLine("Enter the type of exam (1 for Practical, 2 for Final):");
            while (!int.TryParse(Console.ReadLine(), out type) || type < 1 || type > 2)
                Console.WriteLine("Invalid input, please try again.");

            int time;
            Console.WriteLine("Please enter the time for the exam (30 to 180 minutes):");
            while (!int.TryParse(Console.ReadLine(), out time) || time < 30 || time > 180)
                Console.WriteLine("Invalid input, please try again.");

            int count;
            Console.WriteLine("Please enter the number of questions:");
            while (!int.TryParse(Console.ReadLine(), out count) || count < 1)
                Console.WriteLine("Invalid input, please try again.");

            if (type == 1)
            {
                Exam = new PracticalExam(time);
            }
            else
            {
                Exam = new FinalExam(time);
            }

            Exam.Subject = this;
            Exam.CreateQuestions(count);
        }

        public object Clone()
        {
            Subject copy = new Subject(SubjectId, SubjectName);

            if (Exam != null)
            {
                copy.Exam = (Exam)Exam.Clone();
                copy.Exam.Subject = copy;
            }

            return copy;
        }

        public int CompareTo(Subject? other)
        {
            if (other == null)
                return 1;

            return SubjectId.CompareTo(other.SubjectId);
        }

        public override string ToString()
        {
            return "Subject ID: " + SubjectId + ", Subject Name: " + SubjectName;
        }
    }
}