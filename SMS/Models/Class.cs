using System.ComponentModel.DataAnnotations;

namespace SMS.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string? ClassName { get; set; } // e.g. 5th, 6th, 7th
        public string? Section { get; set; } // Optional: A, B, etc.
        [Required]
        [StringLength(100)]
        public string? SubjectName { get; set; }

    }
}
