﻿using System;
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
    public class KursusController : ApiController
    {
        private DbModelContext db = new DbModelContext();

        // GET: api/Kursus
        public IQueryable<Kursus> GetKursus()
        {
            return db.Kursus;
        }

        // GET: api/Kursus/5
        [ResponseType(typeof(Kursus))]
        public IHttpActionResult GetKursus(int id)
        {
            Kursus kursus = db.Kursus.Find(id);
            if (kursus == null)
            {
                return NotFound();
            }
            var xd = db.View_Deltagere_Kursus.Where(d => kursus.KursusId == d.Kursus_id).ToList();
            List<Deltagere> deltagere = xd.Select(x => db.Deltagere.FirstOrDefault(k => x.Deltagere_id == k.Id)).ToList();
            kursus.Deltagere = deltagere;
            return Ok(kursus);
        }

        // PUT: api/Kursus/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKursus(int id, Kursus kursus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kursus.KursusId)
            {
                return BadRequest();
            }

            db.Entry(kursus).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KursusExists(id))
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

        // POST: api/Kursus
        [ResponseType(typeof(Kursus))]
        public IHttpActionResult PostKursus(Kursus kursus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Kursus.Add(kursus);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = kursus.KursusId }, kursus);
        }

        // DELETE: api/Kursus/5
        [ResponseType(typeof(Kursus))]
        public IHttpActionResult DeleteKursus(int id)
        {
            Kursus kursus = db.Kursus.Find(id);
            if (kursus == null)
            {
                return NotFound();
            }

            db.Kursus.Remove(kursus);
            db.SaveChanges();

            return Ok(kursus);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KursusExists(int id)
        {
            return db.Kursus.Count(e => e.KursusId == id) > 0;
        }
    }
}