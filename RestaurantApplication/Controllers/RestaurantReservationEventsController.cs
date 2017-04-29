using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RestaurantApplication.Models;

namespace RestaurantApplication.Controllers
{
    public class RestaurantReservationEventsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RestaurantReservationEvents
        public ActionResult Index()
        {
            return View(db.RestaurantReservationEvents.ToList());
        }

        // GET: RestaurantReservationEvents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantReservationEvent restaurantReservationEvent = db.RestaurantReservationEvents.Find(id);
            if (restaurantReservationEvent == null)
            {
                return HttpNotFound();
            }
            return View(restaurantReservationEvent);
        }

        // GET: RestaurantReservationEvents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RestaurantReservationEvents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RestaurantReservationEventID,BookersName,BookingDate,BookingStartTime,BookingEndTime,BookingDesc,BookingNumberOfPeople,BookingStatus,BookingEmailSent,RestaurantID")] RestaurantReservationEvent restaurantReservationEvent)
        {
            if (ModelState.IsValid)
            {
                db.RestaurantReservationEvents.Add(restaurantReservationEvent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restaurantReservationEvent);
        }

        // GET: RestaurantReservationEvents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantReservationEvent restaurantReservationEvent = db.RestaurantReservationEvents.Find(id);
            if (restaurantReservationEvent == null)
            {
                return HttpNotFound();
            }
            return View(restaurantReservationEvent);
        }

        // POST: RestaurantReservationEvents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RestaurantReservationEventID,BookersName,BookingDate,BookingStartTime,BookingEndTime,BookingDesc,BookingNumberOfPeople,BookingStatus,BookingEmailSent,RestaurantID")] RestaurantReservationEvent restaurantReservationEvent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurantReservationEvent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurantReservationEvent);
        }

        // GET: RestaurantReservationEvents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantReservationEvent restaurantReservationEvent = db.RestaurantReservationEvents.Find(id);
            if (restaurantReservationEvent == null)
            {
                return HttpNotFound();
            }
            return View(restaurantReservationEvent);
        }

        // POST: RestaurantReservationEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RestaurantReservationEvent restaurantReservationEvent = db.RestaurantReservationEvents.Find(id);
            db.RestaurantReservationEvents.Remove(restaurantReservationEvent);
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
