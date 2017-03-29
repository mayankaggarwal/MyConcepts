using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Domain.Contoso
{
    public class Course:BaseEntity
    {
        public Int32 CourseID { get; set; }
        public String Title { get; set; }
        public Int32 Credits { get; set; }
        public int DepartmentID { get; set; }

        public object ID
        {
            get
            {
                return CourseID;
            }
            set
            {
                this.CourseID = (int)value;
            }
        }
    }
}