using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Orange.IAM.ITE.GIR;
using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Orange.IAM.ITE.IDW.Entities;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    public class TigerController : Controller
    {
        TigerService tigerService;
        GIRService girService;
        public TigerController()
        {
            tigerService = new TigerService();
            girService = new GIRService();
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            //string message = "This is my default action...";
            //try
            //{
            //    long requestID = tigerService.CreateIdentity(new Orange.IAM.ITE.IDW.Entities.Identity
            //    {

            //    });
            //}
            //catch(Exception exp)
            //{
            //    message = exp.Message;
            //}


            //return message;
            PopulateEmployeeCategoryDropDownList();
            PopulateEmployeeDomainDropDownList();
            //PopulateEmployeeGroupSubsidiaryDropDownList();
            //PopulatePartnerDropDownList();
            //PopulateTitleDropDownList();

            return View();
        }

        [HttpPost]
        public ActionResult Add(IdentityViewModel identity)
        {
            return RedirectToAction("Index");
        }

        private void PopulateEmployeeCategoryDropDownList(object selectedCategory = null)
        {
            var categoryQuery = girService.GetCategoriesList();
            ViewBag.EmployeeType = new SelectList(categoryQuery, selectedCategory);
        }

        private void PopulateEmployeeDomainDropDownList(object selectedDomain = null)
        {
            var domainQuery = girService.GetDomains();
            ViewBag.GirDomain = new SelectList(domainQuery, "ID", "Domain", selectedDomain);
        }

        private void PopulateEmployeeGroupSubsidiaryDropDownList(object selectedGroupSubsidiary = null)
        {
            var groupSubsidiaryQuery = girService.GetGroupSubsidiary();
            ViewBag.GroupSubsidiaryID = new SelectList(groupSubsidiaryQuery, "ID", "Subsidiary", selectedGroupSubsidiary);
        }

        private void PopulatePartnerDropDownList(object selectedPartner = null)
        {
            var partnerQuery = girService.GetPartner();
            ViewBag.PartnerID = new SelectList(partnerQuery, "ID", "PartnerName", selectedPartner);
        }

        private void PopulateTitleDropDownList(object selectedTitle = null)
        {
            var enumData = (from TitleValues e in Enum.GetValues(typeof(TitleValues))
                           select new
                           {
                               ID = (e.ToString()),Name = e.ToString()}).ToList();
            ViewBag.title = new SelectList(enumData, "ID", "Name", selectedTitle);
        }

        //public string Index()
        //{
        //    return "This is my default action...";
        //}
    }
}
