using System;
using System.ComponentModel.DataAnnotations;

namespace SMS.Models
{
    public class Timetable
    {
        public int Id { get; set; }
        public string? ClassName { get; set; }
        public string? Subject { get; set; }
        public string? Day { get; set; }
        public string? Class { get; set; }
        public string? Time { get; set; }
        public string? TeacherName { get; set; }
        public bool IsApproved { get; set; } // Added property to fix CS1061  
        public DateTime SubmittedDate { get; set; }
        public string? Status { get; set; }
    }
}
