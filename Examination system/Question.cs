using System;
using System.Text;

namespace Examination_system
{
    internal abstract class Question : ICloneable, IComparable<Question>
    {
        public string Header { get; set; }

        public string Body { get; set; }

        public int Mark { get; set; }

        public Answer[] AnswerList { get; set; }

        public Answer RightAnswer { get; set; }

        public Question(string header, string body, int mark)
        {
            Header = header;
            Body = body;
            Mark = mark;
            AnswerList = new Answer[0];
        }


        public object Clone()
        {
            Question copy = (Question)MemberwiseClone();

            copy.AnswerList = new Answer[AnswerList.Length];

            for (int i = 0; i < AnswerList.Length; i++)
            {
                if (AnswerList[i] != null)
                {
                    copy.AnswerList[i] = (Answer)AnswerList[i].Clone();

                    if (AnswerList[i] == RightAnswer)
                    {
                        copy.RightAnswer = copy.AnswerList[i];
                    }
                }
            }

            return copy;
        }


        public abstract void ShowQuestionDetails();

        public virtual void ShowRightAnswer()
        {
            Console.WriteLine("Correct Answer => " + RightAnswer.AnswerText);
        }

        public int CompareTo(Question? other)
        {
            if (other == null) return 1;
            return Mark.CompareTo(other.Mark);
        }

        public override string ToString()
        {
            return "Header: " + Header + ", Body: " + Body + ", Mark: " + Mark;
        }
    }
}
