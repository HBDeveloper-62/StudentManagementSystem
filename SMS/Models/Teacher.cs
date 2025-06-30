using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.Models
{
    [Table("Teachers")]
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Subject { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Status { get; set; }
        public string? CNIC { get; set; }
        public string? Address { get; set; }
        public decimal Salary { get; set; }
        public string? AccountNumber { get; set; }
        public DateTime JoinDate { get; set; }
        public string? ClassAssigned { get; set; }
    }
}
