using ExpenseManager.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Data.Entities
{
    
    [Table("ExpenseUsers")]
    public class ExpenseUser : IIdentifiableEntity
    {
        public int ID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        [Column("EmailID")]
        public String Email { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public bool Valid { get; set; }
        public DateTime CreationDate { get; set; }
        [NotMapped]
        public int EntityId
        {
            get
            {
                return ID;
            }
            set
            {
                ID = value;
            }
        }
    }
}
