using System;
using System.Collections.Generic;

#nullable disable

namespace ClothesWeb.Models
{
    public partial class Clothe
    {
        public Clothe()
        {
            OderDetails = new HashSet<OderDetail>();
            Reviews = new HashSet<Review>();
            ShoppingCarts = new HashSet<ShoppingCart>();
        }

        public int ClothesId { get; set; }
        public string ClothesName { get; set; }
        public string ClothesDescription { get; set; }
        public double? ClothesPrice { get; set; }
        public string ClothesImg { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<OderDetail> OderDetails { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
