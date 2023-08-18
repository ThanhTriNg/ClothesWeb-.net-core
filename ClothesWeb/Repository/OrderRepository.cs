using ClothesWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ClothesWeb.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private ClothesWebContext _ctx;
        public OrderRepository(ClothesWebContext ctx)
        {
            _ctx = ctx;
        }

        public List<Order> GetAllOrder()
        {
            return _ctx.Orders.ToList();
        }

        public List<Order> GetSM()
        {
            return _ctx.Orders.Include(x => x.Sm).ToList();
        }

        public List<Order> GetUser()
        {
            return _ctx.Orders.Include(x => x.User).ToList();
        }
    }
}
