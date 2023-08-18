using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClothesWeb.Models;
using ClothesWeb.Repository;
namespace ClothesWeb.Controllers
{
    public class AdminController : Controller
    {
        private IClothesRepository _clothes;
        private IOrderRepository _order;
        public AdminController(IClothesRepository clothes, IOrderRepository orders)
        {
            _clothes = clothes;
            _order = orders;
        }

        ClothesWebContext ctx = new ClothesWebContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllCategories()
        {
            List<Category> categories = ctx.Categories.ToList();
            return View(categories);
        }

        public IActionResult GetAllClothes()
        {
            List<Clothe> clothes = _clothes.GetAllClothes();
            ViewBag.GetAllClothes = clothes;
            return View();
        }

        public IActionResult GetAllLocation()
        {
            List<Location> location = ctx.Locations.ToList();
            return View(location);
        }
        public IActionResult GetAllOrder()
        {
            List<Order> orders = _order.GetAllOrder();
            List<Order> sm = _order.GetSM();
            List<Order> users = _order.GetUser();
            ViewBag.GetAllOrder = orders;
            return View();
        }
        public IActionResult GetAllOrderDetail()
        {
            List<OderDetail> orderdetail = ctx.OderDetails.ToList();
            return View(orderdetail);
        }
        public IActionResult GetAllSM()
        {
            List<ShippingMode> sp = ctx.ShippingModes.ToList();
            return View(sp);
        }
        public IActionResult GetAllSR()
        {
            List<ShippingRate> sr = ctx.ShippingRates.ToList();
            return View(sr);
        }
        public IActionResult GetAllSC()
        {
            List<ShoppingCart> sc = ctx.ShoppingCarts.ToList();
            return View(sc);
        }
        public IActionResult GetAllUser()
        {
            List<User> user = ctx.Users.ToList();
            return View(user);
        }

        public IActionResult AddCategory()
        {

            return View();
        }
        public IActionResult AddClothes()
        {
            Clothe clothes = new Clothe();
            ViewBag.cate = ctx.Categories.ToList();
            return View(clothes);
        }
        public IActionResult AddLocation()
        {

            return View();
        }

        public IActionResult AddSM()
        {

            return View();
        }

        public IActionResult AddSC()
        {

            return View();
        }

        [HttpPost]
        public IActionResult SaveCategory(Category cate)
        {
            //insert db
           
                ctx.Categories.Add(cate);
                ctx.SaveChanges();
                return RedirectToAction("GetAllCategories");
        }
        public IActionResult DeleteCategory(int id)
        {
            //tim doi tuong co id
            //select * from categories where CCategoryId = id 
            Category c = ctx.Categories.Where(x => x.CategoryId == id).SingleOrDefault();
            //xoa du lieu
            ctx.Categories.Remove(c);
            ctx.SaveChanges();
            return RedirectToAction("GetAllCategories");
        }

        public IActionResult EditCategory(int id)
        {
            //tim doi tuong co id
            //select * from categories where CCategoryId = id 
            Category c = ctx.Categories.Where(x => x.CategoryId == id).SingleOrDefault();
            return View(c);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category cate)
        {
            //tim doi tuong co trong db tuong ung ma CategoryId
            Category c_indb = ctx.Categories.Where(x => x.CategoryId == cate.CategoryId).SingleOrDefault();
            if (c_indb != null)
            {
                c_indb.CategoryName = cate.CategoryName;
                c_indb.CategoryDetails = cate.CategoryDetails;
            }
            //cap nhat thong tin
            ctx.SaveChanges();
            return RedirectToAction("GetAllCategories");
        }

        [HttpPost]
        public IActionResult SaveClothes(Clothe clothe)
        {

                _clothes.CreateClothes(clothe);

            return RedirectToAction("GetAllClothes");
        }
        public IActionResult DeleteClothes(int id)
        {
            //tim doi tuong co id
            //select * from categories where CCategoryId = id 
            Clothe c = ctx.Clothes.Where(x => x.ClothesId == id).SingleOrDefault();
            //xoa du lieu
            ctx.Clothes.Remove(c);
            ctx.SaveChanges();
            return RedirectToAction("GetAllClothes");
        }

        public IActionResult EditClothes(int id)
        {
            //tim doi tuong co id
            //select * from categories where CCategoryId = id 
            Clothe c = ctx.Clothes.Where(x => x.ClothesId == id).SingleOrDefault();
            return View(c);
        }

