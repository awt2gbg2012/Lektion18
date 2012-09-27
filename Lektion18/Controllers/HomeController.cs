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
            string origin = "skövde";
            List<string> destinations = new List<string> 
                { 
                    "Trollhättan", 
                    "Lidköping", 
                    "Mariestad" 
                };

            return View(DistanceMatrix.GetRoutes(origin, destinations));
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
