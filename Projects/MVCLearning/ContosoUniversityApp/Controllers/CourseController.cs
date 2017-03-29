using ContosoUniversityApp.DAL;
using ContosoUniversityApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContosoUniversityApp.Controllers
{
    public class CourseController : Controller
    {
        //SchoolContext db = new SchoolContext();
        UnitOfWork unitOfWork = new UnitOfWork();
        //
        // GET: /Course/
        public ActionResult Index()
        {
            var courses = unitOfWork.CourseRepository.Get(includeProperties: "Department");
            return View(courses.ToList());
        }

        public ActionResult Create()
        {
            PopulateDepartmentDropDownList();
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "CourseID,Title,Credits,DepartmentID")]Course course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.CourseRepository.Insert(course);
                    unitOfWork.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            PopulateDepartmentDropDownList(course.DepartmentID);
            return View(course);
        }

        public ActionResult Edit(int courseID)
        {
            Course course = unitOfWork.CourseRepository.GetByID(courseID);
            if (course == null)
            {
                return HttpNotFound();
            }
            PopulateDepartmentDropDownList(course.DepartmentID);
            return View(course);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "CourseID,Title,Credits,DepartmentID")]Course course)
        {
            try
            {


                if (ModelState.IsValid)
                {
                    if (unitOfWork.CourseRepository.GetByID(course.CourseID) == null)
                    {
                        return HttpNotFound();
                    }

                    unitOfWork.CourseRepository.Update(course);
                    unitOfWork.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException exp)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            PopulateDepartmentDropDownList(course.DepartmentID);
            return View(course);
        }

        public ActionResult Details(int courseID)
        {
            Course course = unitOfWork.CourseRepository.GetByID(courseID);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        public ActionResult Delete(int courseID)
        {
            Course course = unitOfWork.CourseRepository.GetByID(courseID);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int courseID)
        {
            Course course = unitOfWork.CourseRepository.GetByID(courseID);
            if (course == null)
            {
                return HttpNotFound();
            }
            unitOfWork.CourseRepository.Delete(course);
            unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        private void PopulateDepartmentDropDownList(object selectedDepartment = null)
        {
            var departments = unitOfWork.DepartmentRepository.Get(orderBy: q => q.OrderBy(d => d.Name));
            ViewBag.DepartmentID = new SelectList(departments, "DepartmentID", "Name", selectedDepartment);

        }
    }
}