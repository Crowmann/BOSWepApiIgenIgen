using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BosWebApiFinal.Models;

namespace BosWebApiFinal.Controllers
{
    public class KalendersController : ApiController
    {
        private BosContext db = new BosContext();

        // GET: api/Kalenders
        public IQueryable<Kalender> GetKalender()
        {
            return db.Kalender;
        }

        // GET: api/Kalenders/5
        [ResponseType(typeof(Kalender))]
        public IHttpActionResult GetKalender(int id)
        {
            Kalender kalender = db.Kalender.Find(id);
            if (kalender == null)
            {
                return NotFound();
            }

            return Ok(kalender);
        }

        // PUT: api/Kalenders/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKalender(int id, Kalender kalender)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kalender.Id)
            {
                return BadRequest();
            }

            db.Entry(kalender).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KalenderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Kalenders
        [ResponseType(typeof(Kalender))]
        public IHttpActionResult PostKalender(Kalender kalender)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Kalender.Add(kalender);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (KalenderExists(kalender.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = kalender.Id }, kalender);
        }

        // DELETE: api/Kalenders/5
        [ResponseType(typeof(Kalender))]
        public IHttpActionResult DeleteKalender(int id)
        {
            Kalender kalender = db.Kalender.Find(id);
            if (kalender == null)
            {
                return NotFound();
            }

            db.Kalender.Remove(kalender);
            db.SaveChanges();

            return Ok(kalender);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KalenderExists(int id)
        {
            return db.Kalender.Count(e => e.Id == id) > 0;
        }
    }
}