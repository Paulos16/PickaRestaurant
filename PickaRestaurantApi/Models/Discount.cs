using System;
using System.Collections.Generic;

namespace PickaRestaurantApi.Models
{
    public partial class Discount
    {
        public Discount()
        {
            Order = new HashSet<Order>();
        }

        public int IdDiscount { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
