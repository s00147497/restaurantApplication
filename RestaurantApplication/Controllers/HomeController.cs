using Microsoft.AspNet.Identity;
using RestaurantApplication.Models;
using RestaurantApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using Geocoding;
using Geocoding.Google;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;

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
            var UserEmail = User.Identity.GetUserName();

            //if current user = null redirect to login page
            if (currentUserId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            //check the logged in users role. Are they customer or restaurant?
            bool userRoleR = User.IsInRole("Restaurant");
            if (userRoleR == true)
            {
                ViewBag.IsRestaurant = true;
                return View(restaurants.Where(x => x.RestaurantEmailAddress == UserEmail).ToList());
            }
            else
            {
                ViewBag.IsRestaurant = false;
            }

            bool userRoleC = User.IsInRole("Customer");
            if (userRoleC == true)
            {
                ViewBag.IsCustomer = true;
            }
            else
            {
                ViewBag.IsCustomer = false;
            }


            //CODE FOR SEARCH FUNCTIONALITY
            //    if (!String.IsNullOrEmpty(searchString))
            //{
            //    restaurants = restaurants.Where(s => s.RestaurantAddress.Contains(searchString));
            //}


            //var IsRestauarantOwner = from b in db.Restaurants
            //            where b.OwnerId == currentUserId
            //            select b;
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

        public ActionResult CreateRestaurant()
        {
            return View();
        }

        // POST: Restaurants1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRestaurant([Bind(Include = "RestaurantID,OwnerId,RestaurantName,RestaurantDescription,RestaurantPhoneNo,RestaurantAddress,RestaurantTown,County,OpeningTime,ClosingTime,RestaurantType,FurtherDetails")] Restaurant restaurant)
        {
            //setting the owner of the restaurant to be the current logged in users id
            string currentUserId = User.Identity.GetUserId();
            restaurant.OwnerId = currentUserId;

            //    //set the logged on users email to be the email address of the restaurant.
            var email = User.Identity.GetUserName();
            restaurant.RestaurantEmailAddress = email;
            //set rating to 0 as restaurant owner will not create 
            if (ModelState.IsValid)
            {
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




        /*CREATE RESERVATION*/
        // GET: RestaurantReservationEvents
        public ActionResult IndexReservation()
        {
            return View(db.RestaurantReservationEvents.ToList());
        }

        // GET: RestaurantReservationEvents/Details/5
        public ActionResult DetailsReservation(int? id)
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
        public ActionResult CreateReservation()
        {
            return View();
        }

        // POST: RestaurantReservationEvents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateReservation([Bind(Include = "RestaurantReservationEventID,BookersName,BookingDate,BookingStartTime,BookingEndTime,BookingDesc,BookingNumberOfPeople,BookingStatus,BookingEmailSent,RestaurantID")] RestaurantReservationEvent restaurantReservationEvent, int id)
        {
            if (ModelState.IsValid)
            {

                //Get seletcted Restaurants email;
                var selRestaurant = db.Restaurants.Find(id);
                var restaurantEmail = selRestaurant.RestaurantEmailAddress;

                //Set the logged on users email adress to the bookers email address
                var email = User.Identity.GetUserName();
                restaurantReservationEvent.BookingUsersEmail = email;

                //Set Booking Status to pending
                restaurantReservationEvent.BookingStatus = "Pending";

                //Set Email sent to no
                restaurantReservationEvent.BookingEmailSent = "No";

                restaurantReservationEvent.RestaurantID = id;

                //Send email to restaurant only if BookingEmailSent = "No"
                if (restaurantReservationEvent.BookingEmailSent == "No" || restaurantReservationEvent.BookingEmailSent == "NO")
                {

                    MailMessage EmailMsg = new MailMessage();

                    //Href link to event details for this event
                    string EmailLink = string.Format("<A HREF=\"http://localhost:59274/Account/Login\" > here</A>");

                    EmailMsg.From = new MailAddress("restaurantapplicationy4@gmail.com");
                    EmailMsg.To.Add(new MailAddress(restaurantEmail.ToString()));
                    EmailMsg.Subject = "You have a new Reservation from " + restaurantReservationEvent.BookersName;
                    EmailMsg.Body = String.Format("You have a new reservation from {0} for {1} people on the {2}. The reservation Starts at {3} and ends at {4}. Please login at {5} and let the booker know if you will be accepting or declining this reservation", restaurantReservationEvent.BookersName, restaurantReservationEvent.BookingNumberOfPeople, restaurantReservationEvent.BookingDate.ToShortDateString(), restaurantReservationEvent.BookingStartTime.TimeOfDay, restaurantReservationEvent.BookingEndTime.TimeOfDay, EmailLink);

                    EmailMsg.IsBodyHtml = true;

                    EmailMsg.Priority = MailPriority.Normal;
                    SmtpClient MailClient = new SmtpClient("smtp.gmail.com", 587);
                    MailClient.EnableSsl = true;
                    MailClient.Credentials = new System.Net.NetworkCredential("restaurantapplicationy4@gmail.com", "password201");
                    MailClient.Send(EmailMsg);

                    //set the email sent in the db to "Yes"
                    restaurantReservationEvent.BookingEmailSent = "Yes";
                }
                else
                {
                    //update the db
                    db.RestaurantReservationEvents.Add(restaurantReservationEvent);
                    db.SaveChanges();
                }

                //update the db
                db.RestaurantReservationEvents.Add(restaurantReservationEvent);
                db.SaveChanges();

                //Create new view here to say there reservation has been sent and they will get an email confirming the status
                return RedirectToAction("ReservationSent");
            }

            return View(restaurantReservationEvent);
        }

        //ReservationSent
        public ActionResult ReservationSent()
        {
            
            return View();
        }

        // GET: RestaurantReservationEvents/Edit/5
        public ActionResult EditReservation(int? id)
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
        public ActionResult DeleteReservation(int? id)
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
        public ActionResult DeleteConfirmedReservation(int id)
        {
            RestaurantReservationEvent restaurantReservationEvent = db.RestaurantReservationEvents.Find(id);
            db.RestaurantReservationEvents.Remove(restaurantReservationEvent);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //RestaurantReservation Partial View
        public ActionResult RestaurantReservationsPartialView(int id)
        {
            //Check to see if there is any reservations
            int numberOfReservations = db.RestaurantReservationEvents.Where(x => x.RestaurantID == id).ToList().Count();
            ViewBag.numReservations = numberOfReservations;

            //get the reservations for the current logged on restaurant
            //var reservations = db.RestaurantReservationEvents.Where(x => x.RestaurantID == id).ToList();

            //get only pending reservations
            var reservations = (from r in db.RestaurantReservationEvents
                              where r.BookingStatus == "Pending" && r.RestaurantID == id
                              select r).ToList();

            //ViewBag.ReservationStatus = pendingRes;

            return PartialView("_RestaurantReservations", reservations);
        }


        //GET DIRETIONS TO RESTAURANT 
        public ActionResult GetDirections(int? id)
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

            //PassRestaurantName to view
            var restaurantName = restaurant.RestaurantName.ToString();
            ViewBag.RestaurantName = restaurantName;

            //Getting the coordinates of the Restaurant
            IGeocoder geoCode;
            geoCode = new GoogleGeocoder();

            //Combine location into one string
            string address = string.Format("{0}, {1}, {2}, Ireland", restaurant.RestaurantAddress, restaurant.RestaurantTown, restaurant.County);

            var coordinates = geoCode.Geocode(address).ToList();

            //Check if coordinates are valid
            if (coordinates.Count > 0)
            {
                var longlat = coordinates.First();

                //Pass variables to View
                ViewBag.Address = address;
                ViewBag.Lat = Convert.ToDouble(longlat.Coordinates.Latitude);
                ViewBag.Long = Convert.ToDouble(longlat.Coordinates.Longitude);
                
                ViewBag.mapAvailable = true;
            }

            return View();
        }

        //Accept Reservation
        public ActionResult AcceptReservation(int id)
        {
            RestaurantReservationEvent restaurantReservationEvent = db.RestaurantReservationEvents.Find(id);

            //get the restaurants details
            Restaurant restaurant = db.Restaurants.Find(id);

            //var restaurantName = restaurant.RestaurantName;

            var selReservation = db.RestaurantReservationEvents.Find(id);


            var bookersEmail = selReservation.BookingUsersEmail.ToString();

            //Set The reservation Status To Pending
            selReservation.BookingStatus = "Accepted";

            if (selReservation.BookingStatus == "Accepted")
            {
                //send accepted email to booker
                MailMessage EmailMsg = new MailMessage();

                //Href link to event details for this event
                string EmailLink = string.Format("<A HREF=\"http://localhost:59274/Account/Login\" > here</A>");

                EmailMsg.From = new MailAddress("restaurantapplicationy4@gmail.com");
                EmailMsg.To.Add(new MailAddress(bookersEmail.ToString()));
                EmailMsg.Subject = "Your reservation has been accepted"; /*\\ + restaurant.RestaurantName;*/
                EmailMsg.Body = String.Format("Congradulations! Your reservation has been accepted for {0} people on the {1}. The reservation Starts at {2} and ends at {3}. We look forward to seeing you!",restaurantReservationEvent.BookingNumberOfPeople, restaurantReservationEvent.BookingDate.ToShortDateString(), restaurantReservationEvent.BookingStartTime.TimeOfDay, restaurantReservationEvent.BookingEndTime.TimeOfDay);

                EmailMsg.IsBodyHtml = true;

                EmailMsg.Priority = MailPriority.Normal;
                SmtpClient MailClient = new SmtpClient("smtp.gmail.com", 587);
                MailClient.EnableSsl = true;
                MailClient.Credentials = new System.Net.NetworkCredential("restaurantapplicationy4@gmail.com", "password201");
                MailClient.Send(EmailMsg);
            }

            //update the db
            //db.RestaurantReservationEvents.Add(restaurantReservationEvent);
            db.SaveChanges();

            return View();
        }

        //Accept Reservation
        public ActionResult DeclineReservation(int id)
        {
            RestaurantReservationEvent restaurantReservationEvent = db.RestaurantReservationEvents.Find(id);

            //get the restaurants details
            Restaurant restaurant = db.Restaurants.Find(id);

            //var restaurantName = restaurant.RestaurantName;

            var selReservation = db.RestaurantReservationEvents.Find(id);
            var bookersEmail = selReservation.BookingUsersEmail.ToString();

            //Set The reservation Status To Pending
            selReservation.BookingStatus = "Declined";

            if (selReservation.BookingStatus == "Declined")
            {
                //send accepted email to booker
                MailMessage EmailMsg = new MailMessage();

                //Href link to event details for this event
                string EmailLink = string.Format("<A HREF=\"http://localhost:59274/Account/Login\" > here</A>");

                EmailMsg.From = new MailAddress("restaurantapplicationy4@gmail.com");
                EmailMsg.To.Add(new MailAddress(bookersEmail.ToString()));
                EmailMsg.Subject = "Were Sorry your reservation has been declined"; /*\\ + restaurant.RestaurantName;*/
                EmailMsg.Body = String.Format("Were sorry but your reservation has been declined for {0} people on the {1}. Maybe try another time", restaurantReservationEvent.BookingNumberOfPeople, restaurantReservationEvent.BookingDate.ToShortDateString());

                EmailMsg.IsBodyHtml = true;

                EmailMsg.Priority = MailPriority.Normal;
                SmtpClient MailClient = new SmtpClient("smtp.gmail.com", 587);
                MailClient.EnableSsl = true;
                MailClient.Credentials = new System.Net.NetworkCredential("restaurantapplicationy4@gmail.com", "password201");
                MailClient.Send(EmailMsg);
            }

            //update the db
            //db.RestaurantReservationEvents.Add(restaurantReservationEvent);
            db.SaveChanges();

            return View();
        }

        //View all reservations
        public ActionResult ViewReservations (int id)
        {
            //Check to see if there is any reservations
            int numberOfReservations = db.RestaurantReservationEvents.Where(x => x.RestaurantID == id).ToList().Count();
            ViewBag.numReservations = numberOfReservations;

            //get reservations for logged in restaurant user
            var reservations = (from r in db.RestaurantReservationEvents
                                where r.RestaurantID == id
                                select r).ToList();

            return View("ViewReservations", reservations);
        }

        public ActionResult ViewReservationsToday (int id)
        {
            //Check to see if there is any reservations
            int numberOfReservations = db.RestaurantReservationEvents.Where(x => x.RestaurantID == id).ToList().Count();
            ViewBag.numReservations = numberOfReservations;

            //get reservations for logged in restaurant user
            var reservations = (from r in db.RestaurantReservationEvents
                                where r.RestaurantID == id && r.BookingDate == DateTime.Today
                                select r).ToList();

            return View("ViewReservationsToday", reservations);
        }

        //ABOUT
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        //Contact
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}