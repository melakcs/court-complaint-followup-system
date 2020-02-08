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
using System.Configuration;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;

namespace CourtCaseApi.Controllers
{
    public class UsersController : ApiController
    {
        private CourtCaseApiContextEntities1 db = new CourtCaseApiContextEntities1();

        // GET: api/Users
        [System.Web.Http.HttpGet]
        public IQueryable<User> GetUsers()
        {
            return db.Users;
        }
        
      /*  public ActionResult VerifyUser(User obj)
        {
            var user = db.Users.Where(x => x.UserName.Equals(obj.UserName) && x.Password.Equals(obj.Password)).FirstOrDefault();
            return new JsonResult
            {
                Data = user,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }*/
        // GET: api/Users/5
        [ResponseType(typeof(User))]
        [System.Web.Http.HttpGet]

        public IHttpActionResult GetUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        [System.Web.Http.HttpPut]
        public IHttpActionResult PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.UserID)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        [ResponseType(typeof(User))]
        [System.Web.Http.HttpPost]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(user);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = user.UserID }, user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.UserID == id) > 0;
        }
    }
}