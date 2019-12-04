using System;
using System.Collections.Generic;

namespace PickaRestaurantApi.Models
{
    public partial class DeliveryDriver
    {
        public DeliveryDriver()
        {
            Order = new HashSet<Order>();
        }

        public int IdDeliveryDriver { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
