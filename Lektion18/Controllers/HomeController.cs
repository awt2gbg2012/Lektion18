using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrixTest.Models;

namespace Lektion18.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View(DistanceMatrix.DeserializeRoutesTest());
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
