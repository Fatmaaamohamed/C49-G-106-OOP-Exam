using System;
using System.Collections;
using System.Text;

namespace Examination_system
{
    internal class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion(string body, int mark, bool correctAnswer)
            : base("True/False Question", body, mark)
        {
            AnswerList = new Answer[]
            {
                new Answer(1, "True"),
                new Answer(2, "False")
            };

            RightAnswer = AnswerList[correctAnswer ? 0 : 1];
        }

        public override void ShowQuestionDetails()
        {
            Console.WriteLine(Header);
            Console.WriteLine(Body + " (" + Mark + " marks)");

            foreach (Answer answer in AnswerList)
            {
                Console.WriteLine(answer);
            }
        }

    
        public static TrueFalseQuestion Read()
        {
            Console.WriteLine("Please enter the question body:");
            string body = Console.ReadLine() ?? "";
            while (string.IsNullOrWhiteSpace(body))
            {
                Console.WriteLine("This value cannot be empty.");
                body = Console.ReadLine() ?? "";
            }

            int mark;
            Console.WriteLine("Please enter the question mark:");
            while (!int.TryParse(Console.ReadLine(), out mark) || mark < 1)
                Console.WriteLine("Invalid input, please try again.");

            int right;
            Console.WriteLine("Please enter the ID of the correct answer (1 for True, 2 for False):");
            while (!int.TryParse(Console.ReadLine(), out right) || right < 1 || right > 2)
                Console.WriteLine("Invalid input, please try again.");

            return new TrueFalseQuestion(body, mark, right == 1);
        }
    }
}

