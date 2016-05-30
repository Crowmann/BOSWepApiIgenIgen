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
        private DbModelContext db = new DbModelContext();

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

            var xd = db.View_Deltagere_Kursus.Where(d => deltagere.Id == d.Deltagere_id).ToList();
            List<Kursus> kursuses = xd.Select(x => db.Kursus.FirstOrDefault(k => x.Kursus_id == k.KursusId)).ToList();

            deltagere.Kursus = kursuses;
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
            db.SaveChanges();

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