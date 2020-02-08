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

namespace CourtCaseApi.Controllers
{
    [RoutePrefix("/api/Plaintiffs")]

    public class PlaintiffsController : ApiController
    {
        private CourtCaseApiContextEntities1 db = new CourtCaseApiContextEntities1();

        // GET: api/Plaintiffs
        [ResponseType(typeof(Plaintiff))]

        [HttpGet]
        public IQueryable<Plaintiff> GetPlaintiffs()
        {
            return db.Plaintiffs;
        }

        // GET: api/Plaintiffs/5
        [ResponseType(typeof(Plaintiff))]
        [HttpGet]
        //  [Route("{id:int}")]

        public IHttpActionResult GetPlaintiff(int id)
        {
            Plaintiff plaintiff = db.Plaintiffs.Find(id);
            if (plaintiff == null)
            {
                return NotFound();
            }

            return Ok(plaintiff);
        }

        // PUT: api/Plaintiffs/5
        [ResponseType(typeof(Plaintiff))]
        [HttpPut]
        public HttpResponseMessage PutPlaintiff(Plaintiff plaintiff)
        {
            int result = 0;
            try
            {
                db.Plaintiffs.Attach(plaintiff);
                db.Entry(plaintiff).State = EntityState.Modified;
                db.SaveChanges();
                result = 1;
            }
            catch (Exception e)
            {
                result = 0;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // POST: api/Plaintiffs
        [ResponseType(typeof(Plaintiff))]
        [HttpPost]
        public IHttpActionResult PostPlaintiff(Plaintiff plaintiff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Plaintiffs.Add(plaintiff);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = plaintiff.PlaintiffID }, plaintiff);
        }

        // DELETE: api/Plaintiffs/5
        [ResponseType(typeof(Plaintiff))]
        [HttpDelete]
        public IHttpActionResult DeletePlaintiff(int id)
        {
            Plaintiff plaintiff = db.Plaintiffs.Find(id);
            if (plaintiff == null)
            {
                return NotFound();
            }

            db.Plaintiffs.Remove(plaintiff);
            db.SaveChanges();

            return Ok(plaintiff);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlaintiffExists(int id)
        {
            return db.Plaintiffs.Count(e => e.PlaintiffID == id) > 0;
        }
    }
}