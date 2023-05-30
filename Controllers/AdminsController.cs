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
    public class AdminsController : Controller
    {
        private CodeFirstDb db = new CodeFirstDb();

        // GET: Admins
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult ManageAdmins()
        {
            return View(db.admins.ToList());
        }

        public ActionResult ManageFoods()
        {
            //return View(db.foods.ToList());
            IEnumerable<Food> foods = db.foods.ToList();
            IEnumerable<FoodType> foodTypes = db.foodTypes.ToList();

            ViewBag.FoodTypes = foodTypes;

            return View(foods);
        }

        public ActionResult ManageFoodTypes()
        {
            return View(db.foodTypes.ToList());
        }

        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            using (CodeFirstDb db = new CodeFirstDb())
            {
                var adm = db.admins.SingleOrDefault(u => u.UserName == admin.UserName && u.Password == admin.Password);
                if (adm != null)
                {
                    Session["UserID"] = adm.AdminID.ToString();
                    Session["UserName"] = adm.UserName.ToString();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password.");
                }
            }
            return View();
        }

        // GET: Admins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admins/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdminID,UserName,Password")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.admins.Add(admin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(admin);
        }

        // GET: Admins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //****************************EDIT-ADMIN****************************************88
        // GET: Admins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        // POST: Admins/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdminID, UserName, Password")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(admin);
        }

        // POST: Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Admin admin = db.admins.Find(id);
            db.admins.Remove(admin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Admins/ManageUsers
        public ActionResult ManageUsers()
        {
            return View(db.users.ToList());
        }

        // GET: Admins/AddUser
        public ActionResult AddUser()
        {
            return View();
        }

        // POST: Admins/AddUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUser(User user)
        {
            if (ModelState.IsValid)
            {
                db.users.Add(user);
                db.SaveChanges();
                return RedirectToAction("ManageUsers");
            }

            return View(user);
        }


        // GET: Admins/DeleteUser/5
        public ActionResult DeleteUser(int? id)
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

        // POST: Admins/DeleteUser/5
        [HttpPost, ActionName("DeleteUser")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteUserConfirmed(int id)
        {
            User user = db.users.Find(id);
            db.users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("ManageUsers");
        }

        //*****************************************************************************************


        // GET: Admins/AddFood
        public ActionResult CreateFoods()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateFoods(Food food)
        {
            if (ModelState.IsValid)
            {
                // Retrieve the selected food type from the database
                var foodType = db.foodTypes.FirstOrDefault(ft => ft.ID_Type == food.type);
                if (foodType != null)
                {
                    // Associate the food type with the food entity
                    food.type = foodType.ID_Type;

                    db.foods.Add(food);
                    db.SaveChanges();
                    return RedirectToAction("ManageFoods");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid food type.");
                }
            }

            // Retrieve the list of food types to display in the view
            ViewBag.FoodTypes = db.foodTypes.ToList();

            return View(food);
        }


        // GET: Admins/EditFood/5
        public ActionResult EditFoods(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food food = db.foods.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            return View(food);
        }

        // POST: Admins/EditFood/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditFoods(Food food)
        {
            if (ModelState.IsValid)
            {
                db.Entry(food).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ManageFoods");
            }
            return View(food);
        }

        // POST: Admins/DeleteFood/5
        [HttpPost, ActionName("DeleteFood")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFoodsConfirmed(int id)
        {
            Food food = db.foods.Find(id);
            db.foods.Remove(food);
            db.SaveChanges();
            return RedirectToAction("ManageFoods");
        }

        // GET: Admins/AddFoodType
        public ActionResult CreateFoodTypes()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateFoodTypes(FoodType foodType)
        {
            if (ModelState.IsValid)
            {
                db.foodTypes.Add(foodType);
                db.SaveChanges();
                return RedirectToAction("ManageFoodTypes");
            }

            return View(foodType);
        }


        // GET: Admins/EditFoodType/5
        public ActionResult EditFoodTypes(int? id)
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

        // POST: Admins/EditFoodType/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditFoodTypes(FoodType foodType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foodType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ManageFoodTypes");
            }
            return View(foodType);
        }

        // POST: Admins/DeleteFoodType/5
        [HttpPost, ActionName("DeleteFoodType")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFoodTypesConfirmed(int id)
        {
            FoodType foodType = db.foodTypes.Find(id);
            db.foodTypes.Remove(foodType);
            db.SaveChanges();
            return RedirectToAction("ManageFoodTypes");
        }

        // more actions * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *

        // GET: Admins/DeleteFood/5
        public ActionResult DeleteFoods(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food food = db.foods.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            return View(food);
        }

        // POST: Admins/DeleteFood/5
        [HttpPost, ActionName("DeleteFood")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFoodConfirmed(int id)
        {
            Food food = db.foods.Find(id);
            db.foods.Remove(food);
            db.SaveChanges();
            return RedirectToAction("ManageFoods");
        }

        // GET: Admins/DetailsFood/5
        public ActionResult DetailsFoods(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food food = db.foods.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            return View(food);
        }

        public ActionResult DetailsUser(int? id)
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




        // GET: Admins/DeleteFood/5
        public ActionResult DeleteFoodTypes(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodType ft = db.foodTypes.Find(id);
            if (ft == null)
            {
                return HttpNotFound();
            }
            return View(ft);
        }


        // GET: Admins/DetailsFood/5
        public ActionResult DetailsFoodTypes(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodType ft = db.foodTypes.Find(id);
            if (ft == null)
            {
                return HttpNotFound();
            }
            return View(ft);
        }

    }

}
