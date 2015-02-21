using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Blackboard.Models;

namespace Blackboard.Controllers
{
    public class StudentsController : Controller
    {
        private CollegeContext db = new CollegeContext();

        // GET: Students
        [HttpGet]
        [Authorize(Roles = "Student")]
        public ActionResult Index()
        {
            var students = db.Students.Include(s => s.Majors);
            return View(students.ToList());
        }

        // GET: Students/Details/5
        [HttpGet]
        [Authorize(Roles = "Student")]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        [HttpGet]
        [Authorize(Roles = "Student")]
        public ActionResult Create()
        {
            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "Name");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Student")]
        public ActionResult Create([Bind(Include = "StudentID,LastName,FirstName,DateofBirth,MajorID,Email")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "Name", student.MajorID);
            return View(student);
        }

        // GET: Students/Edit/5
        [HttpGet]
        [Authorize(Roles = "Student")]
        [Authorize(Roles = "Student")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "Name", student.MajorID);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Student")]
        public ActionResult Edit([Bind(Include = "StudentID,LastName,FirstName,DateofBirth,MajorID,Email")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "Name", student.MajorID);
            return View(student);
        }

        // GET: Students/Delete/5
        [HttpGet]
        [Authorize(Roles = "Student")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Student")]
        public ActionResult DeleteConfirmed(string id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
