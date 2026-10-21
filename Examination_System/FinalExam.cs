using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_System
{
    internal class FinalExam : Exam
    {
        public FinalExam()
        {
        }

        public FinalExam(int time, int numberOfQuestions) : base(time, numberOfQuestions)
        {
        }

        public override void CreateTypeListOfQs()
        {
            int TypeOfQuestion;
            Questions = new Question[NumberOfQuestions];

            for (int i = 0; i < NumberOfQuestions; i++)
            {
                do
                {
                    Console.WriteLine("Enter the type of question (1 for MCQ, 2 for True or False):");
                }
                while (!int.TryParse(Console.ReadLine(), out TypeOfQuestion) || (TypeOfQuestion < 1 || TypeOfQuestion > 2));

                Console.Clear();

                if (TypeOfQuestion == 1)
                {
                    Questions[i] = new MCQ();
                    Questions[i].AddQuestion();
                }
                else if (TypeOfQuestion == 2)
                {
                    Questions[i] = new TrueOrFalse();
                    Questions[i].AddQuestion();
                }
            }
        }
        

        public override void ShowExam()
        {
            int TypeOfQuestion;
            int StudentAnswer, grade = 0, totalMark = 0;
            foreach (var question in Questions!)
            {
                Console.WriteLine(question);
                for (int i = 0; i < question.Answers!.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {question.Answers[i].AnswerText}");
                }


                if (question is MCQ)
                {
                    do
                    {
                        Console.WriteLine("Enter your answer (1-4):");
                    }
                    while (!int.TryParse(Console.ReadLine(), out StudentAnswer) || (StudentAnswer < 1 || StudentAnswer > 4));

                    question.StudentAnswer.AnswerId = StudentAnswer;
                    question.StudentAnswer = question.Answers[StudentAnswer - 1];

                }
                else
                {
                    do
                    {
                        Console.WriteLine("Enter your answer (1 for True, 2 for False):");
                    }
                    while (!int.TryParse(Console.ReadLine(), out StudentAnswer) || (StudentAnswer < 1 || StudentAnswer > 2));

                    question.StudentAnswer.AnswerId = StudentAnswer;
                    question.StudentAnswer.AnswerText = question.Answers[StudentAnswer - 1].AnswerText;
                }

                Console.WriteLine();
                Console.Clear();

                totalMark += (int)question.Mark;
            }

            for (int i = 0; i < Questions.Length; i++)
            {
                if (Questions[i].StudentAnswer.AnswerId == Questions[i].CorrectAnswer.AnswerId)
                {
                    grade += (int)Questions[i].Mark;
                }
            }
            Console.WriteLine($"Your grade is: {grade}/{totalMark}");
        }
    }
}
