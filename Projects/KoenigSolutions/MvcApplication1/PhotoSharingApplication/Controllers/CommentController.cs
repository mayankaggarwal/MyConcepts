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
			return PartialView("_CreateAComment", comment);
		}

		public PartialViewResult _CommentsForPhoto(int PhotoID)
		{
			var comments = context.Comments.Where(x => x.PhotoID == PhotoID);
			ViewBag.PhotoId = PhotoID;
			return PartialView("_CommentsForPhoto",comments.ToList());
		}
	}
}