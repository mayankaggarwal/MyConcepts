using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OperaWebSites.Controllers;
using System.Web.Mvc;
using OperaWebSitesTests.Doubles;
using System.Web.Routing;
using OperaWebSites;

namespace OperaWebSitesTests
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void TestIndexReturnView()
        {
            OperaController controller = new OperaController();
            var result = controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void Test_Default_Route_ControllerOnly()
        {
            var context = new FakeHttpContextForRouting(requestUrl:"~/Home");
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);
            RouteData data = routes.GetRouteData(context);

            Assert.AreEqual("Home", data.Values["controller"]);
        }
    }
}
