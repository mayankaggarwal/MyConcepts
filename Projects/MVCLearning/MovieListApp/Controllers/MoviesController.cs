using MovieListApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieListApp.Controllers
{
    public class MoviesController : Controller
    {
        private MovieDBContext db = new MovieDBContext();
        // GET: /Movies/
        public ActionResult Index()
        {
            return View(db.Movies.ToList());
        }

        public ActionResult Details(int movieID)
        {
            Movie movie = db.Movies.Find(movieID);
            if(movie==null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if(ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        public ActionResult Edit(int movieID=0)
        {
            Movie movie = db.Movies.Where(x => x.ID == movieID).FirstOrDefault();
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            if(ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        public ActionResult Delete(int movieID)
        {
            Movie movie = db.Movies.Find(movieID);
            if(movie==null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int movieID)
        {
            Movie movie = db.Movies.Find(movieID);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SearchIndex(string movieGenre,string searchString)
        {
            var genres = from m in db.Movies
                         select m.Genre;

            List<string> lstGenres = new List<string>();
            lstGenres.AddRange(genres.ToList().Distinct());

            ViewBag.movieGenre = new SelectList(lstGenres);

            var movies = from m in db.Movies
                         select m;

            if(!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(m => m.Title.Contains(searchString));
            }

            if(!String.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.Genre.Equals(movieGenre));
            }

            return View(movies);
        }

        [HttpPost]
        public string SearchIndex(FormCollection fc, string searchString)
        {
            return "<h3> From [HttpPost]SearchIndex: " + searchString + "</h3>";
        }
	}
}