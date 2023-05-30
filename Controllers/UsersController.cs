using Newtonsoft.Json.Linq;
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
    public class UsersController : Controller
    {
        private CodeFirstDb db = new CodeFirstDb();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.users.ToList());
        }


        public ActionResult AddDetails()
        {
            return View();
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            using (CodeFirstDb db = new CodeFirstDb())
            {
                var usr = db.users.SingleOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);
                if (usr != null)
                {
                    Session["UserID"] = usr.UserID.ToString();
                    Session["UserName"] = usr.UserName.ToString();
                    Session["SubscriptionType"] = usr.SubscriptionTypeFK.ToString();
                    Session["KcalDaily"] = usr.KcalDaily;
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password.");
                }
            }
            return View();
        }

        public ActionResult LoggedIn()
        {
            if (Session["UserID"] != null)
            {
                int userId = Convert.ToInt32(Session["UserID"]);
                MacroCalculations(userId);
                // Retrieve the user from the database based on the UserID
                User user = db.users.Find(userId);
         
                if (user != null)
                {
                    return View(user);
                }
            }

            // If the user is not logged in or not found in the database, redirect to the login page
            return RedirectToAction("Login");
        }

        // LoginRegistration
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        // UpFit!-main

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Register
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult ViewAccounts()
        {
            return View();
        }

        // POST: Users/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "UserID,SubscriptionTypeFK,UserName,Password,FirstName,LastName,Gender,Age,Height,Weight,KcalDaily,Lifestyle")] User user)
        {
            if (user.Gender == "M")
            {
                user.KcalDaily = (int)Math.Round(user.Lifestyle * (66 + (13.7 * user.Weight) + (5 * user.Height) - (6.8 * user.Age)));
            }
            else
            {
                user.KcalDaily = (int)Math.Round(user.Lifestyle * (65 + (9.5 * user.Weight) + (1.8 * user.Height) - (4.7 * user.Age)));
            }
            if (ModelState.IsValid)
            {
                db.users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,SubscriptionTypeFK,UserName,Password,FirstName,LastName,Gender,Age,Height,Weight,KcalDaily")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.users.Find(id);
            db.users.Remove(user);
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

        [HttpGet]
        public ActionResult VideoList()
        {
            using (CodeFirstDb db = new CodeFirstDb())
            {
                List<Video> Videolist = new List<Video>();
                foreach (Video video in db.videos)
                {
                    Video dbVideo = new Video();
                    {
                        dbVideo.Vname = video.Vname;
                        dbVideo.Vpath = video.Vpath.ToString();
                    };
                    Videolist.Add(dbVideo);
                }
                return View(Videolist);
            }
        }

        [HttpGet]
        public List<double> MacroCalculations(int userID)
        {
            DateTime day = DateTime.Today;
            double calories = 0;
            double carbo = 0.00, proteins = 0.00, fats = 0.00, fibers = 0.00, vitamin_A = 0.00, vitamin_B = 0.00, vitamin_C = 0, vitamin_D = 0, vitamin_E = 0;
            List<double> totalmacro = new List<double>();
            using (CodeFirstDb db = new CodeFirstDb())
            {
                foreach (Meal meal in db.meals)
                {
                    if (meal.userFK == userID)
                    {
                        if(meal.date == day)
                        {
                            Food aliment = db.foods.SingleOrDefault(x => x.foodID == meal.foodFK);
                            calories = calories + (aliment.calories)*meal.quantity/100;
                            carbo = carbo + (double)aliment.carbs*meal.quantity/100;
                            proteins = proteins + (double)aliment.proteins* meal.quantity/100;
                            fats=fats+ (double)aliment.fats * meal.quantity / 100;
                            fibers=fibers +(double)aliment.fibers * meal.quantity / 100;
                            vitamin_A = vitamin_A + (double)aliment.vitamin_A * meal.quantity / 100;
                            vitamin_B = vitamin_B + (double)aliment.vitamin_B * meal.quantity / 100;
                            vitamin_C = vitamin_C + (double)aliment.vitamin_C * meal.quantity / 100;
                            vitamin_D = vitamin_D + (double)aliment.vitamin_D * meal.quantity / 100;
                            vitamin_E = vitamin_E + (double)aliment.vitamin_E * meal.quantity / 100; 
                        }
                    }
                }
                totalmacro.AddRange(new double[] { calories, carbo, proteins, fats, fibers, vitamin_A, vitamin_B, vitamin_C, vitamin_D, vitamin_E });
                ViewBag.MacroDaily = totalmacro;
            }
            return totalmacro;
        }
    }
}
