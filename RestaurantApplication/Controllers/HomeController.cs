using Microsoft.AspNet.Identity;
using RestaurantApplication.Models;
using RestaurantApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RestaurantApplication.Controllers
{
    public class HomeController : Controller
    {
        //Database
        //public RestaurantDb db = new RestaurantDb();
        public ApplicationDbContext db = new ApplicationDbContext();

        //View Models
        RestaurantViewModels rvm = new RestaurantViewModels();

        public ActionResult Index(string searchString)
        {
            IQueryable<Restaurant> restaurants = db.Restaurants;
            //Get the currentely logged in user
            string currentUserId = User.Identity.GetUserId();

            //if current user = null redirect to login page
            if (currentUserId == null)
            {
              return RedirectToAction("Login", "Account");
            }
            //CODE FOR SEARCH FUNCTIONALITY

            if (!String.IsNullOrEmpty(searchString))
            {
                restaurants = restaurants.Where(s => s.RestaurantAddress.Contains(searchString));
            }

            //rvm.Restaurants = db.Restaurants.ToList();

            var restaurant = from r in db.Restaurants
                        where r.OwnerId == currentUserId
                              select r;

            if (restaurant.Count() > 0)
            {
                ViewBag.ownsRestaurant = true;
            }
            else
            {
                ViewBag.ownsRestaurant = false;
            }
            //return View(rvm.Restaurants);
            return View(restaurants.ToList());
        }

        // GET: Restaurants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // GET: Restaurants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RestaurantID,RestaurantName,RestaurantDescription,RestaurantPhoneNo,RestaurantAddress, OpeningTime,ClosingTime")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                string currentUserId = User.Identity.GetUserId();
                restaurant.OwnerId = currentUserId;
                db.Restaurants.Add(restaurant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restaurant);
        }

        // GET: Restaurants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RestaurantID,RestaurantName,RestaurantDescription,RestaurantPhoneNo,RestaurantAddress")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurant);
        }

        // GET: Restaurants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Restaurant restaurant = db.Restaurants.Find(id);
            db.Restaurants.Remove(restaurant);
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

        //public ActionResult CreateReservation()
        //{
        //    return View();
        //}

        //// POST: RestaurantReservationEvents/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "RestaurantReservationEventID,BookersName,BookingDate,BookingStartTime,BookingEndTime,BookingDesc,RestaurantID")] RestaurantReservationEvent restaurantReservationEvent)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.RestaurantReservationEvents.Add(restaurantReservationEvent);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(restaurantReservationEvent);
        //}

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}