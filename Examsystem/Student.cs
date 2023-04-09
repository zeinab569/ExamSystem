using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examsystem
{
    public class Student
    {
        
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;  
        public string Email { get; set; }= string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;


        // Method to handle the ExamStarting event
        public void OnExamStarting(object sender, ExamStartingEvent e)
        {
            Console.WriteLine($"{FirstName}{LastName} is taking the {e.ExamName} exam, which is starting now.");
        }
    }
}
