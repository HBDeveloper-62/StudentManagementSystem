// Models/FeeRecord.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace SMS.Models
{
    public class FeeRecord
    {
        public int Id { get; set; }

        [Required]
        public string? StudentName { get; set; }

        [Required]
        public string? ClassName { get; set; } // e.g., "1st", "2nd"

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string? Status { get; set; } // "Paid", "Unpaid"

        [DataType(DataType.Date)]
        public DateTime PaymentDate { get; set; }
    }
}
