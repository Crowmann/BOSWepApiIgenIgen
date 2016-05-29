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
    public class DeltageresController : ApiController
    {
        private BosContext db = new BosContext();

        // GET: api/Deltageres
        public IQueryable<Deltagere> GetDeltagere()
        {
            return db.Deltagere;
        }

        // GET: api/Deltageres/5
        [ResponseType(typeof(Deltagere))]
        public IHttpActionResult GetDeltagere(int id)
        {
            Deltagere deltagere = db.Deltagere.Find(id);
            if (deltagere == null)
            {
                return NotFound();
            }

            return Ok(deltagere);
        }

        // PUT: api/Deltageres/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDeltagere(int id, Deltagere deltagere)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != deltagere.Id)
            {
                return BadRequest();
            }

            db.Entry(deltagere).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeltagereExists(id))
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

        // POST: api/Deltageres
        [ResponseType(typeof(Deltagere))]
        public IHttpActionResult PostDeltagere(Deltagere deltagere)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Deltagere.Add(deltagere);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DeltagereExists(deltagere.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = deltagere.Id }, deltagere);
        }

        // DELETE: api/Deltageres/5
        [ResponseType(typeof(Deltagere))]
        public IHttpActionResult DeleteDeltagere(int id)
        {
            Deltagere deltagere = db.Deltagere.Find(id);
            if (deltagere == null)
            {
                return NotFound();
            }

            db.Deltagere.Remove(deltagere);
            db.SaveChanges();

            return Ok(deltagere);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DeltagereExists(int id)
        {
            return db.Deltagere.Count(e => e.Id == id) > 0;
        }
    }
}