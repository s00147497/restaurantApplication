using RestaurantApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantApplication.ViewModels
{
    public class IndexViewModel
    {
        //reference models in the Index View
        public Restaurant RestaurantViewModel { get; set; }
    }
}