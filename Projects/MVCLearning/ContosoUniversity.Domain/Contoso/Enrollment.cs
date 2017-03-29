using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Domain.Contoso
{
    public enum Grade
    {
        A,B,C,D,F
    }
    public class Enrollment:BaseEntity
    {
        public Int32 EnrollmentID { get; set; }
        public Int32 CourseID { get; set; }
        public Int32 StudentID { get; set; }
        public Grade? Grade { get; set; }

        public object ID
        {
            get
            {
                return EnrollmentID;
            }
            set
            {
                this.EnrollmentID = (int)value;
            }
        }
    }
}