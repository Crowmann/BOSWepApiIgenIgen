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
    public class DeltageresController : Controller
    {
        private Model1 db = new Model1();

        // GET: Deltageres
        public ActionResult Index()
        {
            return View(db.Deltageres.ToList());
        }

        // GET: Deltageres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deltagere deltagere = db.Deltageres.Find(id);
            if (deltagere == null)
            {
                return HttpNotFound();
            }
            return View(deltagere);
        }

        // GET: Deltageres/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Deltageres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Navn,Tlf,Mail")] Deltagere deltagere)
        {
            if (ModelState.IsValid)
            {
                db.Deltageres.Add(deltagere);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deltagere);
        }

        // GET: Deltageres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deltagere deltagere = db.Deltageres.Find(id);
            if (deltagere == null)
            {
                return HttpNotFound();
            }
            return View(deltagere);
        }

        // POST: Deltageres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Navn,Tlf,Mail")] Deltagere deltagere)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deltagere).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deltagere);
        }

        // GET: Deltageres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deltagere deltagere = db.Deltageres.Find(id);
            if (deltagere == null)
            {
                return HttpNotFound();
            }
            return View(deltagere);
        }

        // POST: Deltageres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Deltagere deltagere = db.Deltageres.Find(id);
            db.Deltageres.Remove(deltagere);
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
