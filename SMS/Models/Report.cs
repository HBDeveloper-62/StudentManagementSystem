using System;
using System.ComponentModel.DataAnnotations;

namespace SMS.Models
{
    public class Report
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters")]
        public string? Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
