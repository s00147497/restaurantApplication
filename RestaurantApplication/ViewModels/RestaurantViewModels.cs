using RestaurantApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantApplication.ViewModels
{
    public class RestaurantViewModels
    {
        public int NumberofRestaurants { get; set; }
        public List<Restaurant> Restaurants { get; set; }
    }
}