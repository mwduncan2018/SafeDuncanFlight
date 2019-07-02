using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DemoWeb.Models;

namespace DemoWeb.Controllers
{
    public class LoginController : Controller
    {
        private SafeFlightContext db = new SafeFlightContext();

        // GET: Login
        public ActionResult Index()
        {
            ViewBag.LoginPage = true;
            return View();
        }
        
        // POST: Login/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Username,Password")] RegisteredUser user)
        {
            ViewBag.LoginPage = true;

            if (!ModelState.IsValid)
            {
                return View(user);
            }
            
            // Check if the username exists in the RegisteredUser table
            var u = db.RegisteredUsers.FirstOrDefault(x => x.Username == user.Username);
            if (u != null)
            {
                // If the password is correct
                if (u.Password == user.Password)
                {
                    return RedirectToAction("Index", "Flights");
                }
            }
            ViewBag.ValidationSummary = "The username/password combination is invalid.";
            return View(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
