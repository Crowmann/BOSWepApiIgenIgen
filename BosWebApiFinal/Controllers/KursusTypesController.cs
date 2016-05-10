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
    public class KursusTypesController : Controller
    {
        private Model1 db = new Model1();

        // GET: KursusTypes
        public ActionResult Index()
        {
            return View(db.KursusTypes.ToList());
        }

        // GET: KursusTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KursusType kursusType = db.KursusTypes.Find(id);
            if (kursusType == null)
            {
                return HttpNotFound();
            }
            return View(kursusType);
        }

        // GET: KursusTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KursusTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Type")] KursusType kursusType)
        {
            if (ModelState.IsValid)
            {
                db.KursusTypes.Add(kursusType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kursusType);
        }

        // GET: KursusTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KursusType kursusType = db.KursusTypes.Find(id);
            if (kursusType == null)
            {
                return HttpNotFound();
            }
            return View(kursusType);
        }

        // POST: KursusTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Type")] KursusType kursusType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kursusType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kursusType);
        }

        // GET: KursusTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KursusType kursusType = db.KursusTypes.Find(id);
            if (kursusType == null)
            {
                return HttpNotFound();
            }
            return View(kursusType);
        }

        // POST: KursusTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KursusType kursusType = db.KursusTypes.Find(id);
            db.KursusTypes.Remove(kursusType);
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
