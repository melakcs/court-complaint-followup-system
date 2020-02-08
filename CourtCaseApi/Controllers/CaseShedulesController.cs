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
using CourtCaseApi.Models;
using System.Web.Http.Cors;

namespace CourtCaseApi.Controllers
{
   [RoutePrefix("/api/CaseShedules")]
   [EnableCors(origins: "*", headers: "*", methods: "Get", SupportsCredentials = true)]
    public class CaseShedulesController : ApiController
    {
                private CourtCaseApiContextEntities1 db = new CourtCaseApiContextEntities1();

        // GET: api/CaseShedules
        [ResponseType(typeof(CaseShedule))]

        [HttpGet]
        public IQueryable<CaseShedule> GetCaseShedules()
        {
            return db.CaseShedules;
        }

        // GET: api/CaseShedules/5
        [ResponseType(typeof(CaseShedule))]
        public IHttpActionResult GetCaseShedule(int id)
        {
            CaseShedule caseShedule = db.CaseShedules.Find(id);
            if (caseShedule == null)
            {
                return NotFound();
            }

            return Ok(caseShedule);
        }

        // PUT: api/CaseShedules/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCaseShedule(int id, CaseShedule caseShedule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != caseShedule.CaseSheduleID)
            {
                return BadRequest();
            }

            db.Entry(caseShedule).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaseSheduleExists(id))
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

        // POST: api/CaseShedules
        [ResponseType(typeof(CaseShedule))]
        [HttpPost]
        public IHttpActionResult PostCaseShedule(CaseShedule caseShedule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CaseShedules.Add(caseShedule);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = caseShedule.CaseSheduleID }, caseShedule);
        }

        // DELETE: api/CaseShedules/5
        [ResponseType(typeof(CaseShedule))]
        public IHttpActionResult DeleteCaseShedule(int id)
        {
            CaseShedule caseShedule = db.CaseShedules.Find(id);
            if (caseShedule == null)
            {
                return NotFound();
            }

            db.CaseShedules.Remove(caseShedule);
            db.SaveChanges();

            return Ok(caseShedule);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CaseSheduleExists(int id)
        {
            return db.CaseShedules.Count(e => e.CaseSheduleID == id) > 0;
        }
    }
}