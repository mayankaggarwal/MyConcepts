using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Domain.Contoso
{
    public class Student:BaseEntity
    {
        public Int32 StudentID { get; set; }
        public String FirstMidName { get; set; }
        public String LastName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public object ID
        {
            get
            {
                return StudentID;
            }
            set
            {
                this.StudentID = (int)value;
            }
        }
    }
}