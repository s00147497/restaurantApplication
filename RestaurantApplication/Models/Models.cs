using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestaurantApplication.Models
{
    public class RestaurantDb : DbContext
    {
        public RestaurantDb() : base("RestaurantDb")
        {
            //Database.SetInitializer(new RestaurantInit());
        }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantReservationEvent> RestaurantReservationEvents { get; set; }
    }

    //Enums
    public enum RestaurantType { Ethnic, FastFood, FastCasual, CasualDining, FineDining, Barbecue, BrasserieAndBistro }

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

        ////Email
        //[Required(ErrorMessage = "You must enter a valid Email Address")]
        //[DataType(DataType.EmailAddress)]
        //[Display(Name = "Phone Number")]
        //public string RestaurantEmailAddress { get; set; }

        //Address
        [Display(Name = "Address")]
        [StringLength(200, ErrorMessage = "Address is too long")] //character remaining count
        public string RestaurantAddress { get; set; }

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

        //List of reservations for this restaurant 
        public virtual List<RestaurantReservationEvent> RestaurantBookings { get; set; }



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
        public string BookingDate { get; set; }

        //Start Time
        [Required(ErrorMessage = "You must give this booking a start time")]
        [Display(Name = "Start Time")]
        [DataType(DataType.Time)]
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

        //Foreign Key for Restaurant
        public int RestaurantID { get; set; }

    }//end reservation class



}