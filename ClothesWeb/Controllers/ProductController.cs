using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClothesWeb.Repository;
using ClothesWeb.Models;

namespace ClothesWeb.Controllers
{
    public class ProductController : Controller
    {
        private IClothesRepository _clothes;
        public ProductController(IClothesRepository clothes)
        {
            _clothes = clothes;
        }
        public IActionResult Index()
        {
            //danh sach clothes
            List<Clothe> items = _clothes.GetAllClothes();
            ViewBag.items = items;
            return View();
        }

        [HttpGet]
        public IActionResult ThemClothes()
        {
            Clothe clothe = new Clothe();
            ViewBag.cate = _clothes.GetAllCategories();
            return View(clothe);
        }

        [HttpPost]
        public IActionResult SaveClothes(Clothe clothe)
        {
            _clothes.CreateClothes(clothe);
            return RedirectToAction("Index");
        }
    }
}
