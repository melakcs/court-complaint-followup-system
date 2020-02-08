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
    [RoutePrefix("/api/CaseFiles")]
  //  [EnableCors(origins: "*", headers: "*", methods: "Get", SupportsCredentials = true)]
    public class CaseFilesController : ApiController
    {
        private CourtCaseApiContextEntities1 db = new CourtCaseApiContextEntities1();

        // GET: api/CaseFiles
        [HttpGet]
        public IQueryable<CaseFile> GetCaseFiles()
        {
            return db.CaseFiles;
        }

        // GET: api/CaseFiles/5
        [ResponseType(typeof(CaseFile))]
        [HttpGet]
        public IHttpActionResult GetCaseFile(int id)
        {
            CaseFile caseFile = db.CaseFiles.Find(id);
            if (caseFile == null)
            {
                return NotFound();
            }

            return Ok(caseFile);
        }

        // PUT: api/CaseFiles/5
        [ResponseType(typeof(void))]
        [HttpPut]
        public HttpResponseMessage PutCaseFile(CaseFile caseFile)
        {
            int result = 0;
            try
            {
                db.CaseFiles.Attach(caseFile);
                db.Entry(caseFile).State = EntityState.Modified;
                db.SaveChanges();
                result = 1;
            }
            catch (Exception e)
            {
                result = 0;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
       
        // POST: api/CaseFiles
        [ResponseType(typeof(CaseFile))]
        [HttpPost]
        public IHttpActionResult PostCaseFile(CaseFile caseFile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CaseFiles.Add(caseFile);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = caseFile.CaseFileID }, caseFile);
        }

        // DELETE: api/CaseFiles/5
        [ResponseType(typeof(CaseFile))]
        [HttpDelete]
        public IHttpActionResult DeleteCaseFile(int id)
        {
            CaseFile caseFile = db.CaseFiles.Find(id);
            if (caseFile == null)
            {
                return NotFound();
            }

            db.CaseFiles.Remove(caseFile);
            db.SaveChanges();

            return Ok(caseFile);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CaseFileExists(int id)
        {
            return db.CaseFiles.Count(e => e.CaseFileID == id) > 0;
        }
    }
}