using System;
using System.Collections.Generic;

#nullable disable

namespace ClothesWeb.Models
{
    public partial class Order
    {
        public Order()
        {
            OderDetails = new HashSet<OderDetail>();
        }

        public int OrderId { get; set; }
        public int? UserId { get; set; }
        public int? Scid { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? Smid { get; set; }
        public double? Srfee { get; set; }
        public double? OrderTotal { get; set; }

        public virtual ShippingMode Sm { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<OderDetail> OderDetails { get; set; }
    }
}
