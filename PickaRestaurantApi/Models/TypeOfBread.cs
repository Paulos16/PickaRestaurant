using System;
using System.Collections.Generic;

namespace PickaRestaurantApi.Models
{
    public partial class TypeOfBread
    {
        public TypeOfBread()
        {
            Pizza = new HashSet<Pizza>();
        }

        public string Name { get; set; }

        public virtual ICollection<Pizza> Pizza { get; set; }
    }
}
