using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Domain.Contoso
{
    public class Department:BaseEntity
    {
        public int DepartmentID { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }
        public int? InstructorID { get; set; }

        public object ID
        {
            get
            {
                return DepartmentID;
            }
            set
            {
                this.DepartmentID = (int)value;
            }
        }
    }
}