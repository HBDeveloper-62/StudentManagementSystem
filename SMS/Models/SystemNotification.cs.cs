using System;

namespace SMS.Models
{
    public class SystemNotification
    {
        public int Id { get; set; }
        public string? Message { get; set; }
        public string? Type { get; set; } // e.g. Info, Warning, Error
        public DateTime Timestamp { get; set; }
    }
}
