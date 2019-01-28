using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MeetUp.DAL;
using MeetUp.Models;

namespace MeetUp.Controllers
{
    public class EventyController : Controller
    {
        private MeetUpContext db = new MeetUpContext();

        // GET: Eventy
        public ActionResult Index()
        {
            var events = db.Events.Include(x => x.User);

            return View(events.ToList());
        }

        // GET: Eventy/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }


        // GET: Eventy/Create
        public ActionResult Create()
        {
            ViewBag.userId = new SelectList(db.Users, "userId", "login");
            return View();
        }


        // POST: Eventy/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Event_Id,Name,number,Place,Date,userId")] Event @event)
        {
            if (ModelState.IsValid)
            {
                int id = Int32.Parse(Session["userId"].ToString());
                @event.User = db.Users.FirstOrDefault(x => x.userId == id);

                db.Events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.userId = new SelectList(db.Users, "userId", "login", @event.userId);
            return View(@event);
        }

        // GET: Eventy/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            ViewBag.userId = new SelectList(db.Users, "userId", "login", @event.userId);
            return View(@event);
        }

        // POST: Eventy/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Event_Id,Name,number,Place,Date,userId")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.userId = new SelectList(db.Users, "userId", "login", @event.userId);
            return View(@event);
        }

        // GET: Eventy/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Eventy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
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
