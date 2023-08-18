using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesWeb.Models
{
    public class Cart
    {
        public List<ItemCart> carts = new List<ItemCart>();
        public void addItem(ItemCart item)
        {
            carts.Add(item);
        }

        public List<ItemCart> GetAllItem()
        {
            return carts;
        }

        public decimal getTotal()
        {
            decimal total = 0;
            foreach (ItemCart item in carts)
            {
                total += item.Price * item.Quantity;
            }
            return total;
        }
    }
}
