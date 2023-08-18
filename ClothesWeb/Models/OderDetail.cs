using System;
using System.Collections.Generic;

#nullable disable

namespace ClothesWeb.Models
{
    public partial class OderDetail
    {
        public int OrderId { get; set; }
        public int ClothesId { get; set; }
        public int? Scqty { get; set; }
        public double? Odcost { get; set; }

        public virtual Clothe Clothes { get; set; }
        public virtual Order Order { get; set; }
    }
}
