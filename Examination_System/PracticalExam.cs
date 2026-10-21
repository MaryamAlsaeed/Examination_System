using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_System
{
    public class PracticalExam : Exam
    {
        public PracticalExam()
        {
        }

        public PracticalExam(int time, int numberOfQuestions) : base(time, numberOfQuestions)
        {
        }

        public override void CreateTypeListOfQs()
        {
            Questions = new MCQ[NumberOfQuestions]; // Because practical exam can have MCQs only
            for (int i = 0; i < NumberOfQuestions; i++)
            {
                Questions[i] = new MCQ();
                Questions[i].AddQuestion();
                Console.Clear();
            }
        }

        public override void ShowExam()
        {
            int studentAnswer, grade = 0, totalMark = 0;
            foreach (var question in Questions!)
            {
                Console.WriteLine(question);
                for (int i = 0; i < question.Answers!.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {question.Answers[i].AnswerText}");
                }

                do
                {
                    Console.WriteLine("Please enter your answer (1-4):");
                }
                while (!int.TryParse(Console.ReadLine(), out studentAnswer) || studentAnswer < 1 || studentAnswer > 4);

                question.StudentAnswer.AnswerId = studentAnswer;
                question.StudentAnswer.AnswerText = question.Answers[studentAnswer - 1].AnswerText;


                totalMark += (int)question.Mark;
                if (question.StudentAnswer.AnswerId == question.CorrectAnswer.AnswerId)
                {
                    grade += (int)question.Mark;
                }

                Console.WriteLine($"Your Answer: {question.StudentAnswer.AnswerText}");
                Console.WriteLine($"Correct Answer: {question.CorrectAnswer.AnswerText}");
                Console.WriteLine($"Grade: {grade} out of {totalMark}");
            }
        }
    }
}
