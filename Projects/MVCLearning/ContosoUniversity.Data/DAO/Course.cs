using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Data.DAO
{
    public class Course : EntityTypeConfiguration<ContosoUniversity.Domain.Contoso.Course>
    {
        public Course()
        {
            this.ToTable("tbl_Course");
            Property(x => x.CourseID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            this.Property(bp => bp.Title).HasMaxLength(50);
            this.Ignore(x => x.DepartmentID);
        }

        //[DatabaseGenerated(DatabaseGeneratedOption.None)] 
        //[Display(Name="Number")]
        //public Int32 CourseID { get; set; }
        //[StringLength(50,MinimumLength=3)]
        //public String Title { get; set; }

        //[Range(0,5)]
        //public Int32 Credits { get; set; }

        //[Display(Name="Department")]
        //public int DepartmentID { get; set; }

        //public virtual Department Department { get; set; }
        //public virtual ICollection<Enrollment> Enrollments { get; set; }
        //public virtual ICollection<Instructor> Instructors { get; set; }
    }
}