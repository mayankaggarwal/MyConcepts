using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Domain.Contoso
{
    public class OfficeAssignment:BaseEntity
    {
        public int InstructorID { get; set; }
        public string Location { get; set; }

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