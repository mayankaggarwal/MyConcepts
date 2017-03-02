using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApp.Models.GIR
{
    public class Identity:IBaseEntity
    {
        public string CUID { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string Description { get; set; }
        public string DomainCode { get; set; }
        public Nullable<bool> DirectorySync { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<bool> ReportingGlobal { get; set; }
        public Nullable<bool> GASSI { get; set; }
        public Nullable<bool> LockIdentity { get; set; }
        public Nullable<System.DateTime> FirstEntryDate { get; set; }
        public Nullable<bool> VIP { get; set; }
        public string LastName { get; set; }
        public string SubsidiaryCode { get; set; }
        public Nullable<bool> IsEnable { get; set; }
        public string Email { get; set; }
        public string LocalId { get; set; }
        public string FirstName { get; set; }
        public string ManagerCUID { get; set; }
        public Nullable<short> Title { get; set; }
        public string CategoryCode { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public Nullable<System.DateTime> DepartureDate { get; set; }
        public Nullable<System.DateTime> Last_DepartureDate { get; set; }
        public string PreferredFirstName { get; set; }
        public string PreferredLastName { get; set; }
        public string MiddleName { get; set; }
        public string AlternateNotificationMail { get; set; }
        public string PartnerCode { get; set; }
        public string SubEmployeeType { get; set; }
        public string Prefix { get; set; }

        object IBaseEntity.ID
        {
            get
            {
                return this.CUID;
            }
            set
            {
                this.CUID = value.ToString();
            }
        }
    }
}
