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
    public class LokationsController : ApiController
    {
        private DbModelContext db = new DbModelContext();

        // GET: api/Lokations
        public IQueryable<Lokation> GetLokation()
        {
            return db.Lokation;
        }

        // GET: api/Lokations/5
        [ResponseType(typeof(Lokation))]
        public IHttpActionResult GetLokation(int id)
        {
            Lokation lokation = db.Lokation.Find(id);
            if (lokation == null)
            {
                return NotFound();
            }

            return Ok(lokation);
        }

        // PUT: api/Lokations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLokation(int id, Lokation lokation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lokation.Id)
            {
                return BadRequest();
            }

            db.Entry(lokation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LokationExists(id))
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

        // POST: api/Lokations
        [ResponseType(typeof(Lokation))]
        public IHttpActionResult PostLokation(Lokation lokation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Lokation.Add(lokation);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lokation.Id }, lokation);
        }

        // DELETE: api/Lokations/5
        [ResponseType(typeof(Lokation))]
        public IHttpActionResult DeleteLokation(int id)
        {
            Lokation lokation = db.Lokation.Find(id);
            if (lokation == null)
            {
                return NotFound();
            }

            db.Lokation.Remove(lokation);
            db.SaveChanges();

            return Ok(lokation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LokationExists(int id)
        {
            return db.Lokation.Count(e => e.Id == id) > 0;
        }
    }
}