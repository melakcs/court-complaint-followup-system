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
using System.Web.Http.Results;
using System.Web.Mvc;

namespace CourtCaseApi.Controllers
{
    public class CasesController : ApiController
    {
        private CourtCaseApiContextEntities1 db = new CourtCaseApiContextEntities1();

        // GET: api/Cases
        public IQueryable<Case> GetCases()
        {
            return db.Cases;
        }

        // GET: api/Cases/5
        [ResponseType(typeof(Case))]
        public IHttpActionResult GetCase(int id)
        {
            Case @case = db.Cases.Find(id);
            if (@case == null)
            {
                return NotFound();
            }

            return Ok(@case);
        }

        // PUT: api/Cases/5
        [ResponseType(typeof(void))]
        [System.Web.Http.HttpPut]
        public HttpResponseMessage PutCase(Case @case)
        {
            int result = 0;
            try
            {
                db.Cases.Attach(@case);


                db.Entry(@case).State = EntityState.Modified;

                db.SaveChanges();
                result = 1;
            }
            catch (Exception e)
            {
                result = 0;
            }
            return Request.CreateResponse(HttpStatusCode.OK, result);

        }

        // POST: api/Cases
        [ResponseType(typeof(Case))]
        [System.Web.Http.HttpPost]
        public JsonResult PostCase(Case @case)
        {


            db.Cases.Add(@case);
            db.SaveChanges();
            string message = "Success";
            return new JsonResult { Data = message, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        

        // DELETE: api/Cases/5
        [ResponseType(typeof(Case))]
        public IHttpActionResult DeleteCase(int id)
        {
            Case @case = db.Cases.Find(id);
            if (@case == null)
            {
                return NotFound();
            }

            db.Cases.Remove(@case);
            db.SaveChanges();

            return Ok(@case);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CaseExists(int id)
        {
            return db.Cases.Count(e => e.CaseID == id) > 0;
        }
    }
}