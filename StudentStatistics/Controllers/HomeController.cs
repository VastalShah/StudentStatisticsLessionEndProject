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

            //OrderBy
            //Maximum DBMS
            students = students.OrderBy(s => s.DBMS_Marks).ToList();
            var maxStudentDBMS = students.LastOrDefault();
            ViewBag.maxDBMS = maxStudentDBMS.Name + "+" + maxStudentDBMS.Age.ToString() + "+" + maxStudentDBMS.DBMS_Marks.ToString();

            //Minimum DBMS
            students = students.OrderBy(s => s.DBMS_Marks).ToList();
            var minStudentDBMS = students.FirstOrDefault();
            ViewBag.minDBMS = minStudentDBMS.Name + "+" + minStudentDBMS.Age.ToString() + "+" + minStudentDBMS.DBMS_Marks.ToString();

            //Maximum DS
            students = students.OrderBy(s => s.Data_Structures_Marks).ToList();
            var maxStudentDS = students.LastOrDefault();
            ViewBag.maxDS = maxStudentDS.Name + "+" + maxStudentDS.Age.ToString() + "+" + maxStudentDS.Data_Structures_Marks.ToString();

            //Minimum DS
            students = students.OrderBy(s => s.Data_Structures_Marks).ToList();
            var minStudentDS = students.FirstOrDefault();
            ViewBag.minDS = minStudentDS.Name + "+" + minStudentDS.Age.ToString() + "+" + minStudentDS.Data_Structures_Marks.ToString();

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
