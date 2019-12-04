using System;
using System.Collections.Generic;

namespace PickaRestaurantApi.Models
{
    public partial class Topping
    {
        public Topping()
        {
            PizzaTopping = new HashSet<PizzaTopping>();
        }

        public int IdTopping { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }

        public virtual ICollection<PizzaTopping> PizzaTopping { get; set; }
    }
}
