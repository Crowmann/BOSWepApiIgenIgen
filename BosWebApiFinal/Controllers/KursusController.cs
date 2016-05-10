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
    public class KursusController : Controller
    {
        private Model1 db = new Model1();

        // GET: Kursus
        public ActionResult Index()
        {
            var kursus = db.Kursus.Include(k => k.Deltagere).Include(k => k.KursusType).Include(k => k.Ledere).Include(k => k.Lokaler);
            return View(kursus.ToList());
        }

        // GET: Kursus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kursu kursu = db.Kursus.Find(id);
            if (kursu == null)
            {
                return HttpNotFound();
            }
            return View(kursu);
        }

        // GET: Kursus/Create
        public ActionResult Create()
        {
            ViewBag.Fk_Deltager = new SelectList(db.Deltageres, "Id", "Navn");
            ViewBag.Fk_KursusType = new SelectList(db.KursusTypes, "Id", "Type");
            ViewBag.Fk_Ledere = new SelectList(db.Lederes, "Id", "Navn");
            ViewBag.Fk_Lokaler = new SelectList(db.Lokalers, "Id", "Addresse");
            return View();
        }

        // POST: Kursus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Navn,Fk_Deltager,Fk_KursusType,Fk_Ledere,Fk_Lokaler")] Kursu kursu)
        {
            if (ModelState.IsValid)
            {
                db.Kursus.Add(kursu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Fk_Deltager = new SelectList(db.Deltageres, "Id", "Navn", kursu.Fk_Deltager);
            ViewBag.Fk_KursusType = new SelectList(db.KursusTypes, "Id", "Type", kursu.Fk_KursusType);
            ViewBag.Fk_Ledere = new SelectList(db.Lederes, "Id", "Navn", kursu.Fk_Ledere);
            ViewBag.Fk_Lokaler = new SelectList(db.Lokalers, "Id", "Addresse", kursu.Fk_Lokaler);
            return View(kursu);
        }

        // GET: Kursus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kursu kursu = db.Kursus.Find(id);
            if (kursu == null)
            {
                return HttpNotFound();
            }
            ViewBag.Fk_Deltager = new SelectList(db.Deltageres, "Id", "Navn", kursu.Fk_Deltager);
            ViewBag.Fk_KursusType = new SelectList(db.KursusTypes, "Id", "Type", kursu.Fk_KursusType);
            ViewBag.Fk_Ledere = new SelectList(db.Lederes, "Id", "Navn", kursu.Fk_Ledere);
            ViewBag.Fk_Lokaler = new SelectList(db.Lokalers, "Id", "Addresse", kursu.Fk_Lokaler);
            return View(kursu);
        }

        // POST: Kursus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Navn,Fk_Deltager,Fk_KursusType,Fk_Ledere,Fk_Lokaler")] Kursu kursu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kursu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Fk_Deltager = new SelectList(db.Deltageres, "Id", "Navn", kursu.Fk_Deltager);
            ViewBag.Fk_KursusType = new SelectList(db.KursusTypes, "Id", "Type", kursu.Fk_KursusType);
            ViewBag.Fk_Ledere = new SelectList(db.Lederes, "Id", "Navn", kursu.Fk_Ledere);
            ViewBag.Fk_Lokaler = new SelectList(db.Lokalers, "Id", "Addresse", kursu.Fk_Lokaler);
            return View(kursu);
        }

        // GET: Kursus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kursu kursu = db.Kursus.Find(id);
            if (kursu == null)
            {
                return HttpNotFound();
            }
            return View(kursu);
        }

        // POST: Kursus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kursu kursu = db.Kursus.Find(id);
            db.Kursus.Remove(kursu);
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
