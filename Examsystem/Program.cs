// See https://aka.ms/new-console-template for more information

using Examsystem;

//create Student
Student std1 = new Student();
std1.FirstName = "Zeinab";
std1.LastName = "elazab";
std1.Id = 1;
// create question

//genrate questions True false
Question q1 = new TrueFalseQuestion("oop is very important ?", 5, "section one", true);
Question q2 = new TrueFalseQuestion("machine is apart of AI?", 5, "section one", true);
Console.WriteLine("----------------------Display True False Question-------------------------");
q1.ToString();
Console.WriteLine("--------------------------------------------------------------------------");
q2.ToString();

// generate mcq but one value
List<string> theoptions = new List<string>();
List<string> theoptions2 = new List<string>();

theoptions.Add("1");
theoptions.Add("2");
theoptions.Add("3");
theoptions.Add("any number");

theoptions2.Add("Constructors can be overloaded");
theoptions2.Add("Constructors are never called explicitly");
theoptions2.Add("Constructors have same name as name of the class");
theoptions2.Add(" All of the mentioned");

Question q3 = new ChooseOneQuestion("Number of constructors a class can define is?", 5,"oop section",theoptions,3);
Question q4 = new ChooseOneQuestion("Correct statement about constructors in C#.NET is?", 5, "oop section", theoptions2, 3);
Console.WriteLine("---------------------Display McQ Question---------------------------------");
q3.ToString();
Console.WriteLine("--------------------------------------------------------------------------");
q4.ToString();

// genrate mcq but multible value
List<string> theoptionsformultival = new List<string>();
List<int> thecorrectanswers = new List<int>();

theoptionsformultival.Add("C++ programming language");
theoptionsformultival.Add("Java programming language");
theoptionsformultival.Add("abc programming language");
theoptionsformultival.Add("C# programming language");

thecorrectanswers.Add(1);
thecorrectanswers.Add(2);
thecorrectanswers.Add(0);
Question q5 = new ChooseAllQuestion("Which of the following language supports polymorphism ?", 10, "oop section", theoptionsformultival, thecorrectanswers);
Console.WriteLine("--------------------------------------------------------------------------");
q5.ToString();
Console.WriteLine("-----------------------------Added questin in list ---------------------------------------------");

Console.ForegroundColor = ConsoleColor.Yellow;
//After that make question List
QuestionList questionsAdded = new QuestionList(@"C:\Users\lenovo\Desktop\thecreate_exam.txt");

questionsAdded.Add(q5);
questionsAdded.Add(q3);
Console.ForegroundColor = ConsoleColor.White;

Console.WriteLine("--------------------------Create Exam------------------------------------------------");

DateTime d1 = new DateTime();
Subject s1 = new Subject("Machine Learning", "part of AI");
Dictionary<string, string> ques_answers = new Dictionary<string, string>();

ques_answers.Add("Which of the following language supports polymorphism ?", "C++ programming language");
ques_answers.Add("machine is apart of AI?", "true");
ques_answers.Add("Correct statement about constructors in C#.NET is?", "Constructors have same name as name of the class");

Exam Epractice1 = new PracticeExam(d1, 3, ques_answers, s1);
Exam Efinal2 = new FinalExam(d1, 3, ques_answers, s1);

Console.ForegroundColor = ConsoleColor.Magenta;
//Epractice1.ShowExam();
Console.ForegroundColor = ConsoleColor.Cyan;

Student std2 = new Student();

std1.FirstName = "fatma";
std1.LastName = "elazab";

// print the name of students
Epractice1.ExamStarting += std1.OnExamStarting;
Epractice1.ExamStarting += std2.OnExamStarting;

Epractice1.Start();
Efinal2.Start();
Console.ForegroundColor = ConsoleColor.Green;
// make menu to user select type of Exam
Console.WriteLine("Select an exam type:");
Console.WriteLine("1. Practice Exam");
Console.WriteLine("2. Final Exam");
Console.WriteLine("--------------------------Show Exam------------------------------------------------");
string input = Console.ReadLine();
Exam exam;
if (input == "1")
{
    exam =  Epractice1 as Exam;
}
else
{
    exam =Efinal2 as Exam;  
}
exam.ShowExam();
Console.WriteLine("--------------------------Answers Exam------------------------------------------------");

AnswerList answerList = new AnswerList();
AnswerSheet As = new AnswerSheet(q1, "true");
As.Addallanswer(q2, "true");
As.Addallanswer(q3, "All of the mentioned");
answerList.AddAnswer(q1, "true");
answerList.AddAnswer(q2, "true");
answerList.AddAnswer(q3, "All of the mentioned");

//exam.GradeExam(As, answerList);

Console.ForegroundColor = ConsoleColor.White;