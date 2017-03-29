using ContosoUniversityApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContosoUniversityApp.Controllers
{
    public class EnrollmentController : Controller
    {
        SchoolContext db = new SchoolContext();
        //
        // GET: /Enrollment/
        public ActionResult Index()
        {
            return View(db.Enrollments.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Students.Select(x => x.StudentID).ToList());
            ViewBag.CourseID = new SelectList(db.Courses.Select(x=>x.CourseID).ToList());
            return View();
        }

        [HttpPost]
        public ActionResult Create(Enrollment enrollment)
        {
            if(ModelState.IsValid)
            {
                db.Enrollments.Add(enrollment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(enrollment);
        }

        public ActionResult Details(int enrollmentID)
        {
            Enrollment enrollment = db.Enrollments.Find(enrollmentID);
            if(enrollment == null)
            {
                return HttpNotFound();
            }

            return View(enrollment);
        }

        public ActionResult Edit(int enrollmentID)
        {
            Enrollment enrollment = db.Enrollments.Find(enrollmentID);
            if(enrollment == null)
            {
                return HttpNotFound();
            }

            return View(enrollment);
        }

        [HttpPost]
        public ActionResult Edit(Enrollment enrollment)
        {
            if(ModelState.IsValid)
            {
                db.Entry(enrollment).State = System.Data.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(enrollment);
        }

        public ActionResult Delete(int enrollmentID)
        {
            Enrollment enrollment = db.Enrollments.Find(enrollmentID);
            if(enrollment == null)
            {
                return HttpNotFound();
            }

            return View(enrollment);
        }

        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(Enrollment enrollment)
        {
            Enrollment enrollmentNew = db.Enrollments.Find(enrollment.EnrollmentID);
            if(enrollmentNew == null)
            {
                return HttpNotFound();
            }

            db.Enrollments.Remove(enrollment);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
	}
}