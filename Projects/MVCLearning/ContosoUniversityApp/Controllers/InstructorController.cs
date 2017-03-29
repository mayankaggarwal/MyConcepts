using ContosoUniversityApp.Models;
using ContosoUniversityApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data;

namespace ContosoUniversityApp.Controllers
{
    public class InstructorController : Controller
    {
        SchoolContext db = new SchoolContext();
        //
        // GET: /Instructor/
        public ActionResult Index(int? instructorID,int? courseID)
        {
            var instructorVM = new InstructorIndexData();
            instructorVM.Instructors = db.Instructors
               .Include(i => i.OfficeAssignment)
               .Include(i => i.Courses.Select(c => c.Department))
               .OrderBy(i => i.LastName);

            if(instructorID!=null)
            {
                ViewBag.InstructorID = instructorID.Value;
                instructorVM.Courses = instructorVM.Instructors.Where(i => i.InstructorID == instructorID.Value).Single().Courses;
            }

            if(courseID!=null)
            {
                ViewBag.CourseID = courseID.Value;
                var selectedCourse = instructorVM.Courses.Where(c => c.CourseID == courseID).Single();
                db.Entry(selectedCourse).Collection(e => e.Enrollments).Load();
                foreach(Enrollment enrollment in selectedCourse.Enrollments)
                {
                    db.Entry(enrollment).Reference(s => s.Student).Load();
                }

                instructorVM.Enrollments = selectedCourse.Enrollments;
            }

            return View(instructorVM);
        }

        public ActionResult Edit(int instructorID)
        {
            Instructor instructor = db.Instructors
                .Include(i => i.OfficeAssignment)
                .Include(i=>i.Courses)
                .Where(i => i.InstructorID == instructorID)
                .Single();
            PopulateAssignedCourseData(instructor);
            return View(instructor);
        }

        [HttpPost]
        public ActionResult Edit(int instructorID,FormCollection formCollection,string[] selectedCourses)
        {
            Instructor instructor = db.Instructors
                .Include(i => i.OfficeAssignment)
                .Include(i=>i.Courses)
                .Where(i => i.InstructorID == instructorID)
                .Single();

            if(TryUpdateModel(instructor,"",new string[]{"LastName","FirstMidName","HireDate","OfficeAssignment"}))
            {
                try
                {
                    if(String.IsNullOrEmpty(instructor.OfficeAssignment.Location))
                    {
                        instructor.OfficeAssignment = null;
                    }

                    UpdateInstructorCourses(selectedCourses, instructor);

                    db.Entry(instructor).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch(DataException exp)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            PopulateAssignedCourseData(instructor);
            return View(instructor);
        }

        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int instructorID)
        {
            var instructor = db.Instructors
                .Include(i => i.OfficeAssignment)
                .Where(i => i.InstructorID == instructorID)
                .Single();

            instructor.OfficeAssignment = null;
            db.Instructors.Remove(instructor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private void PopulateAssignedCourseData(Instructor instructor)
        {
            var courses = db.Courses;
            var instructorCourses = new HashSet<int>(instructor.Courses.Select(x => x.CourseID));
            var assignedCourseData = new List<AssignedCourseData>();
            foreach(var course in courses)
            {
                assignedCourseData.Add(new AssignedCourseData
                {
                    CourseID = course.CourseID
                    ,Title = course.Title
                    ,Assigned = instructorCourses.Contains(course.CourseID)
                });
            }

            ViewBag.Courses = assignedCourseData;
        }

        private void UpdateInstructorCourses(string[] selectedCourses, Instructor instructor)
        {
            if(selectedCourses==null)
            {
                instructor.Courses = new List<Course>();
                return;
            }

            var selectedCoursesHS = new HashSet<string>(selectedCourses);
            var instructorCoursesHS = new HashSet<int>(instructor.Courses.Select(x => x.CourseID));
            foreach(var course in db.Courses)
            {
                if(selectedCoursesHS.Contains(course.CourseID.ToString()))
                {
                    if (!instructorCoursesHS.Contains(course.CourseID))
                    {
                        instructor.Courses.Add(course);
                    }
                }
                else
                {
                    if(instructorCoursesHS.Contains(course.CourseID))
                    {
                        instructor.Courses.Remove(course);
                    }
                }
            }
        }
	}
}