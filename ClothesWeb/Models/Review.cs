using System;
using System.Collections.Generic;

#nullable disable

namespace ClothesWeb.Models
{
    public partial class Review
    {
        public int ReviewsId { get; set; }
        public int? ClothesId { get; set; }
        public string GuestName { get; set; }
        public string Email { get; set; }
        public string ReviewsContent { get; set; }

        public virtual Clothe Clothes { get; set; }
    }
}
