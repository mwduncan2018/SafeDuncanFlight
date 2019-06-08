using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DemoWeb.Models;
using DemoWeb.ViewModels;

namespace DemoWeb.Controllers
{
    public class WatchListController : Controller
    {
        private SafeFlightContext db = new SafeFlightContext();

        // GET: WatchList
        public ActionResult Index()
        {
            var result = new List<WatchListEntryViewModel>();
            foreach (var item in db.WatchList)
            {
                result.Add(new WatchListEntryViewModel(item));
            }
            return View(result);
        }

        // GET: WatchList/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WatchListEntry watchListEntry = db.WatchList.Find(id);
            if (watchListEntry == null)
            {
                return HttpNotFound();
            }
            return View(watchListEntry);
        }

        // GET: WatchList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WatchList/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WatchListEntryId,Bounty,FirstName,LastName")] WatchListEntry watchListEntry)
        {
            if (ModelState.IsValid)
            {
                db.WatchList.Add(watchListEntry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(watchListEntry);
        }

        // GET: WatchList/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WatchListEntry watchListEntry = db.WatchList.Find(id);
            if (watchListEntry == null)
            {
                return HttpNotFound();
            }
            return View(watchListEntry);
        }

        // POST: WatchList/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WatchListEntryId,Bounty,FirstName,LastName")] WatchListEntry watchListEntry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(watchListEntry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(watchListEntry);
        }

        // GET: WatchList/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WatchListEntry watchListEntry = db.WatchList.Find(id);
            if (watchListEntry == null)
            {
                return HttpNotFound();
            }
            return View(watchListEntry);
        }

        // POST: WatchList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WatchListEntry watchListEntry = db.WatchList.Find(id);
            db.WatchList.Remove(watchListEntry);
            db.SaveChanges();
            return RedirectToAction("Index");
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
