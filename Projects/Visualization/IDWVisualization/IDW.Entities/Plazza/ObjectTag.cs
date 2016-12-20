using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDW.Entities.Plazza
{
    [Table("tbl_pz_objecttag")]
    public class ObjectTag : IEntityBase
    {
        public int ObjectID { get; set; }
        public Nullable<DateTime> CreationDate { get; set; }
        public long ObjectTypeCode { get; set; }
        public string ObjectType { get; set; }
        public int TagID { get; set; }
        public string TagName { get; set; }

        [NotMapped]
        public long ID
        {
            get
            {
                return ObjectID;
            }
            set
            {
                this.ObjectID = (int)value;
            }
        }
    }
}
