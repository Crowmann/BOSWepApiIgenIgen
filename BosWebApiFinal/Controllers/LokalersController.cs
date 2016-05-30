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
    public class LokalersController : ApiController
    {
        private BosContext db = new BosContext();

        // GET: api/Lokalers
        public IQueryable<Lokaler> GetLokaler()
        {
            return db.Lokaler;
        }

        // GET: api/Lokalers/5
        [ResponseType(typeof(Lokaler))]
        public IHttpActionResult GetLokaler(int id)
        {
            Lokaler lokaler = db.Lokaler.Find(id);
            if (lokaler == null)
            {
                return NotFound();
            }

            return Ok(lokaler);
        }

        // PUT: api/Lokalers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLokaler(int id, Lokaler lokaler)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lokaler.Id)
            {
                return BadRequest();
            }

            db.Entry(lokaler).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LokalerExists(id))
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

        // POST: api/Lokalers
        [ResponseType(typeof(Lokaler))]
        public IHttpActionResult PostLokaler(Lokaler lokaler)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Lokaler.Add(lokaler);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lokaler.Id }, lokaler);
        }

        // DELETE: api/Lokalers/5
        [ResponseType(typeof(Lokaler))]
        public IHttpActionResult DeleteLokaler(int id)
        {
            Lokaler lokaler = db.Lokaler.Find(id);
            if (lokaler == null)
            {
                return NotFound();
            }

            db.Lokaler.Remove(lokaler);
            db.SaveChanges();

            return Ok(lokaler);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LokalerExists(int id)
        {
            return db.Lokaler.Count(e => e.Id == id) > 0;
        }
    }
}