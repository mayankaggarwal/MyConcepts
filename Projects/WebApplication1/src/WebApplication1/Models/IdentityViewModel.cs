using Orange.IAM.ITE.IDW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class IdentityViewModel
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public String Organization { get; set; }
        public String GirDomain { get; set; }
        public String ManagerCUID { get; set; }
        public String EmployeeType { get; set; }
        public String MainEmailAddress { get; set; }
        public TitleValues title { get; set; }
        public String PreferredFirstName { get; set; }
        public String MiddleName { get; set; }
        public String PreferredLastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public String LocalID { get; set; }
        public String Description { get; set; }
        public String PartnerCode { get; set; }
        public String SubsidiaryCode { get; set; }
        public String HRManager { get; set; }
        public String NotificationMail { get; set; }
        public bool ReportingGlobalEnabled { get; set; }
    }
}
