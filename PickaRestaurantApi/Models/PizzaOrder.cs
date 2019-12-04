using System;
using System.Collections.Generic;

namespace PickaRestaurantApi.Models
{
    public partial class PizzaOrder
    {
        public int PizzaIdPizza { get; set; }
        public int OrderIdOrder { get; set; }

        public virtual Order OrderIdOrderNavigation { get; set; }
        public virtual Pizza PizzaIdPizzaNavigation { get; set; }
    }
}
