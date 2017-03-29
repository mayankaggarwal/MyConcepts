using ContosoUniversityApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoUniversityApp.DAL
{
    public class StudentRepository:IStudentRepository,IDisposable
    {
        SchoolContext schoolContext;

        public StudentRepository(SchoolContext schoolContext)
        {
            this.schoolContext = schoolContext;
        }

        public IEnumerable<Models.Student> GetStudents()
        {
            return schoolContext.Students.ToList();
        }

        public Models.Student GetStudentByID(int studentID)
        {
            return schoolContext.Students.Find(studentID);
        }

        public void InsertStudent(Models.Student student)
        {
            schoolContext.Students.Add(student);
        }

        public void DeleteStudent(int studentID)
        {
            Student student = schoolContext.Students.Find(studentID);
            schoolContext.Students.Remove(student);
        }

        public void UpdateStudent(Models.Student student)
        {
            schoolContext.Entry(student).State = System.Data.EntityState.Modified;
        }

        public void Save()
        {
            schoolContext.SaveChanges();
        }

        private bool Disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if(!this.Disposed)
            {
                if(disposing)
                {
                    schoolContext.Dispose();
                }

                this.Disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}