using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Data.DAO
{
    public enum Grade
    {
        A,B,C,D,F
    }
    public class Enrollment : EntityTypeConfiguration<ContosoUniversity.Domain.Contoso.Enrollment>
    {
        public Int32 EnrollmentID { get; set; }
        public Int32 CourseID { get; set; }
        public Int32 StudentID { get; set; }
        [DisplayFormat(NullDisplayText="No grade")]
        public Grade? Grade { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}