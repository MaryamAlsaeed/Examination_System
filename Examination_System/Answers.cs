using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_System
{
    public class Answers
    {
        public int AnswerId { get; set; }
        public string? AnswerText { get; set; }

        public Answers() { } // => used when we have mcq questions in this case we don't need to put the 2 params
        public Answers(int answerId, string? answerText)
        {
            this.AnswerId = answerId;
            this.AnswerText = answerText;
        }

        public override string ToString()
        {
            return $"{AnswerId}: {AnswerText}";
        }
    }
}
