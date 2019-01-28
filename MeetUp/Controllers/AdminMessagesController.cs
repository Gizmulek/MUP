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
    public class AdminMessagesController : Controller
    {
        private MeetUpContext db = new MeetUpContext();

        // GET: AdminMessages
        public ActionResult Index()
        {
            var adminMessages = db.AdminMessages.Include(a => a.User);
            return View(adminMessages.ToList());
        }

        // GET: AdminMessages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminMessage adminMessage = db.AdminMessages.Find(id);
            if (adminMessage == null)
            {
                return HttpNotFound();
            }
            return View(adminMessage);
        }

        // GET: AdminMessages/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Users, "userId", "login");
            return View();
        }

        // POST: AdminMessages/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,text")] AdminMessage adminMessage)
        {
            if (ModelState.IsValid)
            {
                db.AdminMessages.Add(adminMessage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.Users, "userId", "login", adminMessage.Id);
            return View(adminMessage);
        }

        // GET: AdminMessages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminMessage adminMessage = db.AdminMessages.Find(id);
            if (adminMessage == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Users, "userId", "login", adminMessage.Id);
            return View(adminMessage);
        }

        // POST: AdminMessages/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,text")] AdminMessage adminMessage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adminMessage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Users, "userId", "login", adminMessage.Id);
            return View(adminMessage);
        }

        // GET: AdminMessages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminMessage adminMessage = db.AdminMessages.Find(id);
            if (adminMessage == null)
            {
                return HttpNotFound();
            }
            return View(adminMessage);
        }

        // POST: AdminMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdminMessage adminMessage = db.AdminMessages.Find(id);
            db.AdminMessages.Remove(adminMessage);
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
