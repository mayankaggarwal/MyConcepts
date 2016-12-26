using PhotoSharingApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoSharingApplication.Controllers
{
	public class CommentController : Controller
	{
		IPhotoSharingContext context;

		public CommentController()
		{
			context = new PhotoSharingContext();
		}

		public CommentController(IPhotoSharingContext context)
		{
			this.context = context;
		}

		//
		// GET: /Comment/
		public ActionResult Index()
		{
			return View();
		}

		public PartialViewResult _Create(int PhotoID)
		{
			Comment comment = new Comment();
			comment.PhotoID = PhotoID;
			ViewBag.PhotoId = PhotoID;
			return PartialView("_CreateAComment");
		}

		[ChildActionOnly]
		public PartialViewResult _CommentsForPhoto(int PhotoID)
		{
			var comments = context.Comments.Where(x => x.PhotoID == PhotoID);
			ViewBag.PhotoId = PhotoID;
			return PartialView(comments.ToList());
		}

		[HttpPost]
		public PartialViewResult _CommentsForPhoto(Comment comment, int PhotoID)
		{

			//Save the new comment
			context.Add<Comment>(comment);
			context.SaveChanges();

			//Get the updated list of comments
			var comments = from c in context.Comments
						   where c.PhotoID == PhotoID
						   select c;
			//Save the PhotoID in the ViewBag because we'll need it in the view
			ViewBag.PhotoId = PhotoID;
			//Return the view with the new list of comments
			return PartialView("_CommentsForPhoto", comments.ToList());
		}

		public ActionResult Delete(int id = 0)
		{
			Comment comment = context.FindByCommentID(id);
			ViewBag.PhotoID = comment.PhotoID;
			if (comment == null)
			{
				return HttpNotFound();
			}
			return View(comment);
		}

		//
		// POST: /Comment/Delete/5
		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id)
		{
			Comment comment = context.FindByCommentID(id);
			context.Delete<Comment>(comment);
			context.SaveChanges();
			return RedirectToAction("Display", "Photo", new { id = comment.PhotoID });
		}
	}
}