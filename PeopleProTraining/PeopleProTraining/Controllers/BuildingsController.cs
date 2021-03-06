﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PeopleProTraining.Models;

namespace PeopleProTraining.Controllers
{
    public class BuildingsController : Controller
    {
        private PeopleProContext db = new PeopleProContext();

        // GET: Buildings
        public ActionResult Index() {
            return View(db.Buildings.ToList());
        }

        // GET: Buildings/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Building building = db.Buildings.Find(id);
            if (building == null) {
                return HttpNotFound();
            }

            return View(building);
        }

        // GET: Buildings/Create
        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        public PartialViewResult CreateWithAjax()
        {
            string code = Request.Form["buildingTitle"];
            Building b = new Building();
            b.Title = code;

            if (ModelState.IsValid)
            {
                try
                {
                    db.Buildings.Add(b);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("ERRROR HAS OCCURRED");
                    System.Diagnostics.Debug.WriteLine(e.ToString());
                }

            }


            return PartialView("DisplayTemplates/Building", b);
        }

        // POST: Buildings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title")] Building building) {
            if (ModelState.IsValid) {
                try {
                    db.Buildings.Add(building);
                    db.SaveChanges();
                } catch (Exception e) {
                    System.Diagnostics.Debug.WriteLine("ERRROR HAS OCCURRED");
                    System.Diagnostics.Debug.WriteLine(e.ToString());
                }

                return RedirectToAction("Index");
            }

            return View(building);
        }

        // GET: Buildings/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Building building = db.Buildings.Find(id);
            if (building == null) {
                return HttpNotFound();
            }

            return View(building);
        }

        // POST: Buildings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title")] Building building) {
            if (ModelState.IsValid) {
                db.Entry(building).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(building);
        }

        // GET: Buildings/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Building building = db.Buildings.Find(id);
            if (building == null) {
                return HttpNotFound();
            }

            return View(building);
       } 

        // POST: Buildings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            try {
                Building building = db.Buildings.Find(id);
                db.Buildings.Remove(building);
                db.SaveChanges();
            } catch (Exception e) {
                System.Diagnostics.Debug.WriteLine(e.ToString());
            }

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
