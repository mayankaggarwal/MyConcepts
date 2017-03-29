using ContosoUniversity.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContosoUniversityApp.Controllers
{
    public class Student1Controller : Controller
    {
        private readonly IStudentService _studentService;

        public Student1Controller(IStudentService studentService)
        {
            _studentService = studentService;
        }
        //
        // GET: /Student1/
        public ActionResult Index()
        {
            var students = _studentService.Get();
            return View(students.ToList());
        }
	}
}