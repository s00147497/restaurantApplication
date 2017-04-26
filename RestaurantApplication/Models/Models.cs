using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestaurantApplication.Models
{
    //public class RestaurantDb : DbContext
    //{
    //    public RestaurantDb() : base("RestaurantDb")
    //    {
    //        //Database.SetInitializer(new RestaurantInit());
    //    }
    //    public DbSet<Restaurant> Restaurants { get; set; }
    //    public DbSet<RestaurantReservationEvent> RestaurantReservationEvents { get; set; }
    //}

    //Enums
    public enum RestaurantType {
        [Display(Name = "Fast Food")]
        FastFood,
        [Display(Name = "Fast Casual")]
        FastCasual,
        [Display(Name = "Casual Dining")]
        CasualDining,
        [Display(Name = "Fine Dining")]
        FineDining,
        [Display(Name = "Barbecue")]
        Barbecue,
        [Display(Name = "Brasserie and Bistro")]
        BrasserieAndBistro,
        [Display(Name = "Café")]
        Café,
        [Display(Name = "Cafeteria")]
        Cafeteria,
        [Display(Name = "Pub")]
        Pub,
    }

    public class Restaurant
    {
        // Class to manage a single Restaurant
        [Key]
        public int RestaurantID { get; set; }

        //To Test whos on the site
        public string OwnerId { get; set; }

        //Name
        [Required(ErrorMessage = "You must enter a Restaurant Name")]
        [DataType(DataType.Text)]
        [StringLength(150, ErrorMessage = "Restaurant Name cannot be longer than 150 characters")]
        [Display(Name = "Restaurant Name")]
        public string RestaurantName { get; set; }


        //Discription
        [Display(Name = "Description")]
        [StringLength(200, ErrorMessage = "Discription is too long")] //character remaining count
        public string RestaurantDescription { get; set; }

        //Phone Number
        [Required(ErrorMessage = "You must enter a Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string RestaurantPhoneNo { get; set; }

        //Email
        //[Required(ErrorMessage = "You must enter a valid Email Address")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string RestaurantEmailAddress { get; set; }

        //Address
        [Display(Name = "Address")]
        [StringLength(200, ErrorMessage = "Address is too long")] //character remaining count
        public string RestaurantAddress { get; set; }

        //County
        [Display(Name = "County")]
        [StringLength(200, ErrorMessage = "Please Select County")]
        public string County { get; set; }

        //Latidude
        [Display(Name = "Latitude Co-Ordinates")]
        //[StringLength(200, ErrorMessage = "Please enter Latidute Co-Ordinates")]
        public double Lat { get; set; }

        //Longitude
        [Display(Name = "Longitude Co-Ordinates")]
        //[StringLength(200, ErrorMessage = "Please enter Longitude Co-Ordinates")]      ADD BUTTON TO GET COORDS
        public double Long { get; set; }

        //Opening Time
        [Required(ErrorMessage = "Please enter the restaurants opening time")]
        [Display(Name = "Opening Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime OpeningTime { get; set; }

        //Closing Time
        [Required(ErrorMessage = "Please enter the restaurants closing time")]
        [Display(Name = "Closing Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime ClosingTime { get; set; }

        //Rating
        [Display(Name = "Rating")]
        public double Rating { get; set; }

        //Type
        [Required(ErrorMessage = "Please select Restaurant Type")]
        [Display(Name = "Restaurant Type")]
        [DataType(DataType.Text)]
        public RestaurantType RestaurantType { get; set; }

        ////Amount of notice Required
        //[Display(Name = "Amount of Notice Required")]
        //[DataType(DataType.Text)]
        //public string NoticeRequired { get; set; }

        //Further Details        
        [Required(ErrorMessage = "Please enter any further details about your restaurant")]
        [Display(Name = "FurtherDetails")]
        [DataType(DataType.Text)]
        public string FurtherDetails { get; set; }

        //List of reservations for this restaurant 
        public virtual List<RestaurantReservationEvent> RestaurantBooking { get; set; }
    }//end Restaurant

    public class RestaurantReservationEvent
    {
        [Key]
        public int RestaurantReservationEventID { get; set; }

        //Bookers Name
        [Required(ErrorMessage = "You must enter the Name of who's booking the table")]
        [Display(Name = "Name")]
        public string BookersName { get; set; }

        //Date
        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "You must enter a date for this booking")]
        public DateTime BookingDate { get; set; }

        //Start Time
        [Required(ErrorMessage = "You must give this booking a start time")]
        [Display(Name = "Start Time")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime BookingStartTime { get; set; }

        //End Time
        [Required(ErrorMessage = "You must give this booking an end time")]
        [Display(Name = "End Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime BookingEndTime { get; set; }

        //Booking Description
        [Display(Name = "Description")]
        [DataType(DataType.Text)]
        public string BookingDesc { get; set; }

        //Number of People
        [Display(Name = "Number of People")]
        [DataType(DataType.Text)]
        public int BookingNumberOfPeople { get; set; }

        //Booking Status? Accepted - Pending - Declined
        [Display(Name = "Booking Status")]
        [DataType(DataType.Text)]
        public string BookingStatus { get; set; }

        //Booking Email Sent
        [Display(Name = "Email Sent")]
        [DataType(DataType.Text)]
        public string BookingEmailSent { get; set; }

        //Foreign Key for Restaurant
        public int RestaurantID { get; set; }

    }//end reservation class



}