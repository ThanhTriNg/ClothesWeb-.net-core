using System;
using System.Collections.Generic;

#nullable disable

namespace ClothesWeb.Models
{
    public partial class ShippingMode
    {
        public ShippingMode()
        {
            Orders = new HashSet<Order>();
            ShippingRates = new HashSet<ShippingRate>();
        }

        public int Smid { get; set; }
        public string Smmode { get; set; }
        public int? SmmaxDelay { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ShippingRate> ShippingRates { get; set; }
    }
}
