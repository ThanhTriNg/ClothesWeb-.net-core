using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClothesWeb.Models;
namespace ClothesWeb.Repository
{
    public interface IClothesRepository
    {
        List<Clothe> GetAllClothes();
        void CreateClothes(Clothe clothe);
        List<Category> GetAllCategories();
        List<Clothe> GetTop5();
    }
}

