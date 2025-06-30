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
    [LoginAuthorize("Admin", "Clerk")]
    public class ClerkController : Controller
    {
        // Dashboard showing Fee Due, Attendance Reports, Exam Dates summary
        public IActionResult Dashboard()
        {
            // Using TempData demo data (ideally get from DB)
            TempData["FeeDue"] = "3 students have fee due";
            TempData["AttendanceReports"] = "Attendance reports available for current month";
            TempData["ExamDates"] = "Upcoming exams: Math, Science";

            return View();
        }

        // Upload Syllabus

        public IActionResult UploadSyllabus()
        {
            TempData["Message"] = "Upload syllabus here.";
            return View();
        }

        [HttpPost]
        public IActionResult UploadSyllabusPost()
        {
            TempData["Message"] = "Syllabus uploaded successfully (demo).";
            return RedirectToAction(nameof(UploadSyllabus));
        }

        public IActionResult UploadExamDateSheets()
        {
            TempData["Message"] = "Upload exam date sheets here.";
            return View();
        }

        [HttpPost]
        public IActionResult UploadExamDateSheetsPost()
        {
            TempData["Message"] = "Exam date sheets uploaded successfully (demo).";
            return RedirectToAction(nameof(UploadExamDateSheets));
        }

        public IActionResult UploadTimetables()
        {
            TempData["Message"] = "Upload or auto-generate timetables here.";
            return View();
        }

        [HttpPost]
        public IActionResult UploadTimetablesPost()
        {
            TempData["Message"] = "Timetable uploaded/generated successfully (demo).";
            return RedirectToAction(nameof(UploadTimetables));
        }

        public IActionResult GenerateFeeChallans()
        {
            TempData["Message"] = "Generate fee challans here.";
            return View();
        }

        [HttpPost]
        public IActionResult GenerateFeeChallansPost()
        {
            TempData["Message"] = "Fee challans generated successfully (demo).";
            return RedirectToAction(nameof(GenerateFeeChallans));
        }

        public IActionResult RecordData()
        {
            TempData["Message"] = "Record student data & teacher attendance.";
            return View();
        }

        [HttpPost]
        public IActionResult RecordDataPost()
        {
            TempData["Message"] = "Data recorded successfully (demo).";
            return RedirectToAction(nameof(RecordData));
        }

        public IActionResult AddAdmissionForm()
        {
            TempData["Message"] = "Add new admission forms here.";
            return View();
        }

        [HttpPost]
        public IActionResult AddAdmissionFormPost()
        {
            TempData["Message"] = "Admission form added successfully (demo).";
            return RedirectToAction(nameof(AddAdmissionForm));
        }
    }
}

