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
    public class InstructorsController : Controller
    {
        private CollegeContext db = new CollegeContext();

        // GET: Instructors
        [HttpGet]
        [Authorize(Roles = "Instructor")]
        public ActionResult Index()
        {
            var instructors = db.Instructors.Include(i => i.Department);
            return View(instructors.ToList());
        }

        // GET: Instructors/Details/5
        [HttpGet]
        [Authorize(Roles = "Instructor")]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor instructor = db.Instructors.Find(id);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            return View(instructor);
        }

        // GET: Instructors/Create
        [HttpGet]
        [Authorize(Roles = "Instructor")]
        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "Name");
            return View();
        }

        // POST: Instructors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Instructor")]
        public ActionResult Create([Bind(Include = "InstructorID,LastName,FirstName,DateofBirth,Email,DepartmentID")] Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                db.Instructors.Add(instructor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "Name", instructor.DepartmentID);
            return View(instructor);
        }

        // GET: Instructors/Edit/5
        [HttpGet]
        [Authorize(Roles = "Instructor")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor instructor = db.Instructors.Find(id);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "Name", instructor.DepartmentID);
            return View(instructor);
        }

        // POST: Instructors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Instructor")]
        public ActionResult Edit([Bind(Include = "InstructorID,LastName,FirstName,DateofBirth,Email,DepartmentID")] Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(instructor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "Name", instructor.DepartmentID);
            return View(instructor);
        }

        // GET: Instructors/Delete/5
        [HttpGet]
        [Authorize(Roles = "Instructor")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor instructor = db.Instructors.Find(id);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            return View(instructor);
        }

        // POST: Instructors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Instructor")]
        public ActionResult DeleteConfirmed(string id)
        {
            Instructor instructor = db.Instructors.Find(id);
            db.Instructors.Remove(instructor);
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
