using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoSharingApplication.Controllers;
using System.Web.Mvc;
using System.Collections.Generic;
using PhotoSharingApplication.Models;
using PhotoSharingTests.Doubles;
using System.Linq;
using System.Web.Routing;
using PhotoSharingApplication;

namespace PhotoSharingTests
{
    [TestClass]
    public class PhotoControllerTests
    {
        [TestMethod]
        public void TextIndexReturnType()
        {
            var context = new FakePhotoSharingContext();
            var controller = new PhotoController(context);
            var result = controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void PhotoGalleryModelType()
        {
            var context = new FakePhotoSharingContext();
            context.Photos = new[] {
                new Photo(),
                new Photo(),
                new Photo(),
                new Photo()
            }.AsQueryable();

            var controller = new PhotoController(context);
            var result = controller._PhotoGallery() as PartialViewResult;
            Assert.AreEqual(typeof(List<Photo>), result.Model.GetType());
        }

        [TestMethod]
        public void TestGetImageReturnType()
        {
            FakePhotoSharingContext photoSharingContext = new FakePhotoSharingContext();
            photoSharingContext.Photos = new[] {
                new Photo{ PhotoID = 1, PhotoFile = new byte[1], ImageMimeType = "image/jpeg" },
                new Photo{ PhotoID = 2, PhotoFile = new byte[1], ImageMimeType = "image/jpeg" },
                new Photo{ PhotoID = 3, PhotoFile = new byte[1], ImageMimeType = "image/jpeg" },
                new Photo{ PhotoID = 4, PhotoFile = new byte[1], ImageMimeType = "image/jpeg" }
            }.AsQueryable();
            PhotoController photoController = new PhotoController(photoSharingContext);
            var result = photoController.GetImage(1) as ActionResult;
            Assert.AreEqual(typeof(FileContentResult), result.GetType());
        }

        [TestMethod]
        public void Test_PhotoGallery_Int_Parameter()
        {
            //This test checks that, when you call the _PhotoGallery action with no
            //parameter, all the photos in the context are returned
            var context = new FakePhotoSharingContext();
            context.Photos = new[] {
                new Photo(),
                new Photo(),
                new Photo(),
                new Photo()
            }.AsQueryable();

            var controller = new PhotoController(context);
            var result = controller._PhotoGallery(3) as PartialViewResult;
            var modelPhotos = (IEnumerable<Photo>)result.Model;
            Assert.AreEqual(3, modelPhotos.Count());
        }

        [TestMethod]
        public void Test_Default_Route_ControllerOnly()
        {
            var context = new FakeHttpContextForRouting(requestUrl: "~/Photo");
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var routeData = routeCollection.GetRouteData(context);
            Assert.IsNotNull(routeData);
            Assert.AreEqual("Photo", routeData.Values["controller"]);
            Assert.AreEqual("Index", routeData.Values["action"]);
        }

        [TestMethod]
        public void Test_Photo_Route_With_PhotoID()
        {
            var context = new FakeHttpContextForRouting(requestUrl:"~/photo/2");
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);

            var routeData = routeCollection.GetRouteData(context);

            Assert.IsNotNull(routeData);
            Assert.AreEqual("Photo", routeData.Values["controller"]);
            Assert.AreEqual("Display", routeData.Values["action"]);
            Assert.AreEqual("2", routeData.Values["id"]);

        }

        [TestMethod]
        public void Test_Photo_Title_Route()
        {
            var context = new FakeHttpContextForRouting(requestUrl: "~/photo/title/my%20title");
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var routeData = routeCollection.GetRouteData(context);

            Assert.IsNotNull(routeData);
            Assert.AreEqual("Photo", routeData.Values["controller"]);
            Assert.AreEqual("DisplayByTitle", routeData.Values["action"]);
            Assert.AreEqual("my%20title", routeData.Values["title"]);
        }
    }
}
