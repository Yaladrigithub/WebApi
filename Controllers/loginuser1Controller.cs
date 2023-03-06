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
using WebApiproject1.Models;

namespace WebApiproject1.Controllers
{
    public class loginuser1Controller : ApiController
    {
        private loginfromwebEntities2 db ;

        // GET: api/loginuser1
        public IQueryable Getloginuser1()
        {
            List<string> l = new List<string>();
            l.Add("rk");
            l.Add("Yaldri");
            l.Add("Veera anna");

            return l.AsQueryable();

        }

        // GET: api/loginuser1/5
        [ResponseType(typeof(loginuser1))]
        public IHttpActionResult Getloginuser1(int id)
        {
            loginuser1 loginuser1 = db.loginuser1.Find(id);
            if (loginuser1 == null)
            {
                return NotFound();
            }

            return Ok(loginuser1);
        }

        // PUT: api/loginuser1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putloginuser1(int id, loginuser1 loginuser1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != loginuser1.id)
            {
                return BadRequest();
            }

            db.Entry(loginuser1).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!loginuser1Exists(id))
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

        // POST: api/loginuser1
        [ResponseType(typeof(loginuser1))]
        public IHttpActionResult Postloginuser1(loginuser1 loginuser1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.loginuser1.Add(loginuser1);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (loginuser1Exists(loginuser1.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = loginuser1.id }, loginuser1);
        }

        // DELETE: api/loginuser1/5
        [ResponseType(typeof(loginuser1))]
        public IHttpActionResult Deleteloginuser1(int id)
        {
            loginuser1 loginuser1 = db.loginuser1.Find(id);
            if (loginuser1 == null)
            {
                return NotFound();
            }

            db.loginuser1.Remove(loginuser1);
            db.SaveChanges();

            return Ok(loginuser1);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool loginuser1Exists(int id)
        {
            return db.loginuser1.Count(e => e.id == id) > 0;
        }
    }
}
