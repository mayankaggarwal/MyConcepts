using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDW.Entities.Plazza
{
    [Table("tbl_pz_blog")]
    public class PlazzaBlog:IEntityBase
    {
        public int BlogID { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public Nullable<System.DateTime> ModificationDate { get; set; }
        public Nullable<short> CMAuthentication { get; set; }
        public Nullable<bool> FeedEnabled { get; set; }
        public Nullable<bool> FeedFullContent { get; set; }
        public Nullable<int> ContainerID { get; set; }
        public Nullable<long> ContainerType { get; set; }
        public string ContainerCode { get; set; }
        public Nullable<int> Status { get; set; }
        [NotMapped]
        public long ID
        {
            get
            {
                return BlogID;
            }
            set
            {
                this.BlogID = (int)value;
            }
        }
    }
}
