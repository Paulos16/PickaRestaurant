using System;
using System.Collections.Generic;

namespace PickaRestaurantApi.Models
{
    public partial class PizzaTopping
    {
        public int PizzaIdPizza { get; set; }
        public int ToppingIdTopping { get; set; }

        public virtual Pizza PizzaIdPizzaNavigation { get; set; }
        public virtual Topping ToppingIdToppingNavigation { get; set; }
    }
}
