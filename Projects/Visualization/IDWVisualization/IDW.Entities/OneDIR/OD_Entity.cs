using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDW.Entities.OneDIR
{
    [Table("tbl_od_entity")]
    public class OD_Entity:IEntityBase
    {
        public string Entity { get; set; }
        public string Sigle { get; set; }
        public string Description { get; set; }
        public string Other_Name { get; set; }
        public string Type { get; set; }
        public string URL { get; set; }
        public string Mission { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Manager { get; set; }
        public string Secondary_Manager { get; set; }
        public string Secretary { get; set; }
        public Nullable<int> RANK { get; set; }
        public string Email_Alias { get; set; }
        public string Postal_Address { get; set; }
        public string Location_Code { get; set; }
        public Nullable<System.DateTime> Last_Update_Date { get; set; }
        public Nullable<System.DateTime> Creation_Date { get; set; }
        public string Subsidiary_Code { get; set; }
        public string Entity_Comex { get; set; }
        public string Entity_Country { get; set; }
        public string Entity_Display_Name { get; set; }
        [NotMapped]
        public long ID
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
