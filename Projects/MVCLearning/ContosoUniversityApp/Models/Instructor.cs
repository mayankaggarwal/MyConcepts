using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ContosoUniversityApp.Models
{
    public class Instructor
    {
        public int InstructorID { get; set; }

        [Display(Name="Last Name"),StringLength(50,MinimumLength=1)]
        public string LastName { get; set; }
        [Column("FirstName"),Display(Name="First Name"),StringLength(50,MinimumLength=1)]
        public string FirstMidName { get; set; }
        [DataType(DataType.Date),Display(Name="Hire Date")]
        public DateTime HireDate { get; set; }

        public string FullName
        {
            get
            {
                return LastName + " " + FirstMidName;
            }
        }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual OfficeAssignment OfficeAssignment { get; set; }
    }
}