using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_System
{
    public class MCQ : Question
    {
        public override string? Header => "Multiple Choice Questions";

        public MCQ()
        {
            Answers = new Answers[4];
        }

        public override void AddQuestion()
        {
            int mark;

            Console.WriteLine("Multiple Choice Question :");

            Console.WriteLine("Please Enter the question body:");
            Body = Console.ReadLine();

            do
            {
                Console.WriteLine("Please Enter the question mark:");
            }
            while (!int.TryParse(Console.ReadLine(), out mark) || mark <= 0);
            Mark = mark;

            Console.WriteLine("Choices of Question:");
            for (int i = 0; i < Answers!.Length; i++)
            {
                Console.WriteLine($"Please enter choice number {i + 1}:");
                Answers[i] = new Answers(i + 1, Console.ReadLine());
            }

            int RightAnswerId;

            do
            {
                Console.WriteLine("Please Enter the correct answer (1-4):");
            }
            while (!int.TryParse(Console.ReadLine(), out RightAnswerId) || RightAnswerId < 1 || RightAnswerId > 4);

            CorrectAnswer.AnswerId = RightAnswerId;
            CorrectAnswer.AnswerText = Answers?[RightAnswerId - 1].AnswerText;
        }
    }
}
