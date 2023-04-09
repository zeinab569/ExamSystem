using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examsystem
{
    // class Answer
    public  class Answer
    {
        
        
        public Question Question { get; set; }
        //public string Ans { get; set; }
        public string Text { get; set; }
        

        public Answer(Question ques, string ans )
        {
            Question = ques;
            Text=ans;
        }

    }

    // class AnswerList
    public class AnswerList : List<Answer>
    {
        public List<Answer> Answers { get; set; }

        public AnswerList()
        {
            Answers = new List<Answer>();
        }

        public void AddAnswer(Question q,string ans)
        {
            Answers.Add(new Answer(q,ans));
        }

    }

    public class AnswerSheet
    {
        public int StudentId { get; }
        public Question Question { get; set; }
        public string Text { get; set; }
        //public bool IsCorrect { get; set; }

        public AnswerSheet( Question question, string text)
        {
            
            Question = question;
            Text = text;
        }

        public void Addallanswer(Question q,string Text)
        {
            AnswerSheet AS =new AnswerSheet(q,Text);
        }
    }



}
