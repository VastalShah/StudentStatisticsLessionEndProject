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

            //Count of Students and Subjects
            var studentCount = students.Count();
            var subjectCount = subjects.Count();
            ViewBag.totalStudents = studentCount;
            ViewBag.totalSubjects = subjectCount;

            //Max Marks for each subjects
            var dbms_max = students.Max(s => s.DBMS_Marks);
            var ds_max = students.Max(s => s.Data_Structures_Marks);
            ViewBag.maximum = dbms_max.ToString() + "+" + ds_max.ToString();

            //Min Marks for each subjects
            var dbms_min = students.Min(s => s.DBMS_Marks);
            var ds_min = students.Min(s => s.Data_Structures_Marks);
            ViewBag.minimum = dbms_min.ToString() + "+" + ds_min.ToString();

            //Average Marks for each subjects
            var dbms_avg = students.Average(s => s.DBMS_Marks);
            var ds_avg = students.Average(s => s.Data_Structures_Marks);
            ViewBag.average = dbms_avg.ToString() + "+" + ds_avg.ToString();

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
