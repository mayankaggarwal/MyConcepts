using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ContosoUniversityApp.Models
{
    public class Student
    {
        public Int32 StudentID { get; set; }

        [StringLength(50,MinimumLength=1)]
        [Column("FirstName")]
        public String FirstMidName { get; set; }

        [StringLength(50,MinimumLength=1,ErrorMessage="Last name cannot be longer than 50 characters")]
        public String LastName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}",ApplyFormatInEditMode=true)]
        [Display(Name="Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }

        public string FullName
        {
            get
            {
                return LastName + " " + FirstMidName;
            }
        }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}