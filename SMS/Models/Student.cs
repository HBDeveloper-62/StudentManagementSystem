using System.ComponentModel.DataAnnotations;

namespace SMS.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
      
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? ClassName { get; set; }
        public string? Status { get; set; }
        public bool IsPresent { get; set; }
        public double AttendancePercentage { get; set; }
        public string? FeeStatus { get; set; }
        public string? Role { get; set; }
        public string? Email { get; set; } // Added Email property to fix CS1061  
    }
}
