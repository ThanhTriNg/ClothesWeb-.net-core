using ClothesWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ClothesWeb.Repository
{
    public class ClothesRepository : IClothesRepository
    {
        private ClothesWebContext _ctx;
        public ClothesRepository(ClothesWebContext ctx)
        {
            _ctx = ctx;
        }

        public void CreateClothes(Clothe clothe)
        {
            _ctx.Clothes.Add(clothe);
            _ctx.SaveChanges();
        }

        public List<Category> GetAllCategories()
        {
            return _ctx.Categories.ToList();
        }

        public List<Clothe> GetAllClothes()
        {
            return _ctx.Clothes.Include(x => x.Category).ToList();
        }

        public List<Clothe> GetTop5()
        {
            return _ctx.Clothes.OrderBy(x => x.ClothesPrice).Take(5).ToList();
        }
    }
}
