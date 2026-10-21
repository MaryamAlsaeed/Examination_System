using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_System
{
    internal class TrueOrFalse : Question
    {
        public override string? Header => "True or False Questions";

        public TrueOrFalse()
        {
            Answers = new Answers[2];
            Answers[0] = new Answers(1, "True");
            Answers[1] = new Answers(2, "False");
        }

        public override void AddQuestion()
        {
            int mark;
            
            Console.WriteLine("True Or False Question :");

            Console.WriteLine("Please Enter the question body:");
            Body = Console.ReadLine();

            do
            {
                Console.WriteLine("Please Enter the question mark:");
            }
            while (!int.TryParse(Console.ReadLine(), out mark) || mark <= 0);
            Mark = mark;

            int RightAnswerId;

            do
            {
                Console.WriteLine("Please Enter the correct answer (1 for True, 2 for False):");
            }
            while (!int.TryParse(Console.ReadLine(), out RightAnswerId) || RightAnswerId < 1 || RightAnswerId > 2);

            CorrectAnswer.AnswerId = RightAnswerId;
            CorrectAnswer.AnswerText = Answers?[RightAnswerId - 1].AnswerText; // => we minus 1 bec. the array is zero indexed and user have to enter (1 or 2)
        }
    }
}
