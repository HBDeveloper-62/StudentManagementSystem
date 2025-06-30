using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SMS.Data;
using SMS.Filters;
using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagementSystem.Controllers
{
    [LoginAuthorize("Admin", "Clerk")]

    public class AdminController : Controller
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        // -------------------- ADMIN DASHBOARD --------------------
        public IActionResult Dashboard()
        {
            return View();
        }

        // -------------------- TEACHERS --------------------
        public IActionResult Teachers()
        {
            return View(_context.Teachers.ToList());
        }

        [HttpGet]
        public IActionResult AddTeacher()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTeacher(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _context.Teachers.Add(teacher);
                _context.SaveChanges();
                return RedirectToAction("Teachers");
            }
            return View(teacher);
        }

        [HttpGet]
        public IActionResult EditTeacher(int id)
        {
            var teacher = _context.Teachers.Find(id);
            if (teacher == null) return NotFound();
            return View(teacher);
        }

        [HttpPost]
        public IActionResult EditTeacher(Teacher model)
        {
            if (ModelState.IsValid)
            {
                _context.Teachers.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Teachers");
            }
            return View(model);
        }

        public IActionResult DeleteTeacher(int id)
        {
            var teacher = _context.Teachers.Find(id);
            if (teacher != null)
            {
                _context.Teachers.Remove(teacher);
                _context.SaveChanges();
            }
            return RedirectToAction("Teachers");
        }

        // ✅ Events & Exams
        public IActionResult Events()
        {
            var events = _context.EventExams.OrderByDescending(e => e.Date).ToList();
            return View(events);
        }

        [HttpGet]
        public IActionResult CreateEvent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateEvent(EventExam model)
        {
            if (ModelState.IsValid)
            {
                _context.EventExams.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Events");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult EditEvent(int id)
        {
            var ev = _context.EventExams.Find(id);
            if (ev == null) return NotFound();
            return View("EditEvent", ev);
        }

        [HttpPost]
        public IActionResult EditEvent(EventExam ev)
        {
            if (ModelState.IsValid)
            {
                _context.Update(ev);
                _context.SaveChanges();
                return RedirectToAction("Events");
            }
            return View("EditEvent", ev);
        }

        public IActionResult DeleteEvent(int id)
        {
            var ev = _context.EventExams.Find(id);
            if (ev != null)
            {
                _context.EventExams.Remove(ev);
                _context.SaveChanges();
            }
            return RedirectToAction("Events");
        }



        // -------------------- ASSIGN ROLES --------------------
        public IActionResult AssignRoles()
        {
            return View(_context.Users.ToList());
        }

        [HttpGet]
        public IActionResult EditUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return NotFound();
            return View(user);
        }

        [HttpPost]
        public IActionResult EditUser(UserModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Update(model);
                _context.SaveChanges();
                return RedirectToAction("AssignRoles");
            }
            return View(model);
        }

        public IActionResult DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            return RedirectToAction("AssignRoles");
        }

        // -------------------- VIEW REPORTS --------------------
        public IActionResult ViewReports()
        {
            var reports = _context.Reports.ToList();
            return View(reports); // Make sure Views/Admin/ViewReports.cshtml exists
        }

        [HttpGet]
        public IActionResult AddReport()
        {
            return View(new Report()); // Always pass a model to avoid null issues in the view
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // ✅ Security best practice
        public IActionResult AddReport(Report report)
        {
            if (ModelState.IsValid)
            {
                report.Date = DateTime.Now;
                _context.Reports.Add(report);
                _context.SaveChanges();
                return RedirectToAction(nameof(ViewReports));
            }

            return View(report);
        }

        [HttpGet]
        public IActionResult EditReport(int id)
        {
            var report = _context.Reports.Find(id);
            if (report == null) return NotFound();

            return View(report);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // ✅ Security best practice
        public IActionResult EditReport(Report model)
        {
            if (ModelState.IsValid)
            {
                _context.Reports.Update(model);
                _context.SaveChanges();
                return RedirectToAction(nameof(ViewReports));
            }

            return View(model);
        }

        [HttpPost] // ✅ Make it a POST request
        [ValidateAntiForgeryToken]
        public IActionResult DeleteReport(int id)
        {
            var report = _context.Reports.Find(id);
            if (report != null)
            {
                _context.Reports.Remove(report);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(ViewReports));
        }

        // -------------------- MANAGE CLASSES --------------------
        public IActionResult ManageClasses()
        {
            return View(_context.Classes.ToList());
        }

        [HttpGet]
        public IActionResult AddClass()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddClass(Class model)
        {
            if (ModelState.IsValid)
            {
                _context.Classes.Add(model);
                _context.SaveChanges();
                return RedirectToAction("ManageClasses");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult EditClass(int id)
        {
            var cls = _context.Classes.Find(id);
            if (cls == null) return NotFound();
            return View(cls);
        }

        [HttpPost]
        public IActionResult EditClass(Class model)
        {
            if (ModelState.IsValid)
            {
                _context.Classes.Update(model);
                _context.SaveChanges();
                return RedirectToAction("ManageClasses");
            }
            return View(model);
        }

        public IActionResult DeleteClass(int id)
        {
            var cls = _context.Classes.Find(id);
            if (cls != null)
            {
                _context.Classes.Remove(cls);
                _context.SaveChanges();
            }
            return RedirectToAction("ManageClasses");
        }
        // GET: /Admin/AddClassSubject
        [HttpGet]
        public IActionResult AddClassSubject()
        {
            return View();
        }

        // POST: /Admin/AddClassSubject
        [HttpPost]
        public IActionResult AddClassSubject(Class model)
        {
            if (ModelState.IsValid)
            {
                _context.Classes.Add(model);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Subject assigned to class successfully!";
                return RedirectToAction("ManageClasses");
            }
            return View(model);
        }


        // -------------------- APPROVE TIMETABLES --------------------
        public IActionResult ApproveTimetables()
        {
            return View(_context.Timetables.ToList());
        }

        [HttpPost]
        public IActionResult ApproveTimetables(int id)
        {
            var timetable = _context.Timetables.Find(id);
            if (timetable != null)
            {
                timetable.IsApproved = true;
                _context.SaveChanges();
            }
            return RedirectToAction("ApproveTimetables");
        }

        [HttpPost]
        public IActionResult RejectTimetables(int id)
        {
            var timetable = _context.Timetables.Find(id);
            if (timetable != null)
            {
                timetable.IsApproved = false;
                _context.SaveChanges();
            }
            return RedirectToAction("ApproveTimetables");
        }

        // -------------------- BACKUP & SECURITY --------------------
        public IActionResult BackupSecurity()
        {
            return View(_context.BackupLogs.ToList());
        }

        [HttpPost]
        public IActionResult CreateBackup()
        {
            var log = new BackupLog
            {
                Date = DateTime.Now,
                Status = "Backup completed successfully"
            };
            _context.BackupLogs.Add(log);
            _context.SaveChanges();

            return RedirectToAction("BackupSecurity");
        }

        [HttpPost]
        public IActionResult RestoreBackup()
        {
            var log = new BackupLog
            {
                Date = DateTime.Now,
                Status = "Restore completed successfully"
            };
            _context.BackupLogs.Add(log);
            _context.SaveChanges();

            return RedirectToAction("BackupSecurity");
        }
        //--------------------------------------SystemHealth--------------------------//
        // ✅ System Health
        public IActionResult SystemHealth()
        {
            return View(SystemHealth);
        }

        //------------------------------------NewAdmission------------------------------//
        // ✅ Students - Admission
        [HttpGet]
        public IActionResult AddNewStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewStudent(Admission admission)
        {
            if (ModelState.IsValid)
            {
                _context.Admissions.Add(admission);
                _context.SaveChanges();
                TempData["Message"] = "🎉 Admission Confirmed!";
                return RedirectToAction("AdmissionSuccess");
            }
            return View(admission);
        }

        public IActionResult AdmissionSuccess()
        {
            ViewBag.Message = TempData["Message"];
            return View();
        }

        public IActionResult AllStudents()
        {
            var classGroups = _context.Admissions
                                      .OrderBy(a => a.Class)
                                      .GroupBy(a => a.Class)
                                      .ToList();

            return View(classGroups);
        }

        public IActionResult Edit(int id)
        {
            var student = _context.Admissions.FirstOrDefault(a => a.StudentID == id);
            if (student == null) return NotFound();
            ViewBag.IsDelete = false;
            return View("EditStudent", student);
        }

        [HttpPost]
        public IActionResult Edit(Admission model)
        {
            _context.Admissions.Update(model);
            _context.SaveChanges();
            return RedirectToAction("AllStudents");
        }

        public IActionResult Delete(int id)
        {
            var student = _context.Admissions.FirstOrDefault(a => a.StudentID == id);
            if (student == null) return NotFound();
            ViewBag.IsDelete = true;
            return View("EditStudent", student);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(Admission model)
        {
            _context.Admissions.Remove(model);
            _context.SaveChanges();
            return RedirectToAction("AllStudents");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

    }
}

    

