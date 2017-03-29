using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Domain.Contoso
{
    public class Instructor:BaseEntity
    {
        public int InstructorID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime HireDate { get; set; }

        public object ID
        {
            get
            {
                return InstructorID;
            }
            set
            {
                this.InstructorID = (int)value;
            }
        }
    }
}