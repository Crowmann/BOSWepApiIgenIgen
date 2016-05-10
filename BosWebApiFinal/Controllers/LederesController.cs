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
    public class LederesController : Controller
    {
        private Model1 db = new Model1();

        // GET: Lederes
        public ActionResult Index()
        {
            return View(db.Lederes.ToList());
        }

        // GET: Lederes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ledere ledere = db.Lederes.Find(id);
            if (ledere == null)
            {
                return HttpNotFound();
            }
            return View(ledere);
        }

        // GET: Lederes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lederes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Navn,Tlf,Mail,Admin_id")] Ledere ledere)
        {
            if (ModelState.IsValid)
            {
                db.Lederes.Add(ledere);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ledere);
        }

        // GET: Lederes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ledere ledere = db.Lederes.Find(id);
            if (ledere == null)
            {
                return HttpNotFound();
            }
            return View(ledere);
        }

        // POST: Lederes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Navn,Tlf,Mail,Admin_id")] Ledere ledere)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ledere).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ledere);
        }

        // GET: Lederes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ledere ledere = db.Lederes.Find(id);
            if (ledere == null)
            {
                return HttpNotFound();
            }
            return View(ledere);
        }

        // POST: Lederes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ledere ledere = db.Lederes.Find(id);
            db.Lederes.Remove(ledere);
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
