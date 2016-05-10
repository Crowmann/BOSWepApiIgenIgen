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
    public class BookingsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Bookings
        public ActionResult Index()
        {
            var bookings = db.Bookings.Include(b => b.Kursu).Include(b => b.Ledere).Include(b => b.Lokaler);
            return View(bookings.ToList());
        }

        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Bookings/Create
        public ActionResult Create()
        {
            ViewBag.Fk_Kursus = new SelectList(db.Kursus, "Id", "Navn");
            ViewBag.Fk_Leder = new SelectList(db.Lederes, "Id", "Navn");
            ViewBag.Fk_Lokaler = new SelectList(db.Lokalers, "Id", "Addresse");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,Fk_Kursus,Fk_Leder,Fk_Lokaler")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Fk_Kursus = new SelectList(db.Kursus, "Id", "Navn", booking.Fk_Kursus);
            ViewBag.Fk_Leder = new SelectList(db.Lederes, "Id", "Navn", booking.Fk_Leder);
            ViewBag.Fk_Lokaler = new SelectList(db.Lokalers, "Id", "Addresse", booking.Fk_Lokaler);
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.Fk_Kursus = new SelectList(db.Kursus, "Id", "Navn", booking.Fk_Kursus);
            ViewBag.Fk_Leder = new SelectList(db.Lederes, "Id", "Navn", booking.Fk_Leder);
            ViewBag.Fk_Lokaler = new SelectList(db.Lokalers, "Id", "Addresse", booking.Fk_Lokaler);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,Fk_Kursus,Fk_Leder,Fk_Lokaler")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Fk_Kursus = new SelectList(db.Kursus, "Id", "Navn", booking.Fk_Kursus);
            ViewBag.Fk_Leder = new SelectList(db.Lederes, "Id", "Navn", booking.Fk_Leder);
            ViewBag.Fk_Lokaler = new SelectList(db.Lokalers, "Id", "Addresse", booking.Fk_Lokaler);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
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
