using System;
using System.Collections.Generic;

namespace PickaRestaurantApi.Models
{
    public partial class Restaurant
    {
        public Restaurant()
        {
            Order = new HashSet<Order>();
        }

        public int IdRestaurant { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
