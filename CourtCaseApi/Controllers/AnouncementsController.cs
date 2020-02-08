using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CourtCaseApi.Models;
using System.Web.Http.Cors;

namespace CourtCaseApi.Controllers
{
    [RoutePrefix("/api/Anouncements")]
    [EnableCors(origins: "*", headers: "*", methods: "Get", SupportsCredentials = true)]
    // Access-Control-Allow-Credentials: true

    public class AnouncementsController : ApiController

    {
        private CourtCaseApiContextEntities1 db = new CourtCaseApiContextEntities1();

        [ResponseType(typeof(Anouncement))]

        [HttpGet]
        public IQueryable<Anouncement> GetAnouncements()
        {
            return db.Anouncements;


        }

        // GET: api/Anouncements/5
        [ResponseType(typeof(Anouncement))]
        [HttpGet]
        public IHttpActionResult GetAnouncement(int id)
        {
            Anouncement anouncement = db.Anouncements.Find(id);
            if (anouncement == null)
            {
                return NotFound();
            }

            return Ok(anouncement);
        }

        // PUT: api/Anouncements/5
        [ResponseType(typeof(void))]
        [HttpPut]
        public HttpResponseMessage PutAnouncement(Anouncement anouncement)
        {
            int result = 0;
            try
            {
                db.Anouncements.Attach(anouncement);
                db.Entry(anouncement).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                result = 0;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);

        }

        // POST: api/Anouncements
        [ResponseType(typeof(Anouncement))]
        [HttpPost]
        public IHttpActionResult PostAnouncement(Anouncement anouncement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Anouncements.Add(anouncement);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = anouncement.AnouncementID }, anouncement);
        }

        // DELETE: api/Anouncements/5
        [ResponseType(typeof(Anouncement))]
        public IHttpActionResult DeleteAnouncement(int id)
        {
            Anouncement anouncement = db.Anouncements.Find(id);
            if (anouncement == null)
            {
                return NotFound();
            }

            db.Anouncements.Remove(anouncement);
            db.SaveChanges();

            return Ok(anouncement);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AnouncementExists(int id)
        {
            return db.Anouncements.Count(e => e.AnouncementID == id) > 0;
        }
    }
}