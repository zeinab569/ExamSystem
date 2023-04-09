using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Net.Mime.MediaTypeNames;


namespace Examsystem
{
    // Base class for all question types
    public abstract class Question
    {
        string body;
        int marks;
        string header;

        //properities
        public string Body { get => body; set => body = value; }
        public int Marks { get => marks; set => marks = value; }
        public string Header { get => header; set => header = value; }

        //constructor
        public Question(string _body, int _marks, string _header)
        {
            body = _body;
            marks = _marks;
            header = _header;
        }

        public Question() { }

        // Method to display the question in a format specific to its type
        public override string ToString()
        {
            return $"the header {header}\n {body} \t the mark is:{marks}";
        }

        public override bool Equals(object? obj)
        {
            if(obj is null) return false;   
            Question q= obj as Question;
            if(q == null) return false;
            if(q.GetType() != typeof(Question)) return false;
            return Body == q.Body && Header == q.Header;

        }

        public override int GetHashCode()
        {
            return this.Body.ToString().GetHashCode();
        }

        // Answer List
        public List<Answer> Answers { get; set; }

        // Method to get the correct answer(s) to the question
        //public  List<string> GetCorrectAnswers();

    }

    // True/False question type
    public class TrueFalseQuestion : Question
    {
        bool answer;
        public bool Answer { get => answer; set => answer = value; }

        public TrueFalseQuestion(string _body, int _marks, string _header, bool _answer) : base(_body, _marks, _header)
        {
            answer = _answer;
        }

        public override string ToString()
        {
            Console.WriteLine($"{Header} ({Marks} marks)");
            Console.WriteLine(Body);
            Console.WriteLine("True or False?");
            return "";
        }

        //public override List<string> GetCorrectAnswers()
        //{
        //    return new List<string> { Answer.ToString() };
        // }
    }

    // Choose One question type
    public class ChooseOneQuestion : Question
    {
        public List<string> Options { get; set; }
        int correctOptionIndex;

        public int CorrectOptionIndex1 { get => correctOptionIndex; set => correctOptionIndex = value; }
        public ChooseOneQuestion(string _body, int _marks, string _header, List<string> _options, int _CorrectOptionIndex) : base(_body, _marks, _header)
        {
            correctOptionIndex = _CorrectOptionIndex;
            Options = _options;
        }
        public ChooseOneQuestion():base() { }
        
        public override string ToString()
        {
            Console.WriteLine($"{Header} ({Marks} marks)");
            Console.WriteLine(Body);
            for (int i = 0; i < Options.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Options[i]}");
            }
            return "";
        }

        // public override List<string> GetCorrectAnswers()
        // {
        //      return new List<string> { Options[CorrectOptionIndex1] };
        // }

    }

    // Choose All each
    public class ChooseAllQuestion : Question
    {
        public List<string> Options { get; set; }
        public List<int> AnswerNumber { get; set; }

        public ChooseAllQuestion(string _body, int _marks, string _header, List<String> _options, List<int> _answernumber) : base(_body, _marks, _header)
        {
            Options = _options;
            AnswerNumber = _answernumber;
        }

        public override String ToString()
        {
            Console.WriteLine("Choose all question:");
            Console.WriteLine(Header);
            Console.WriteLine(Body);
            for (int i = 0; i < Options.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Options[i]}");
            }
            return "";
        }
    }

    // QuestionList
    public class QuestionList : List<Question>
    {
        string logFilePath;

        public string LogFilePath { get => logFilePath; set => logFilePath = value; }


        public QuestionList(string _logFilePath)
        {
            LogFilePath = _logFilePath;
        }

        public new void Add(Question question)
        {
            
            try
            {
                using (StreamWriter writer = new StreamWriter(LogFilePath))
                {
                    writer.WriteLine(question.ToString() + DateTime.Now.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            //FileStream fs = File.Create(LogFilePath);
            //File.WriteAllText(LogFilePath, question.ToString() + DateTime.Now.ToString());
            
    }
    }



}
