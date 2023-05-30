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
    public class FoodTypesController : Controller
    {
        private CodeFirstDb db = new CodeFirstDb();

        // GET: FoodTypes
        public ActionResult Index()
        {
            return View(db.foodTypes.ToList());
        }

        // GET: FoodTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodType foodType = db.foodTypes.Find(id);
            if (foodType == null)
            {
                return HttpNotFound();
            }
            return View(foodType);
        }

        // GET: FoodTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FoodTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Type,Name")] FoodType foodType)
        {
            if (ModelState.IsValid)
            {
                db.foodTypes.Add(foodType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(foodType);
        }

        // GET: FoodTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodType foodType = db.foodTypes.Find(id);
            if (foodType == null)
            {
                return HttpNotFound();
            }
            return View(foodType);
        }

        // POST: FoodTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Type,Name")] FoodType foodType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foodType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(foodType);
        }

        // GET: FoodTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodType foodType = db.foodTypes.Find(id);
            if (foodType == null)
            {
                return HttpNotFound();
            }
            return View(foodType);
        }

        // POST: FoodTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FoodType foodType = db.foodTypes.Find(id);
            db.foodTypes.Remove(foodType);
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
