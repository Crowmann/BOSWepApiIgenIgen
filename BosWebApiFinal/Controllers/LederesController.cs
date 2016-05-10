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
    public class LederesController : ApiController
    {
        private BosContext db = new BosContext();

        // GET: api/Lederes
        public IQueryable<Ledere> GetLedere()
        {
            return db.Ledere;
        }

        // GET: api/Lederes/5
        [ResponseType(typeof(Ledere))]
        public IHttpActionResult GetLedere(int id)
        {
            Ledere ledere = db.Ledere.Find(id);
            if (ledere == null)
            {
                return NotFound();
            }

            return Ok(ledere);
        }

        // PUT: api/Lederes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLedere(int id, Ledere ledere)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ledere.Id)
            {
                return BadRequest();
            }

            db.Entry(ledere).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LedereExists(id))
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

        // POST: api/Lederes
        [ResponseType(typeof(Ledere))]
        public IHttpActionResult PostLedere(Ledere ledere)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ledere.Add(ledere);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (LedereExists(ledere.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ledere.Id }, ledere);
        }

        // DELETE: api/Lederes/5
        [ResponseType(typeof(Ledere))]
        public IHttpActionResult DeleteLedere(int id)
        {
            Ledere ledere = db.Ledere.Find(id);
            if (ledere == null)
            {
                return NotFound();
            }

            db.Ledere.Remove(ledere);
            db.SaveChanges();

            return Ok(ledere);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LedereExists(int id)
        {
            return db.Ledere.Count(e => e.Id == id) > 0;
        }
    }
}