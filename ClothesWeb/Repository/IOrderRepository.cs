using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClothesWeb.Models;
namespace ClothesWeb.Repository
{
    public interface IOrderRepository
    {
        List<Order> GetAllOrder();
       
        List<Order> GetSM();
        List<Order> GetUser();
    }
}
