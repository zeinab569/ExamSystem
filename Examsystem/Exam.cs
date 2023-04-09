using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection.PortableExecutable;
//using Microsoft.Toolkit.Uwp.Notifications;
using System.Xml.Linq;

namespace Examsystem
{
    //Exam mode
    public enum ExamMode { Starting, Queued, Finished }
    // Exam
    public class Exam : ICloneable, IComparable<Exam>
    {
        public String Name { get; set; }
        public DateTime Time { get; set; }
        public int NumQuestions { get; set; }
        public Dictionary<string, string> QuestionAnswers { get; set; }
        public ExamMode Mode { get; set; }
        public Subject Subject { get; set; }

        public Exam(DateTime time, int numQuestions, Dictionary<string, string> questionAnswers, Subject subject)
        {
            Time = time;
            NumQuestions = numQuestions;
            QuestionAnswers = questionAnswers;
            Mode = ExamMode.Starting;
            Subject = subject;
        }

        public Exam(Exam other) : this(other.Time, other.NumQuestions, other.QuestionAnswers, other.Subject)
        {
            Mode = other.Mode;
        }

        public virtual void ShowExam()
        {
            // To be overridden by subclasses
        }

        public object Clone()
        {
            return new Exam(this);
        }

        public int CompareTo(Exam other)
        {
            return Time.CompareTo(other.Time);
        }

        public override string ToString()
        {
            return $"Exam at {Time} ({NumQuestions} questions) (the mode is{Mode} )";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Exam other = (Exam)obj;
            return Time == other.Time && NumQuestions == other.NumQuestions &&
                QuestionAnswers.Equals(other.QuestionAnswers) && Mode == other.Mode &&
                Subject.Equals(other.Subject);
        }

        public override int GetHashCode()
        {
            return Tuple.Create(Time, NumQuestions, QuestionAnswers, Mode, Subject).GetHashCode();
        }

        // Event for when the exam is starting
        public event ExamStartingEventHandler ExamStarting;

        // Method to start the exam
        public void Start()
        {
            Mode = ExamMode.Starting;

            // Notify all students taking the exam
            ExamStartingEvent stds = new ExamStartingEvent();
            stds.ExamName = Name;
            OnExamStarting(stds);
        }

        // Method to handle the ExamStarting event
        protected virtual void OnExamStarting(ExamStartingEvent e)
        {
            ExamStarting?.Invoke(this, e);
        }

        // CalcGrade
        public void GradeExam(AnswerSheet userAnswers,AnswerList al)
        {
            int numCorrect = 0;
            for (int i = 0; i < al.Count; i++)
            {
                if (userAnswers.Equals ==  al.Equals)
                {
                    numCorrect++;
                }
            }
            Console.WriteLine($"You got {numCorrect} out of {al.Count} questions correct.");
        }
    }

    //practice Exam
    public class PracticeExam : Exam
    {
        public PracticeExam(DateTime time, int numQuestions, Dictionary<string, string> questionAnswers, Subject subject)
            : base(time, numQuestions, questionAnswers, subject)
        {
        }
        public override void ShowExam()
        {
            Console.WriteLine($"Practice Exam ({NumQuestions} questions):");

            foreach (var pair in QuestionAnswers)
            {
                Console.WriteLine($"Right Answer: {pair.Value}");     
            }
        }
    }

    //finalexam
    public class FinalExam : Exam
    {
        public FinalExam(DateTime time, int numQuestions, Dictionary<string, string> questionAnswers, Subject subject)
            : base(time, numQuestions, questionAnswers, subject)
        {
        }

        public override void ShowExam()
        {
            Console.WriteLine($"Final Exam ({NumQuestions} questions):");
            foreach (var pair in QuestionAnswers)
            {
                Console.WriteLine($"Question: {pair.Key}");
                Console.WriteLine($"Answer: {pair.Value}");
            }
        }
    }

    // Event arguments for the ExamStarting event
    public class ExamStartingEvent : EventArgs
    {
        public string ExamName { get; set; }
    }

    // Delegate for the ExamStarting event
    public delegate void ExamStartingEventHandler(object sender, ExamStartingEvent e);

    // Delegate for the ExamChange mood event
    public delegate void ExamStatusChangedEventHandler(Exam exam, ExamMode oldMode, ExamMode newMode);

    // Exam Scheduler
    public class ExamScheduler
    {
        public event ExamStatusChangedEventHandler ExamStatusChanged;

        private List<Exam> exams;

        public ExamScheduler()
        {
            exams = new List<Exam>();
        }

        public void AddExam(Exam exam)
        {
            exams.Add(exam);
            exam.Mode = ExamMode.Queued;
        }

    }
}
