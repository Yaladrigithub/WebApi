using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApiproject1.Models;

namespace WebApiproject1.Controllers
{
    public class RetrievedataController : Controller
    {
        private loginfromwebEntities2 db = new loginfromwebEntities2();

        // GET: Retrievedata
        public ActionResult Index()
        {
            return View(db.loginuser1.ToList());
        }

        // GET: Retrievedata/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loginuser1 loginuser1 = db.loginuser1.Find(id);
            if (loginuser1 == null)
            {
                return HttpNotFound();
            }
            return View(loginuser1);
        }

        // GET: Retrievedata/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Retrievedata/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,contact,pass")] loginuser1 loginuser1)
        {
            if (ModelState.IsValid)
            {
                db.loginuser1.Add(loginuser1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loginuser1);
        }

        // GET: Retrievedata/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loginuser1 loginuser1 = db.loginuser1.Find(id);
            if (loginuser1 == null)
            {
                return HttpNotFound();
            }
            return View(loginuser1);
        }

        // POST: Retrievedata/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,contact,pass")] loginuser1 loginuser1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loginuser1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loginuser1);
        }

        // GET: Retrievedata/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loginuser1 loginuser1 = db.loginuser1.Find(id);
            if (loginuser1 == null)
            {
                return HttpNotFound();
            }
            return View(loginuser1);
        }

        // POST: Retrievedata/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            loginuser1 loginuser1 = db.loginuser1.Find(id);
            db.loginuser1.Remove(loginuser1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
