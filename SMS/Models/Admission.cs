using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.Models
{
    [Table("Admissions")]
    public class Admission
    {
        [Key]
        public int StudentID { get; set; } // Use int if your DB column is int
        public string? FullName { get; set; }
        public string? FatherName { get; set; }
        public string? Class { get; set; }
        public string? Email { get; set; }
        public string? Contact { get; set; }
        public string? Address { get; set; }
        public DateTime AdmissionDate { get; set; }
    }
}
