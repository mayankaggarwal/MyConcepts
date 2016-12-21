using OperaWebSites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OperaWebSites.Controllers
{
    public class OperaController : Controller
    {
        //
        // GET: /Opera/
        private OperaDB contextDB = new OperaDB();
        [OutputCache(Duration=600,Location=System.Web.UI.OutputCacheLocation.Server,VaryByParam="none")]
        public ActionResult Index()
        {
            return View("Index",contextDB.Operas.ToList());
        }

        public ActionResult Details(int id)
        {
            Opera opera = contextDB.Operas.Find(id);
            if (opera != null)
            {
                return View("Details", opera);
            }
            else
                return HttpNotFound();
        }

        public ActionResult DetailsByTitle(string title)
        {
            Opera opera = contextDB.Operas.Where(x => x.Title.Equals(title)).FirstOrDefault();
            if (opera != null)
            {
                return View("Details", opera);
            }
            else
                return HttpNotFound();
        }

        public ActionResult Create()
        {
            Opera opera = new Opera();
            return View("Create", opera);
        }

        [HttpPost]
        public ActionResult Create(Opera opera)
        {
            if(ModelState.IsValid)
            {
                contextDB.Operas.Add(opera);
                contextDB.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Create", opera);
            }
        }

    }
}
