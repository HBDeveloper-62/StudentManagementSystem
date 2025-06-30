using Microsoft.AspNetCore.Mvc;
using SMS.Models;
using SMS.Data;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace SMS.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Account/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        public IActionResult Register(UserModel user)
        {
            if (!ModelState.IsValid)
                return View(user);

            if (user.Role == "Student")
            {
                // Check if the email exists in the Admissions table
                var admission = _context.Admissions.FirstOrDefault(s => s.Email == user.Email);
                if (admission == null)
                {
                    ViewBag.Error = "Your email was not found in admission records.";
                    return View(user);
                }

                user.FullName = admission.FullName;
            }
            else
            {
                // Only Admin, Principal, and Clerk can self-register
                if (user.Role != "Admin" && user.Role != "Principal" && user.Role != "Clerk")
                {
                    ViewBag.Error = "Only Admin, Principal, or Clerk can register.";
                    return View(user);
                }

                if ((user.Role == "Admin" && _context.Users.Any(u => u.Role == "Admin")) ||
                    (user.Role == "Principal" && _context.Users.Any(u => u.Role == "Principal")))
                {
                    ViewBag.Error = $"A user with role {user.Role} already exists.";
                    return View(user);
                }
            }

            _context.Users.Add(user);
            _context.SaveChanges();

            TempData["Success"] = "Registered successfully. Please log in.";
            return RedirectToAction("Login");
        }

        // GET: /Account/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public IActionResult Login(UserModel user)
        {
            if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
            {
                ViewBag.Error = "Email and password are required.";
                return View();
            }

            // ✅ Step 1: Authenticate from Users table
            var dbUser = _context.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
            if (dbUser == null)
            {
                ViewBag.Error = "Invalid email or password.";
                return View();
            }

            // ✅ Step 2: If student, verify in Admissions table
            if (dbUser.Role == "Student")
            {
                var admission = _context.Admissions.FirstOrDefault(a => a.Email == dbUser.Email);
                if (admission == null)
                {
                    ViewBag.Error = "You are not registered in admission records.";
                    return View();
                }

                // ✅ Store StudentName in Session from Admissions table (not Users table)
                HttpContext.Session.SetString("StudentName", admission.FullName);
            }

            // ✅ Step 3: Set session for role & user
            HttpContext.Session.SetString("UserName", dbUser.FullName);
            HttpContext.Session.SetString("UserRole", dbUser.Role ?? "");

            // ✅ Step 4: Redirect by role
            return dbUser.Role switch
            {
                "Admin" => RedirectToAction("Dashboard", "Admin"),
                "Principal" => RedirectToAction("Dashboard", "Principal"),
                "Clerk" => RedirectToAction("Dashboard", "Clerk"),
                "Student" => RedirectToAction("Dashboard", "Student", new { name = dbUser.FullName }),
                _ => RedirectToAction("AccessDenied")
            };
        }




        // GET: /Account/Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        public IActionResult AccessDenied()
        {
            return View("AccessDenied");
        }
    }
}
