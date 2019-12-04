using System;
using System.Collections.Generic;

namespace PickaRestaurantApi.Models
{
    public partial class Pizza
    {
        public Pizza()
        {
            PizzaOrder = new HashSet<PizzaOrder>();
            PizzaTopping = new HashSet<PizzaTopping>();
        }

        public int IdPizza { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public int IsStandard { get; set; }
        public string TypeOfBreadName { get; set; }

        public virtual TypeOfBread TypeOfBreadNameNavigation { get; set; }
        public virtual ICollection<PizzaOrder> PizzaOrder { get; set; }
        public virtual ICollection<PizzaTopping> PizzaTopping { get; set; }
    }
}
