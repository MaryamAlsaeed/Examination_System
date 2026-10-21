using System.Diagnostics;

namespace Examination_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject(1, "OOP");
            subject.CreateExam();
            Console.Clear();

            Stopwatch sw = Stopwatch.StartNew();
            subject.Exam!.ShowExam();
            sw.Stop();

            Console.WriteLine($"Time = {sw.Elapsed}");
            Console.WriteLine("Thank you");
        }
    }
}
