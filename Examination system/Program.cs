
namespace Examination_system
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject(1, "C# OOP");

     
            subject.CreateExam();

            Console.Clear();
            Console.WriteLine("Do You Want To Start Exam (Y | N)");
            string choice = (Console.ReadLine() ?? "");
            while (choice != "Y" && choice != "y" && choice != "N" && choice != "n")
            {
                Console.WriteLine("Please enter Y or N.");
                choice = (Console.ReadLine() ?? "");
            }

            if (choice == "Y" || choice == "y")
            {
                Console.Clear();
                subject.Exam.ShowExam();
            }
        
        }
    }
}
    