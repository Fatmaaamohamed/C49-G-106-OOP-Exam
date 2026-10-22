using System;
using System.Text;

namespace Examination_system
{
    internal class MCQQuestion : Question
    {
        public MCQQuestion(string body, int mark, Answer[] answers, int rightAnswerId)
            : base("MCQ Question", body, mark)
        {
            AnswerList = answers;

            foreach (Answer answer in AnswerList)
            {
                if (answer.AnswerId == rightAnswerId)
                {
                    RightAnswer = answer;
                    break;
                }
            }

            if (RightAnswer == null)
            {
                throw new ArgumentException("Right answer ID was not found.");
            }
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

      
        public static MCQQuestion Read()
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

            Console.WriteLine("Choices of Question:");
            Answer[] answers = new Answer[4];
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Please enter choice number " + (i + 1) + ":");
                string text = Console.ReadLine() ?? "";
                while (string.IsNullOrWhiteSpace(text))
                {
                    Console.WriteLine("This value cannot be empty.");
                    text = Console.ReadLine() ?? "";
                }
                answers[i] = new Answer(i + 1, text);
            }

            int right;
            Console.WriteLine("Please enter the ID of the correct answer (1 to 4):");
            while (!int.TryParse(Console.ReadLine(), out right) || right < 1 || right > 4)
                Console.WriteLine("Invalid input, please try again.");

            return new MCQQuestion(body, mark, answers, right);
        }
    }
}
