using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UpFit__main.Models;

namespace UpFit__main.Controllers
{
    public class MealTypesController : Controller
    {
        private CodeFirstDb db = new CodeFirstDb();

        // GET: MealTypes
        public ActionResult Index()
        {
            return View(db.mealTypes.ToList());
        }

        // GET: MealTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MealType mealType = db.mealTypes.Find(id);
            if (mealType == null)
            {
                return HttpNotFound();
            }
            return View(mealType);
        }

        // GET: MealTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MealTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "mealTypeID,mealName")] MealType mealType)
        {
            if (ModelState.IsValid)
            {
                db.mealTypes.Add(mealType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mealType);
        }

        // GET: MealTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MealType mealType = db.mealTypes.Find(id);
            if (mealType == null)
            {
                return HttpNotFound();
            }
            return View(mealType);
        }

        // POST: MealTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "mealTypeID,mealName")] MealType mealType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mealType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mealType);
        }

        // GET: MealTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MealType mealType = db.mealTypes.Find(id);
            if (mealType == null)
            {
                return HttpNotFound();
            }
            return View(mealType);
        }

        // POST: MealTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MealType mealType = db.mealTypes.Find(id);
            db.mealTypes.Remove(mealType);
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
