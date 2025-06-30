using System.ComponentModel.DataAnnotations;

namespace SMS.Models
{
    public class EventExam
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public string? Type { get; set; } // "Event" or "Exam"
    }

}
