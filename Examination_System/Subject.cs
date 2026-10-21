using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_System
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam Exam { get; set; }
        public Question question { get; set; }
        public Subject() { }
        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }

        int TypeOfExam,time, NumQuestions;

        public void CreateExam()
        {
            do
            {
                Console.Write("Please Enter The Type Of Exam ( 1 for practical and 2 for final):");
            } while (!int.TryParse(Console.ReadLine(), out TypeOfExam) && TypeOfExam < 1 || TypeOfExam > 2);

            do
            {
                Console.Write("Enter The Time Of The Exam (30 to 180 minutes ) : ");
            } while (!int.TryParse(Console.ReadLine(), out time) || time < 30 || time > 180);
            do
            {
                Console.Write("Enter The Number Of Questions: ");
            } while (!int.TryParse(Console.ReadLine(), out NumQuestions) || NumQuestions <= 0);

            Console.Clear();
            Question[] questions = new Question[NumQuestions];

            if (TypeOfExam == 1)
            {
                Exam = new PracticalExam(time, NumQuestions);
            }
            else
            {
                Exam = new FinalExam(time, NumQuestions);
            }

            Console.Clear();

            Exam.CreateTypeListOfQs();
        }
    }
}
