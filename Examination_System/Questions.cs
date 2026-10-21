using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_System
{
    public abstract class Question
    {
        // Question class is abstract class bec. its the base class
        // and we dont want it to be instantiated and also to contain abstract methods
        public virtual string? Header { get; set; }
        public string? Body { get; set; }
        public double Mark { get; set; }
        public Answers[]? Answers { get; set; }
        public Answers CorrectAnswer { get; set; }
        public Answers StudentAnswer { get; set; }

        public Question()
        {
            CorrectAnswer = new Answers();
            StudentAnswer = new Answers();
        }
        public override string ToString()
        {
            return $"{Body}\t Mark: {Mark}";
        }

        public abstract void AddQuestion();
    }
}
