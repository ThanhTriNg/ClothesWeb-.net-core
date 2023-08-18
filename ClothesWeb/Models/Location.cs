using System;
using System.Collections.Generic;

#nullable disable

namespace ClothesWeb.Models
{
    public partial class Location
    {
        public Location()
        {
            ShippingRates = new HashSet<ShippingRate>();
        }

        public int LocationId { get; set; }
        public string LocationName { get; set; }

        public virtual ICollection<ShippingRate> ShippingRates { get; set; }
    }
}
