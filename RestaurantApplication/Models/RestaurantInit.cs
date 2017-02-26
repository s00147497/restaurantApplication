using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestaurantApplication.Models
{
    public class RestaurantInit : DropCreateDatabaseAlways<RestaurantDb>
    {
        // Called on database setup
        protected override void Seed(RestaurantDb context)
        {
            var initRestaurants = new List<Restaurant>
            {
                //SLIGO RESTAURANTS
                //Eala Bhan
                new Restaurant() { RestaurantName = "Eala Bhan" , RestaurantDescription = "Relaxed restaurant with white tablecloths specialising in locally caught seafood and prime steaks." , RestaurantAddress = "Rockwood Parade, Abbeyquarter North, Sligo", RestaurantPhoneNo="(071) 914 5823", RestaurantManagers = new List<RestaurantManager> {
                    new RestaurantManager { ManagerFName="John", ManagerLName="McDonnell", ManagerPhoneNo="087 1239148", ManagerEmail="johnmcdonnell@gmail.com", ManagerDescription="Manager at Eala Bhan" }
                },
                    RestaurantOwners = new List<RestaurantOwner> {
                    new RestaurantOwner { OwnerFName = "Gary", OwnerLName = "Hughes" , OwnerEmail = "garyhughes@yahoo.com" , OwnerPhoneNo="085 3216547", OwnerDescription = "Owner of Eala Bhan"},
                } },
                
                //Bistro Bianconi
                new Restaurant() { RestaurantName = "Bistro Bianconi" , RestaurantDescription = "Italian Restaurant" , RestaurantAddress = "Tobergal Ln, Abbeyquarter North, Sligo", RestaurantPhoneNo="(071) 914 1744", RestaurantManagers = new List<RestaurantManager> {
                    new RestaurantManager { ManagerFName="Shane", ManagerLName="Dowd", ManagerPhoneNo="087 8347568", ManagerEmail="shanedowd@gmail.com", ManagerDescription="Manager at Bistro Bianconi" }
                },
                    RestaurantOwners = new List<RestaurantOwner> {
                    new RestaurantOwner { OwnerFName = "Daniel", OwnerLName = "Brady" , OwnerEmail = "Danielbrady@yahoo.com" , OwnerPhoneNo="087 34543875", OwnerDescription = "Owner of Bistro Bianconi"},
                } },

                //Knox
                new Restaurant() { RestaurantName = "Knox" , RestaurantDescription = "Restaurant" , RestaurantAddress = "32 O'Connell St, Abbeyquarter North, Sligo", RestaurantPhoneNo="(071) 914 1575", RestaurantManagers = new List<RestaurantManager> {
                    new RestaurantManager { ManagerFName="Killian", ManagerLName="Regan", ManagerPhoneNo="087 8736465", ManagerEmail="kregan@gmail.com", ManagerDescription="Manager at Knox" }
                },
                    RestaurantOwners = new List<RestaurantOwner> {
                    new RestaurantOwner { OwnerFName = "Mick", OwnerLName = "Murphy" , OwnerEmail = "mickmurphy@yahoo.com" , OwnerPhoneNo="085 8774633", OwnerDescription = "Owner of Knox"},
                } },

                //A Casa Mia
                new Restaurant() { RestaurantName = "A Casa Mia" , RestaurantDescription = "Restaurant" , RestaurantAddress = "Tobergal Ln, Abbeyquarter North, Sligo", RestaurantPhoneNo="(071) 914 1690", RestaurantManagers = new List<RestaurantManager> {
                    new RestaurantManager { ManagerFName="Mary", ManagerLName="Murray", ManagerPhoneNo="087 47388746", ManagerEmail="maryMary@gmail.com", ManagerDescription="Manager at A Casa Mia" }
                },
                    RestaurantOwners = new List<RestaurantOwner> {
                    new RestaurantOwner { OwnerFName = "Conor", OwnerLName = "Watts" , OwnerEmail = "conorwatts@yahoo.com" , OwnerPhoneNo="085 4088430", OwnerDescription = "Owner of A Casa Mia"},
                } },

                //Paprika Tandoori Restaurant
                new Restaurant() { RestaurantName = "Paprika Tandoori Restaurant" , RestaurantDescription = "Restaurant" , RestaurantAddress = "Lower Pearse Road, Sligo", RestaurantPhoneNo="(071) 915 1948", RestaurantManagers = new List<RestaurantManager> {
                    new RestaurantManager { ManagerFName="Martin", ManagerLName="Downes", ManagerPhoneNo="087 27462534", ManagerEmail="martydownes@gmail.com", ManagerDescription="Manager at Paprika Tandoori Restaurant" }
                },
                    RestaurantOwners = new List<RestaurantOwner> {
                    new RestaurantOwner { OwnerFName = "Nathan", OwnerLName = "Cassidy" , OwnerEmail = "nathancassidy@yahoo.com" , OwnerPhoneNo="085 7346582", OwnerDescription = "Owner of Paprika Tandoori Restaurant"},
                } },

                //Four Lanterns
                new Restaurant() { RestaurantName = "Four Lanterns" , RestaurantDescription = "Fast Food Restaurant" , RestaurantAddress = "3 John St, Abbeyquarter North, Sligo", RestaurantPhoneNo="(071) 914 3372", RestaurantManagers = new List<RestaurantManager> {
                    new RestaurantManager { ManagerFName="Patrick", ManagerLName="OShea", ManagerPhoneNo="086 4181622", ManagerEmail="patricOshea@gmail.com", ManagerDescription="Manager at Four Lanterns" }
                },
                    RestaurantOwners = new List<RestaurantOwner> {
                    new RestaurantOwner { OwnerFName = "Nathan", OwnerLName = "Cassidy" , OwnerEmail = "nathancassidy@yahoo.com" , OwnerPhoneNo="085 3456364", OwnerDescription = "Owner of Four Lanterns"},
                } },

                //DUBLIN RESTAURANTS
                //Red Torch Ginger
                new Restaurant() { RestaurantName = "Red Torch Ginger" , RestaurantDescription = "Colourful, contemporary restaurant for Modern Thai cuisine and cocktails, plus early-bird deals." , RestaurantAddress = "15 St Andrew's St, Dublin 2", RestaurantPhoneNo="(01) 677 3363", RestaurantManagers = new List<RestaurantManager> {
                    new RestaurantManager { ManagerFName="Trevor", ManagerLName="Breslin", ManagerPhoneNo="086 56813218", ManagerEmail="trevorbreslin@gmail.com", ManagerDescription="Manager at Red Torch Ginger" }
                },
                    RestaurantOwners = new List<RestaurantOwner> {
                    new RestaurantOwner { OwnerFName = "James", OwnerLName = "Baxter" , OwnerEmail = "Jamesbax@yahoo.com" , OwnerPhoneNo="085 46677832", OwnerDescription = "Owner of Red Torch Ginger"},
                } },

                //Dax Restaurant
                new Restaurant() { RestaurantName = "Dax Restaurant" , RestaurantDescription = "French Restaurant. Georgian rooms with original features for crisp white tablecloths, gourmet dining and French wines." , RestaurantAddress = "23 Pembroke Street Upper, Dublin 2", RestaurantPhoneNo="(01) 676 1494", RestaurantManagers = new List<RestaurantManager> {
                    new RestaurantManager { ManagerFName="Sean", ManagerLName="Clarke", ManagerPhoneNo="086 4533123", ManagerEmail="sclarkey@gmail.com", ManagerDescription="Manager at Dax Restaurant" }
                },
                    RestaurantOwners = new List<RestaurantOwner> {
                    new RestaurantOwner { OwnerFName = "Fergal", OwnerLName = "Duke" , OwnerEmail = "fergalDuke@yahoo.com" , OwnerPhoneNo="085 87987763", OwnerDescription = "Owner of Dax Restaurant"},
                } },



            };

            initRestaurants.ForEach(r => context.Restaurants.Add(r));   // Add each restaurant to the dataabse

           // base.Seed(context);

            context.SaveChanges();  // save changes to the database
            
        }

    }
}