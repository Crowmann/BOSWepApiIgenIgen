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
    public class Kursus_DeltagerController : ApiController
    {
        private BosContext db = new BosContext();

        // GET: api/Kursus_Deltager
        public IQueryable<Kursus_Deltager> GetKursus_Deltager()
        {
            return db.Kursus_Deltager;
        }

        // GET: api/Kursus_Deltager/5
        [ResponseType(typeof(Kursus_Deltager))]
        public IHttpActionResult GetKursus_Deltager(int id)
        {
            Kursus_Deltager kursus_Deltager = db.Kursus_Deltager.Find(id);
            if (kursus_Deltager == null)
            {
                return NotFound();
            }

            return Ok(kursus_Deltager);
        }

        // PUT: api/Kursus_Deltager/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKursus_Deltager(int id, Kursus_Deltager kursus_Deltager)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kursus_Deltager.Id)
            {
                return BadRequest();
            }

            db.Entry(kursus_Deltager).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Kursus_DeltagerExists(id))
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

        // POST: api/Kursus_Deltager
        [ResponseType(typeof(Kursus_Deltager))]
        public IHttpActionResult PostKursus_Deltager(Kursus_Deltager kursus_Deltager)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Kursus_Deltager.Add(kursus_Deltager);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = kursus_Deltager.Id }, kursus_Deltager);
        }

        // DELETE: api/Kursus_Deltager/5
        [ResponseType(typeof(Kursus_Deltager))]
        public IHttpActionResult DeleteKursus_Deltager(int id)
        {
            Kursus_Deltager kursus_Deltager = db.Kursus_Deltager.Find(id);
            if (kursus_Deltager == null)
            {
                return NotFound();
            }

            db.Kursus_Deltager.Remove(kursus_Deltager);
            db.SaveChanges();

            return Ok(kursus_Deltager);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Kursus_DeltagerExists(int id)
        {
            return db.Kursus_Deltager.Count(e => e.Id == id) > 0;
        }
    }
}