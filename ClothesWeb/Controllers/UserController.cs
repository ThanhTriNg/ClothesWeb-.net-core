using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClothesWeb.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ClothesWeb.Controllers
{
    public class UserController : Controller
    {
        ClothesWebContext ctx = new ClothesWebContext();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserModel.LoginModel L)
        {
            if (ModelState.IsValid)
            {
                UserManager mg = new UserManager();
                if (mg.CheckLogin(L.Email, L.Password))
                {
                    //Nên lưu Session thay vì gọi database vì tốn thời gian                    
                    HttpContext.Session.SetString("Email", L.Email);
                    HttpContext.Session.SetString("Password", L.Password);
                    return RedirectToAction("Index", "Customer");
                }
                else
                {
                    ViewBag.Error = "Sai tài khoản hoặc mật khẩu";
                    return View();
                }
            }
            return View();
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserModel.RegisterModel R)
        {
            if (ModelState.IsValid) // kiểm tra xem mô hình có hợp lệ cho cơ sở dư liệu không
            {
                UserManager mg = new UserManager();
                if (mg.CheckCustomerName(R.Name) && mg.CheckCustomerEmail(R.Email))
                {
                    User user = new User();
                    user.UserName = R.Name;
                    user.UserEmail = R.Email;
                    user.UserAddress = R.Adress;
                    user.UserPhone = R.Phone;


                    user.UserPassword = Encrypt.MD5Hash(R.Password);
                    ctx.Users.Add(user); //thêm mới danh sách trên dataset
                    ctx.SaveChanges(); //cập nhật vào database
                    return RedirectToAction("Index", "Customer");
                    // Success

                }
                else if (mg.CheckCustomerName(R.Name)==false)
                {
                    //view regiter nay khong ton tai ten no loi. 
                    ModelState.AddModelError("Register", "Tên tài khoản đã tồn tại");
                    return View();
                }
                else if (mg.CheckCustomerEmail(R.Email) == false)
                {
                    //view regiter nay khong ton tai ten no loi. 
                    ModelState.AddModelError("Register", "Email đã tồn tại");
                    return View();
                }

            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Customer");
        }
    }
}
