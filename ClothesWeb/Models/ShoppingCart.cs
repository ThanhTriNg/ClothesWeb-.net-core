using System;
using System.Collections.Generic;

#nullable disable

namespace ClothesWeb.Models
{
    public partial class ShoppingCart
    {
        public int Scid { get; set; }
        public int ClothesId { get; set; }
        public int? Scqty { get; set; }

        public virtual Clothe Clothes { get; set; }
    }
}
