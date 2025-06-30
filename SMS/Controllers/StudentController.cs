using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SMS.Data;
using SMS.Filters;
using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SMS.Controllers
{
    

    public class StudentController : Controller
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Dashboard()
        {
            string studentName = HttpContext.Session.GetString("UserName");

            var student = _context.Admissions.FirstOrDefault(a => a.FullName == studentName);
            if (student == null)
            {
                TempData["Error"] = "Student record not found.";
                return RedirectToAction("Login", "Account");
            }

            // Dummy attendance values
            TempData["AttendancePresent"] = 75;
            TempData["AttendanceAbsent"] = 25;

            return View(student);
        }
        public IActionResult AttendanceDetails(string status)
        {
            string studentName = HttpContext.Session.GetString("UserName");
            var student = _context.Admissions.FirstOrDefault(s => s.FullName == studentName);

            if (student == null)
            {
                TempData["Error"] = "Student record not found.";
                return RedirectToAction("Dashboard");
            }

            // Dummy dates
            var dates = status == "Present"
                ? new List<string> { "2025-05-01", "2025-05-03", "2025-05-04" }
                : new List<string> { "2025-05-02", "2025-05-05" };

            ViewBag.Status = status;
            ViewBag.Dates = dates;

            return View(student);
        }



        // Placeholder actions for now
        public IActionResult ViewTimetable()
        {
            // TODO: Fetch timetable data from DB if needed
            return View();
        }

        public IActionResult ViewResults()
        {
            // TODO: Fetch exam results from DB
            return View();
        }

        public IActionResult DownloadMaterials()
        {
            // TODO: Fetch syllabus/notes files list
            return View();
        }

        public IActionResult FeeStatus()
        {
            // TODO: Fetch fee payment status for logged-in student
            return View();
        }

        public IActionResult Chatbot()
        {
            // TODO: Integrate chatbot UI or iframe here
            return View();
        }

        [HttpPost]
        public IActionResult SubmitAssignments(IFormFile assignmentFile)
        {
            if (assignmentFile == null || assignmentFile.Length == 0)
            {
                ViewBag.Error = "Please select a valid file.";
                return View();
            }

            var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "assignments");
            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }

            var filePath = Path.Combine(uploads, assignmentFile.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                assignmentFile.CopyTo(stream);
            }

            ViewBag.Message = "Assignment uploaded successfully!";
            return View();
        }

    }

}
