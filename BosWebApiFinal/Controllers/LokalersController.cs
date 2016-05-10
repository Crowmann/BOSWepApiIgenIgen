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
    public class LokalersController : Controller
    {
        private Model1 db = new Model1();

        // GET: Lokalers
        public ActionResult Index()
        {
            return View(db.Lokalers.ToList());
        }

        // GET: Lokalers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lokaler lokaler = db.Lokalers.Find(id);
            if (lokaler == null)
            {
                return HttpNotFound();
            }
            return View(lokaler);
        }

        // GET: Lokalers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lokalers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Addresse,Byy,Land,Pladser")] Lokaler lokaler)
        {
            if (ModelState.IsValid)
            {
                db.Lokalers.Add(lokaler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lokaler);
        }

        // GET: Lokalers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lokaler lokaler = db.Lokalers.Find(id);
            if (lokaler == null)
            {
                return HttpNotFound();
            }
            return View(lokaler);
        }

        // POST: Lokalers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Addresse,Byy,Land,Pladser")] Lokaler lokaler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lokaler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lokaler);
        }

        // GET: Lokalers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lokaler lokaler = db.Lokalers.Find(id);
            if (lokaler == null)
            {
                return HttpNotFound();
            }
            return View(lokaler);
        }

        // POST: Lokalers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lokaler lokaler = db.Lokalers.Find(id);
            db.Lokalers.Remove(lokaler);
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
