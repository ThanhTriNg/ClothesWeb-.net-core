using System;
using System.Collections.Generic;

#nullable disable

namespace ClothesWeb.Models
{
    public partial class ShippingRate
    {
        public int LocationId { get; set; }
        public int Smid { get; set; }
        public double? Srfee { get; set; }

        public virtual Location Location { get; set; }
        public virtual ShippingMode Sm { get; set; }
    }
}
