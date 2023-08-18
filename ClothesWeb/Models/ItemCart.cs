using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesWeb.Models
{
    public class ItemCart
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public String Name { get; set; }
        public String img { get; set; }
        public decimal Price { get; set; }
    }
}
