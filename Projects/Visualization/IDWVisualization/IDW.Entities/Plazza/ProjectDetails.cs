using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDW.Entities.Plazza
{
    [Table("tbl_pz_project")]
    public class ProjectDetails:IEntityBase
    {
        public int ProjectID { get; set; }
        public Nullable<long> ParentTypeCode { get; set; }
        public string ParentType { get; set; }
        public Nullable<int> ParentObjectID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> OwnerID { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public Nullable<System.DateTime> ModificationDate { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public string Status { get; set; }
        [NotMapped]
        public long ID
        {
            get
            {
                return ProjectID;
            }
            set
            {
                this.ProjectID = (int)value;
            }
        }
    }
}
