using SMS.Models;
using System.Collections.Generic;

namespace SMS.ViewModels
{
    public class AdmissionViewModel
    {
        public Admission Admission { get; set; } = new Admission();
        public List<string>? ClassList { get; set; }  // ✅ Accepts ToString() values

        public List<Admission>? Admissions { get; set; }   // Add this to pass all students
    }
}
