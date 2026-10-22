using System;
using System.Diagnostics;

namespace Examination_system
{
    internal class PracticalExam : Exam
    {
        public PracticalExam(int time) : base(time)
        {
        }

  
        public override void CreateQuestions(int count)
        {
            for (int i = 0; i < count; i++)
            {
                AddQuestion(MCQQuestion.Read());
            }
        }

        public override void ShowExam()
        {
            Stopwatch sw = Stopwatch.StartNew();
            AskQuestions();
            sw.Stop();

            Console.Clear();
            Console.WriteLine("Practical Exam Results:");

            int grade = 0;
            int totalMarks = 0;

            for (int i = 0; i < Questions.Count; i++)
            {
                Question question = Questions[i];
                Answer chosen = question.AnswerList[StudentAnswers[i] - 1];

                Console.WriteLine("Question " + (i + 1) + ": " + question.Body);
                Console.WriteLine("Your Answer => " + chosen.AnswerText);
                question.ShowRightAnswer();      
                Console.WriteLine();

                totalMarks += question.Mark;
                if (chosen.AnswerId == question.RightAnswer.AnswerId)
                {
                    grade += question.Mark;
                }
            }

            Console.WriteLine("Your Grade is " + grade + " from " + totalMarks);
            Console.WriteLine("Time = " + sw.Elapsed);
            Console.WriteLine("Thank you");
        }
    }
}