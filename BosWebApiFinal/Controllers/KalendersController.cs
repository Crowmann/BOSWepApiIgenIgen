using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BosWebApiFinal.Models;

namespace BosWebApiFinal.Controllers
{
    public class KalendersController : Controller
    {
        private Model1 db = new Model1();

        // GET: Kalenders
        public ActionResult Index()
        {
            return View(db.Kalenders.ToList());
        }

        // GET: Kalenders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kalender kalender = db.Kalenders.Find(id);
            if (kalender == null)
            {
                return HttpNotFound();
            }
            return View(kalender);
        }

        // GET: Kalenders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kalenders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id")] Kalender kalender)
        {
            if (ModelState.IsValid)
            {
                db.Kalenders.Add(kalender);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kalender);
        }

        // GET: Kalenders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kalender kalender = db.Kalenders.Find(id);
            if (kalender == null)
            {
                return HttpNotFound();
            }
            return View(kalender);
        }

        // POST: Kalenders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id")] Kalender kalender)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kalender).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kalender);
        }

        // GET: Kalenders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kalender kalender = db.Kalenders.Find(id);
            if (kalender == null)
            {
                return HttpNotFound();
            }
            return View(kalender);
        }

        // POST: Kalenders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kalender kalender = db.Kalenders.Find(id);
            db.Kalenders.Remove(kalender);
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