        [HttpPost]
        public IActionResult UpdateClothes(Clothe clothes)
        {
            //tim doi tuong co trong db tuong ung ma CategoryId
            Clothe c_indb = ctx.Clothes.Where(x => x.ClothesId == clothes.CategoryId).SingleOrDefault();
            if (c_indb != null)
            {
                c_indb.ClothesName = clothes.ClothesName;
                c_indb.ClothesDescription = clothes.ClothesDescription;
                c_indb.ClothesPrice = clothes.ClothesPrice;
                c_indb.ClothesImg = clothes.ClothesImg;
                c_indb.CategoryId = clothes.CategoryId;
            }
            //cap nhat thong tin
            ctx.SaveChanges();
            return RedirectToAction("GetAllClothes");
        }

        [HttpPost]
        public IActionResult SaveLocation(Location location)
        {
            //insert db
            ctx.Locations.Add(location);
            ctx.SaveChanges();
            return RedirectToAction("GetAllLocation");
        }
        public IActionResult DeleteLocation(int id)
        {
            //tim doi tuong co id
            //select * from categories where CCategoryId = id 
            Location c = ctx.Locations.Where(x => x.LocationId == id).SingleOrDefault();
            //xoa du lieu
            ctx.Locations.Remove(c);
            ctx.SaveChanges();
            return RedirectToAction("GetAllLocation");
        }

        public IActionResult EditLocation(int id)
        {
            //tim doi tuong co id
            //select * from categories where CCategoryId = id 
            Location c = ctx.Locations.Where(x => x.LocationId == id).SingleOrDefault();
            return View(c);
        }

        [HttpPost]
        public IActionResult UpdateLocation(Location location)
        {
            //tim doi tuong co trong db tuong ung ma CategoryId
            Location c_indb = ctx.Locations.Where(x => x.LocationId == location.LocationId).SingleOrDefault();
            if (c_indb != null)
            {
                c_indb.LocationId = location.LocationId;
                c_indb.LocationName = location.LocationName;
            }
            //cap nhat thong tin
            ctx.SaveChanges();
            return RedirectToAction("GetAllLocation");
        }

        [HttpPost]
        public IActionResult SaveSM(ShippingMode sm)
        {
            //insert db
            ctx.ShippingModes.Add(sm);
            ctx.SaveChanges();
            return RedirectToAction("GetAllSM");
        }
        public IActionResult DeleteSM(int id)
        {
            //tim doi tuong co id
            //select * from categories where CCategoryId = id 
            ShippingMode c = ctx.ShippingModes.Where(x => x.Smid == id).SingleOrDefault();
            //xoa du lieu
            ctx.ShippingModes.Remove(c);
            ctx.SaveChanges();
            return RedirectToAction("GetAllSM");
        }

        public IActionResult EditSM(int id)
        {
            //tim doi tuong co id
            //select * from categories where CCategoryId = id 
            ShippingMode c = ctx.ShippingModes.Where(x => x.Smid == id).SingleOrDefault();
            return View(c);
        }

        [HttpPost]
        public IActionResult UpdateSM(ShippingMode sm)
        {
            //tim doi tuong co trong db tuong ung ma CategoryId
            ShippingMode c_indb = ctx.ShippingModes.Where(x => x.Smid == sm.Smid).SingleOrDefault();
            if (c_indb != null)
            {
                c_indb.Smid = sm.Smid;
                c_indb.Smmode = sm.Smmode;
                c_indb.SmmaxDelay = sm.SmmaxDelay;
            }
            //cap nhat thong tin
            ctx.SaveChanges();
            return RedirectToAction("GetAllSM");
        }


        [HttpPost]
        public IActionResult SaveSC(ShoppingCart sc)
        {
            //insert db
            ctx.ShoppingCarts.Add(sc);
            ctx.SaveChanges();
            return RedirectToAction("GetAllSM");
        }
        public IActionResult DeleteSC(int id)
        {
            //tim doi tuong co id
            //select * from categories where CCategoryId = id 
            ShoppingCart c = ctx.ShoppingCarts.Where(x => x.Scid == id).SingleOrDefault();
            //xoa du lieu
            ctx.ShoppingCarts.Remove(c);
            ctx.SaveChanges();
            return RedirectToAction("GetAllSC");
        }

        public IActionResult EditSC(int id)
        {
            //tim doi tuong co id
            //select * from categories where CCategoryId = id 
            ShoppingCart c = ctx.ShoppingCarts.Where(x => x.Scid == id).SingleOrDefault();
            return View(c);
        }

        [HttpPost]
        public IActionResult UpdateSC(ShoppingCart sm)
        {
            //tim doi tuong co trong db tuong ung ma CategoryId
            ShoppingCart c_indb = ctx.ShoppingCarts.Where(x => x.Scid == sm.Scid).SingleOrDefault();
            if (c_indb != null)
            {
                c_indb.Scid = sm.Scid;
                c_indb.ClothesId = sm.ClothesId;
                c_indb.Scqty = sm.Scqty;
            }
            //cap nhat thong tin
            ctx.SaveChanges();
            return RedirectToAction("GetAllSC");
        }
    }
}
