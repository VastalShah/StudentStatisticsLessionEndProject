using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentStatistics.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace StudentStatistics.Controllers
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
            List<StudentModel> students = new List<StudentModel>();
            students = new Data().GetAllStudents();
            ViewData["students"] = students;

            List<SubjectModel> subjects = new List<SubjectModel>();
            subjects = new Data().GetAllSubjects();
            ViewData["subjects"] = subjects;

            var studentCount = students.Count();
            var subjectCount = subjects.Count();
            ViewBag.totalStudents = studentCount;
            ViewBag.totalSubjects = subjectCount;
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
