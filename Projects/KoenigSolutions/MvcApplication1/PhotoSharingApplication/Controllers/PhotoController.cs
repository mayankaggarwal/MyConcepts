using PhotoSharingApplication.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoSharingApplication.Controllers
{
    [ValueReporter]
    [HandleError(View="Error")]
    public class PhotoController : Controller
    {
        IPhotoSharingContext context;

        public PhotoController()
        {
            context = new PhotoSharingContext();
        }

        public PhotoController(IPhotoSharingContext context)
        {
            this.context = context;
        }
        //
        // GET: /Photo/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Display(int id = 0)
        {
            Photo photo = context.FindByPhotoID(id);
            if (photo == null)
            {
                return HttpNotFound();
            }

            return View(photo);
        }

        public ActionResult Create()
        {
            Photo photo = new Photo
            {
                CreatedDate = DateTime.Now
            };
            return View(photo);
        }

        [HttpPost]
        public ActionResult Create(Photo photo,HttpPostedFileBase image)
        {
            photo.CreatedDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                if(image != null)
                {
                    photo.ImageMimeType = image.ContentType;
                    photo.PhotoFile = new byte[image.ContentLength];
                    image.InputStream.Read(photo.PhotoFile, 0, photo.PhotoFile.Length - 1);
                }
                context.Add<Photo>(photo);
                context.SaveChanges();
                RedirectToAction("Index");
            }

            return View(photo);
        }


        public ActionResult Edit(int id = 0)
        {
            Photo photo = context.FindByPhotoID(id);
            if (photo == null)
            {
                return HttpNotFound();
            }

            return View(photo);
        }

        [HttpPost]
        public ActionResult Edit(Photo photo)
        {
            if (ModelState.IsValid)
            {
                //context.Entry(photo).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(photo);
        }

        public ActionResult Delete(int id = 0)
        {
            Photo photo = context.FindByPhotoID(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(photo);
        }

        //
        // POST: /Photo/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Photo photo = context.FindByPhotoID(id);
            context.Delete<Photo>(photo);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public FileContentResult GetImage(int id)
        {
            Photo photo = context.FindByPhotoID(id);
            if(photo != null)
            {
                return File(photo.PhotoFile, photo.ImageMimeType);
            }
            else
            {
                return null;
            }
        }

        [ChildActionOnly]
        public PartialViewResult _PhotoGallery(int number=0)
        {
            List<Photo> photos = new List<Photo>();
            if(number<=0)
            {
                photos = context.Photos.ToList();
            }
            else
            {
                photos = context.Photos.OrderByDescending(x => x.CreatedDate).Take(number).ToList();
            }

            return PartialView(photos);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    context.Dispose();
        //    base.Dispose(disposing);
        //}

        public ActionResult SlideShow()
        {
            throw new NotImplementedException("The slide show is not implemented");
        }

        public ActionResult DisplayByTitle(string title)
        {
            var photo = context.Photos.Where(x => x.Title.Equals(title)).FirstOrDefault();
            if (photo == null)
                return HttpNotFound();

            return View("Display", photo);
        }
    }
}