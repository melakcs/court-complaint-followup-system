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
    [RoutePrefix("/api/Finances")]

    public class FinancesController : ApiController
    {
        private CourtCaseApiContextEntities1 db = new CourtCaseApiContextEntities1();

        // GET: api/Finances
        public IQueryable<Finance> GetFinances()
        {
            return db.Finances;
        }

        // GET: api/Finances/5
        [ResponseType(typeof(Finance))]
        public IHttpActionResult GetFinance(int id)
        {
            Finance finance = db.Finances.Find(id);
            if (finance == null)
            {
                return NotFound();
            }

            return Ok(finance);
        }

        // PUT: api/Finances/5
        [ResponseType(typeof(void))]
        [HttpPut]
        public HttpResponseMessage PutFinance(Finance finance)
        {
            int result = 0;
            try
            {

                db.Finances.Attach(finance);
                db.Entry(finance).State = EntityState.Modified;
                db.SaveChanges();
                result = 1;

            }
            catch (DbUpdateConcurrencyException)
            {
                result = 0;
            }
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

           
        

    // POST: api/Finances
    [ResponseType(typeof(Finance))]
        public IHttpActionResult PostFinance(Finance finance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Finances.Add(finance);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = finance.FinanceID }, finance);
        }

        // DELETE: api/Finances/5
        [ResponseType(typeof(Finance))]
        public IHttpActionResult DeleteFinance(int id)
        {
            Finance finance = db.Finances.Find(id);
            if (finance == null)
            {
                return NotFound();
            }

            db.Finances.Remove(finance);
            db.SaveChanges();

            return Ok(finance);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FinanceExists(int id)
        {
            return db.Finances.Count(e => e.FinanceID == id) > 0;
        }
    }
}