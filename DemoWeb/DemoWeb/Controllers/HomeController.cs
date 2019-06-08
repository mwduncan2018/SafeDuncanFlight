using DemoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var db = new SafeFlightContext())
            {

                var flight = db.Flights.First(y => y.FirstName == "Travis");
                var user = db.RegisteredUsers.First(z => z.Password == "cucumber");

            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Use this website to demonstrate test automation with Cucumber, Selenium, Page-Object Model, and AutoIt.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "";

            return View();
        }
    }
}