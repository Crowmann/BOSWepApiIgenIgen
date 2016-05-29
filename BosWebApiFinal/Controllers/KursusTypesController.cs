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
    public class KursusTypesController : ApiController
    {
        private BosContext db = new BosContext();

        // GET: api/KursusTypes
        public IQueryable<KursusType> GetKursusType()
        {
            return db.KursusType;
        }

        // GET: api/KursusTypes/5
        [ResponseType(typeof(KursusType))]
        public IHttpActionResult GetKursusType(int id)
        {
            KursusType kursusType = db.KursusType.Find(id);
            if (kursusType == null)
            {
                return NotFound();
            }

            return Ok(kursusType);
        }

        // PUT: api/KursusTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKursusType(int id, KursusType kursusType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kursusType.Id)
            {
                return BadRequest();
            }

            db.Entry(kursusType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KursusTypeExists(id))
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

        // POST: api/KursusTypes
        [ResponseType(typeof(KursusType))]
        public IHttpActionResult PostKursusType(KursusType kursusType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.KursusType.Add(kursusType);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (KursusTypeExists(kursusType.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = kursusType.Id }, kursusType);
        }

        // DELETE: api/KursusTypes/5
        [ResponseType(typeof(KursusType))]
        public IHttpActionResult DeleteKursusType(int id)
        {
            KursusType kursusType = db.KursusType.Find(id);
            if (kursusType == null)
            {
                return NotFound();
            }

            db.KursusType.Remove(kursusType);
            db.SaveChanges();

            return Ok(kursusType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KursusTypeExists(int id)
        {
            return db.KursusType.Count(e => e.Id == id) > 0;
        }
    }
}