using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Session;
using ClothesWeb.Models;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
namespace ClothesWeb.Controllers
{
    public class CustomerController : Controller
    {
        private const string cart_null = "Giỏ hàng rỗng nha bạn ơi.";
        private const string review_null = "Hiện tại chưa có đánh giá. Hãy là người đầu tiên đánh giá sản phẩm";

        ClothesWebContext ctx = new ClothesWebContext();
        public IActionResult Index()
        {
           
            ViewBag.GetAllClothes = ctx.Clothes.ToList();
            ViewBag.GetCategoryTop = ctx.Categories.Where(x => x.CategoryName.Contains("Áo") ).ToList();
            ViewBag.GetCategoryBottom = ctx.Categories.Where(x => x.CategoryName.Contains("Quần")).ToList();
            ViewBag.Get9Clothes = ctx.Clothes.Take(9).ToList();
            //ViewBag.GetCategoryAccessories = ctx.Categories.Where(x => x.CategoryName.Except("Quần")).ToList();
            return View();
        }
        public IActionResult ProductList()
        {
            ViewBag.Title = "Áo";
            ViewBag.SubTitle = "Đa dạng màu sắc và kiểu dáng, phù hợp với nhiều phong cách.";
            return View();

        }



        public IActionResult tops()
        {
            //List<Clothe> clothes = ctx.Clothes.Where(x => x.ClothesName.Contains(top)).ToList();
           
            List<Clothe> clothes = ctx.Clothes.Where(x => x.ClothesName.Contains("Áo")).ToList();
            ViewBag.Title = "Áo";
            ViewBag.SubTitle = "Đa dạng màu sắc và kiểu dáng, phù hợp với nhiều phong cách.";
            return View(clothes);
        }



        public IActionResult bottom()
        {
            //List<Clothe> clothes = ctx.Clothes.Where(x => x.ClothesName.Contains("Quần")).ToList();
            List<Clothe> clothes = ctx.Clothes.Where(x => x.ClothesName.Contains("Quần")).ToList();
            ViewBag.Title = "Quần";
            ViewBag.SubTitle = "Các kiểu dáng phù hợp với mọi lứa tuổi.";
            return View(clothes);
        }

        public IActionResult accessory()
        {
            //List<Clothe> clothes = ctx.Clothes.Where(x => x.ClothesName.Contains(top)).ToList();

            List<Clothe> clothes = ctx.Clothes.Where(x => (!x.ClothesName.Contains("Áo")) && (!x.ClothesName.Contains("Quần")) ).ToList();

            ViewBag.Title = "Áo";
            ViewBag.SubTitle = "Đa dạng màu sắc và kiểu dáng, phù hợp với nhiều phong cách.";
            return View(clothes);
        }

        public IActionResult OnlyLayout()
        {
            return View();
        }
        public IActionResult ProductDetail(int id)
        {
            Clothe clothes = ctx.Clothes.Where(x => x.ClothesId == id).SingleOrDefault();
            //ViewBag.GetClothes = clothes
            ViewBag.GetAllClothes = ctx.Clothes.ToList();

            List<Review> review = ctx.Reviews.Where(x => x.ClothesId == id).ToList();
            
            if(review.Count == 0)
            {
                ViewBag.GetReview = review;
                ViewBag.review_null = review_null;
            }
            else
            {
                ViewBag.GetReview = review;
            }
            return View(clothes);
        }

        public IActionResult Cart()
        {
           
            ViewBag.GetAllClothes = ctx.Clothes.ToList();
            var sessionID = HttpContext.Session.Id;
            ViewBag.sessionID = sessionID;
            List<ItemCart> items = null;
            //doc session
            var yourcart = HttpContext.Session.GetString("yourcart");
            //chuyen string json --> object
            if (yourcart != null)
            {
                items = (List<ItemCart>)JsonSerializer.Deserialize(yourcart, typeof(List<ItemCart>));
                ViewBag.feeship = 25000;
            }
            else
            {
                ViewBag.cart_null = cart_null;
                ViewBag.feeship = 0;
                items = new List<ItemCart>();
            }
            ViewBag.Cart = items;
            
            //total
            decimal total = 0;
            foreach (ItemCart item in items)
            {
                total += item.Price * item.Quantity;
            }

            ViewBag.Total = total;
            return View();
        }
        public IActionResult AddToCart()
        {

        /*   List<ItemCart> cart = HttpContext.Session.GetString("yourcart").ToList();*/

            int id = int.Parse(Request.Form["ClothesId"].ToString());
            int quantity = int.Parse(Request.Form["SiQty"].ToString());
            List<ItemCart> items = null;

            Clothe prod = ctx.Clothes.Where(x => x.ClothesId == id).SingleOrDefault();


            var yourcart = HttpContext.Session.GetString("yourcart");

            //chuyen string json => object
            if (yourcart != null)
            {
                items = (List<ItemCart>)JsonSerializer.Deserialize(yourcart, typeof(List<ItemCart>));
                ViewBag.Cart = items;

                var cartitem = items.Find(p => p.Id == id);

                if (cartitem != null)
                {
                    var itemID = items.Find(p => p.Id == id);

                    var i = items.Where(p => p.Id == itemID.Id).FirstOrDefault();
                    i.Quantity = itemID.Quantity + quantity;
                    HttpContext.Session.SetString("yourcart", JsonSerializer.Serialize(items, typeof(List<ItemCart>)));

                }
                else
                {
                    // Tao item trong gio hang

                    ItemCart item = new ItemCart()
                    {
                        Id = id,
                        Quantity = quantity,
                        img = prod.ClothesImg,
                        Price = (Decimal)prod.ClothesPrice,
                        Name = prod.ClothesName,
                    };
                    // Bo item vao gio hang
                    items.Add(item);


                    //Luu seesion

                    HttpContext.Session.SetString("yourcart", JsonSerializer.Serialize(items, typeof(List<ItemCart>)));

                }
            }
            else
            {
                items = new List<ItemCart>();
                // Tao item trong gio hang

                ItemCart item = new ItemCart()
                {
                    Id = id,
                    Quantity = quantity,
                    img = prod.ClothesImg,
                    Price = (Decimal)prod.ClothesPrice,
                    Name = prod.ClothesName,


                };
                // Bo item vao gio hang
                items.Add(item);


                //Luu seesion

                HttpContext.Session.SetString("yourcart", JsonSerializer.Serialize(items, typeof(List<ItemCart>)));
            }


            return RedirectToAction("cart");
        }


        public IActionResult RemoveCart(int id)
        {

            List<ItemCart> items;
            var yourcart = HttpContext.Session.GetString("yourcart");
            //chuyen string json => object
            if (yourcart != null)
            {
                items = (List<ItemCart>)JsonSerializer.Deserialize(yourcart, typeof(List<ItemCart>));
                ViewBag.Cart = items;

                var cartitem_remove = items.FindIndex(p => p.Id == id);
                items.RemoveAt(cartitem_remove);
                HttpContext.Session.SetString("yourcart", JsonSerializer.Serialize(items, typeof(List<ItemCart>)));


            }
            return RedirectToAction("cart");
        }

        [HttpPost]
        public IActionResult SaveReview(Review contact)
        {
            int id = int.Parse(Request.Form["ClothesId"].ToString());
            ViewBag.save = ctx.Reviews.Add(contact);
            ctx.SaveChanges();
            return RedirectToAction("ProductDetail", "Customer", new { id = id });
        }

        public IActionResult Signup()
        {
            return View();
        }
    }
}
