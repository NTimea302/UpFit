using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using UpFit__main.Models;

namespace UpFit__main.Controllers
{
    public class MealsController : Controller
    {
        private CodeFirstDb db = new CodeFirstDb();

        // GET: Meals
        public ActionResult Index()
        {
            return View(db.meals.ToList());
        }

        // GET: Meals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meal meal = db.meals.Find(id);
            if (meal == null)
            {
                return HttpNotFound();
            }
            return View(meal);
        }


        // GET: Meals/Create
        public ActionResult Create()
        {
           ViewBag.FoodFK = new SelectList(db.foods, "foodID", "name");
            return View();
        }

        // POST: Meals/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "mealID,mealTypeFK,userFK,foodFK,quantity,date")] Meal meal)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        meal.date = DateTime.Today; // Set today's date
        //        db.meals.Add(meal);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
            
        //    ViewBag.MealTypeFK = new SelectList(db.foodTypes, "ID_Type", "Name", meal.mealTypeFK);
        //    ViewBag.FoodFK = new SelectList(db.foods, "foodID", "name", meal.foodFK);
        //    return View(meal);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "mealID,mealTypeFK,userFK,foodFK,quantity,date")] Meal meal)
        {
            if (ModelState.IsValid)
            {
                meal.date = DateTime.Today; // Set today's date
                db.meals.Add(meal);
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            ViewBag.FoodFK = new SelectList(db.foods, "foodID", "name",meal.foodFK);

            return View(meal);
        }
        // GET: Meals/Edit/5
        public ActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Meal meal = db.meals.Find(id);
                if (meal == null)
                {
                    return HttpNotFound();
                }
                return View(meal);
            }

            // POST: Meals/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit([Bind(Include = "mealID,mealTypeFK,userFK,foodFK,quantity")] Meal meal)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(meal).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(meal);
            }

            // GET: Meals/Delete/5
            public ActionResult Delete(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Meal meal = db.meals.Find(id);
                if (meal == null)
                {
                    return HttpNotFound();
                }
                return View(meal);
            }

            // POST: Meals/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public ActionResult DeleteConfirmed(int id)
            {
                Meal meal = db.meals.Find(id);
                db.meals.Remove(meal);
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
