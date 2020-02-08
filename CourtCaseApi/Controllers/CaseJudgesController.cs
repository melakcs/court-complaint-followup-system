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
    public class CaseJudgesController : ApiController
    {
        private CourtCaseApiContextEntities1 db = new CourtCaseApiContextEntities1();

        // GET: api/CaseJudges
        [HttpGet]
        public IQueryable<CaseJudge> GetCaseJudges()
        {
            return db.CaseJudges;
        }

        // GET: api/CaseJudges/5
        [ResponseType(typeof(CaseJudge))]
        [HttpGet]
        public IHttpActionResult GetCaseJudge(int id)
        {
            CaseJudge caseJudge = db.CaseJudges.Find(id);
            if (caseJudge == null)
            {
                return NotFound();
            }

            return Ok(caseJudge);
        }

        // PUT: api/CaseJudges/5
        [ResponseType(typeof(void))]
        [HttpPut]
        public HttpResponseMessage PutCaseJudge(CaseJudge caseJudge)
        {
            int result = 0;
            try
            {

                db.CaseJudges.Attach(caseJudge);
                db.Entry(caseJudge).State = EntityState.Modified;
                db.SaveChanges();
                result = 1;
            }
            catch (Exception)
            {
                result = 0;
            }


            return Request.CreateResponse(HttpStatusCode.OK, result);

        }

        // POST: api/CaseJudges
        [ResponseType(typeof(CaseJudge))]
        [HttpPost]
        public IHttpActionResult PostCaseJudge(CaseJudge caseJudge)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CaseJudges.Add(caseJudge);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = caseJudge.CaseJudgeID }, caseJudge);
        }

        // DELETE: api/CaseJudges/5
        [ResponseType(typeof(CaseJudge))]
        [HttpDelete]
        public IHttpActionResult DeleteCaseJudge(int id)
        {
            CaseJudge caseJudge = db.CaseJudges.Find(id);
            if (caseJudge == null)
            {
                return NotFound();
            }

            db.CaseJudges.Remove(caseJudge);
            db.SaveChanges();

            return Ok(caseJudge);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CaseJudgeExists(int id)
        {
            return db.CaseJudges.Count(e => e.CaseJudgeID == id) > 0;
        }
    }
}