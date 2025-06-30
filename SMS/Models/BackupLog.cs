using System;

namespace SMS.Models
{
    public class BackupLog
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string? Status { get; set; } // e.g. "Success", "Failed"
    }
}
