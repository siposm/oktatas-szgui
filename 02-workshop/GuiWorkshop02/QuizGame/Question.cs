using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame
{
    public class Question
    {
        public string QuestionText { get; set; }

        public string[] Answers { get; set; }

        public bool? Correct { get; set; }
    }
}
