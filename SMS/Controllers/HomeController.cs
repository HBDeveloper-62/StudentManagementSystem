using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SMS.Models;

namespace SMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            TempData["AboutInfo"] = @"
        <p>Some information about me:</p>
        <p><strong>HBH_Experts</strong></p>
        <p>.NET Developers</p>
        <p>Sheikh Hammad (Web Designer)</p>
        <p>Basharat Iqbal (Testing)</p>
        <p>Hasnain Bhutta (.Net Developer)</p>
        <p>Contact: +923240064420</p>
        <p>Email: hasnainbhutta262@gmail.com</p>
        <p>Student Management System (SMS) is a comprehensive platform designed to manage student data, attendance, fees, exams, and assignments efficiently.</p>
    ";

            TempData["PrivacyInfo"] = @"
        <p>Our website respects your privacy. We ensure all your personal data is securely stored and never shared with unauthorized parties.</p>
        <p>We use encryption and follow industry best practices to protect your information.</p>
        <p>Cookies are only used to enhance your browsing experience.</p>
    ";

            TempData["ContactInfo"] = @"
        <p>Contact us anytime:</p>
        <p>Phone: +923240064420</p>
        <p>Email: hasnainbhutta262@gmail.com</p>
        <p>Address: 123 HBH Experts Lane, Developer City</p>
    ";

            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
