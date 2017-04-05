using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestaurantApplication.Models
{
    //public class RestaurantInit : DropCreateDatabaseAlways<ApplicationDbContext>
    //{
    //    // Called on database setup
    //    protected override void Seed(ApplicationDbContext context)
    //    {
    //        var initRestaurants = new List<Restaurant>
    //        {
    //            //SLIGO RESTAURANTS
    //            //Eala Bhan
    //            new Restaurant() { RestaurantName = "Eala Bhan" , RestaurantDescription = "Relaxed restaurant with white tablecloths specialising in locally caught seafood and prime steaks." , RestaurantAddress = "Rockwood Parade, Abbeyquarter North, Sligo", RestaurantPhoneNo="(071) 914 5823", OpeningTime = DateTime.Parse("12:00"), ClosingTime = DateTime.Parse("23:00")},
                
    //            //Bistro Bianconi
    //            new Restaurant() { RestaurantName = "Bistro Bianconi" , RestaurantDescription = "Italian Restaurant" , RestaurantAddress = "Tobergal Ln, Abbeyquarter North, Sligo", RestaurantPhoneNo="(071) 914 1744", OpeningTime = DateTime.Parse("12:00"), ClosingTime = DateTime.Parse("23:00") },

    //            //Knox
    //            new Restaurant() { RestaurantName = "Knox" , RestaurantDescription = "Restaurant" , RestaurantAddress = "32 O'Connell St, Abbeyquarter North, Sligo", RestaurantPhoneNo="(071) 914 1575", OpeningTime = DateTime.Parse("12:00"), ClosingTime = DateTime.Parse("23:00") },
                    
    //            //A Casa Mia
    //            new Restaurant() { RestaurantName = "A Casa Mia" , RestaurantDescription = "Restaurant" , RestaurantAddress = "Tobergal Ln, Abbeyquarter North, Sligo", RestaurantPhoneNo="(071) 914 1690", OpeningTime = DateTime.Parse("12:00"), ClosingTime = DateTime.Parse("23:00") },
                    
    //            //Paprika Tandoori Restaurant
    //            new Restaurant() { RestaurantName = "Paprika Tandoori Restaurant" , RestaurantDescription = "Restaurant" , RestaurantAddress = "Lower Pearse Road, Sligo", RestaurantPhoneNo="(071) 915 1948", OpeningTime = DateTime.Parse("12:00"), ClosingTime = DateTime.Parse("23:00")},
                    
    //            //Four Lanterns
    //            new Restaurant() { RestaurantName = "Four Lanterns" , RestaurantDescription = "Fast Food Restaurant" , RestaurantAddress = "3 John St, Abbeyquarter North, Sligo", RestaurantPhoneNo="(071) 914 3372", OpeningTime = DateTime.Parse("12:00"), ClosingTime = DateTime.Parse("23:00") },
                    
    //            //DUBLIN RESTAURANTS
    //            //Red Torch Ginger
    //            new Restaurant() { RestaurantName = "Red Torch Ginger" , RestaurantDescription = "Colourful, contemporary restaurant for Modern Thai cuisine and cocktails, plus early-bird deals." , RestaurantAddress = "15 St Andrew's St, Dublin 2", RestaurantPhoneNo="(01) 677 3363", OpeningTime = DateTime.Parse("12:00"), ClosingTime = DateTime.Parse("23:00")},
                    
    //            //Dax Restaurant
    //            new Restaurant() { RestaurantName = "Dax Restaurant" , RestaurantDescription = "French Restaurant. Georgian rooms with original features for crisp white tablecloths, gourmet dining and French wines." , RestaurantAddress = "23 Pembroke Street Upper, Dublin 2", RestaurantPhoneNo="(01) 676 1494", OpeningTime = DateTime.Parse("12:00"), ClosingTime = DateTime.Parse("23:00")},




    //        };

    //        initRestaurants.ForEach(r => context.Restaurants.Add(r));   // Add each restaurant to the dataabse

    //       // base.Seed(context);

    //        context.SaveChanges();  // save changes to the database
            
    //    }

    //}
}