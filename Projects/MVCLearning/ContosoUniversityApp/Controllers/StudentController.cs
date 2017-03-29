using ContosoUniversityApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using ContosoUniversityApp.DAL;

namespace ContosoUniversityApp.Controllers
{
    public class StudentController : Controller,IDisposable
    {
        //SchoolContext db = new SchoolContext();
        private IStudentRepository studentRepository;
  
        public StudentController()
        {
            this.studentRepository = new StudentRepository(new SchoolContext());
        }

        public ActionResult Index(string sortOrder,string currentFilter,string searchString,int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParam = string.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            ViewBag.DateSortParam = sortOrder == "Date" ? "Date_desc" : "Date";

            if(searchString!=null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var students = from s in this.studentRepository.GetStudents()
                           select s;

            if(!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(x => x.LastName.ToUpper().Contains(searchString) || x.FirstMidName.ToUpper().Contains(searchString));
            }

            switch(sortOrder)
            {
                case "Name_desc":
                    students = students.OrderByDescending(x => x.LastName);
                    break;
                case "Date":
                    students = students.OrderBy(s => s.EnrollmentDate);
                    break;
                case "Date_desc":
                    students = students.OrderByDescending(s => s.EnrollmentDate);
                    break;
                default :
                    students = students.OrderBy(s => s.LastName);
                    break;

            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(students.ToPagedList(pageNumber,pageSize));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "LastName, FirstMidName, EnrollmentDate")]Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this.studentRepository.InsertStudent(student);
                    this.studentRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException exp)
            {
                //Log the error (add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(student);
        }

        public ActionResult Edit(int studentID)
        {
            Student student = this.studentRepository.GetStudentByID(studentID);
            if (student == null)
            {
                return HttpNotFound();
            }

            return View(student);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "StudentID, LastName, FirstMidName, EnrollmentDate")]Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this.studentRepository.UpdateStudent(student);
                    this.studentRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException exp)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(student);
        }

        public ActionResult Details(int studentID)
        {
            Student student = this.studentRepository.GetStudentByID(studentID);
            if (student == null)
            {
                return HttpNotFound();
            }

            return View(student);
        }

        public ActionResult Delete(bool? saveChangesError = false, int studentID = 0)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Student student = this.studentRepository.GetStudentByID(studentID);
            if (student == null)
            {
                return HttpNotFound();
            }

            return View(student);
        }

        [HttpPost]
        public ActionResult Delete(int studentID)
        {
            try
            {
                this.studentRepository.DeleteStudent(studentID);
                this.studentRepository.Save();
            }
            catch (DataException/* dex */)
            {
                // uncomment dex and log error.
                return RedirectToAction("Delete", new { studentID = studentID, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            this.studentRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}