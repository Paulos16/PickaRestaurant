using System;
using System.Collections.Generic;

namespace PickaRestaurantApi.Models
{
    public partial class Order
    {
        public Order()
        {
            PizzaOrder = new HashSet<PizzaOrder>();
        }

        public int IdOrder { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerContact { get; set; }
        public DateTime? AcceptedTime { get; set; }
        public DateTime? DeliveryTime { get; set; }
        public int RestaurantIdRestaurant { get; set; }
        public int DeliveryDriverIdDeliveryDriver { get; set; }
        public int AdministratorIdAdministrator { get; set; }
        public int DiscountIdDiscount { get; set; }

        public virtual Administrator AdministratorIdAdministratorNavigation { get; set; }
        public virtual DeliveryDriver DeliveryDriverIdDeliveryDriverNavigation { get; set; }
        public virtual Discount DiscountIdDiscountNavigation { get; set; }
        public virtual Restaurant RestaurantIdRestaurantNavigation { get; set; }
        public virtual ICollection<PizzaOrder> PizzaOrder { get; set; }
    }
}
