using System;
using System.Text;

namespace Examination_system
{
    internal abstract class Exam : ICloneable, IComparable<Exam>
    {
        public int Time { get; set; }

        public int NumberOfQuestions
        {
            get { return Questions.Count; }
        }

        public List<Question> Questions { get; set; }

        public Subject Subject { get; set; }

        protected List<int> StudentAnswers;

        protected Exam(int time)
        {
            Time = time;
            Questions = new List<Question>();
            StudentAnswers = new List<int>();
        }

        public void AddQuestion(Question question)
        {
            Questions.Add(question);
        }

        public abstract void CreateQuestions(int count);

      
        public abstract void ShowExam();


        protected void AskQuestions()
        {
            StudentAnswers.Clear();

            for (int i = 0; i < Questions.Count; i++)
            {
                if (Questions[i].AnswerList == null ||
                    Questions[i].AnswerList.Length == 0)
                {
                    throw new InvalidOperationException(
                        "Question must have at least one answer.");
                }

                Console.WriteLine();
                Console.WriteLine("Question " + (i + 1) + ":");

                Questions[i].ShowQuestionDetails();

                int choice;
                Console.Write("Your Answer (enter Answer ID): ");

                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > Questions[i].AnswerList.Length)
                {
                    Console.Write("Invalid input, please try again: ");
                }

                StudentAnswers.Add(choice);
            }
        }

        public object Clone()
        {
            Exam copy = (Exam)MemberwiseClone();

            copy.Questions = new List<Question>();
            foreach (Question question in Questions)
            {
                copy.Questions.Add((Question)question.Clone());
            }

            copy.StudentAnswers = new List<int>(StudentAnswers);
            return copy;
        }

        public int CompareTo(Exam? other)
        {
            if (other == null) return 1;
            return Time.CompareTo(other.Time);
        }

        public override string ToString()
        {
            return "Time: " + Time + " minutes, Number of Questions: " + NumberOfQuestions;
        }
    }
}

