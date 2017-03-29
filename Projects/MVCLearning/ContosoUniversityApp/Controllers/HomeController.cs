using ContosoUniversityApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContosoUniversityApp.Controllers
{
    public class HomeController : Controller
    {
        SchoolContext db = new SchoolContext();
        //
        // GET: /Home/
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to Contoso University";
            return View();
        }

        public ActionResult About()
        {
            var data = from student in db.Students
                       group student by student.EnrollmentDate into dateGroup
                       select new EnrollmentDateGroup()
                       {
                           EnrollmentDate = dateGroup.Key,
                           StudentCount = dateGroup.Count()
                       };

            return View(data);
        }
	}
}