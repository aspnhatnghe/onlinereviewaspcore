using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebApp.Helpers;
using MyWebApp.Models;
using MyWebApp.Services;

namespace MyWebApp.Controllers
{
    public class CartController : Controller
    {
        const string CART_KEY = "GioHang";
        private readonly IProductService _productService;

        public CartController(IProductService productService)
        {
            _productService = productService;
        }

        public List<CartItem> Carts
        {
            get
            {
                var data = HttpContext.Session.Get<List<CartItem>>(CART_KEY);
                if (data == null)
                {
                    data = new List<CartItem>();
                }
                return data;
            }
        }

        public IActionResult Index()
        {
            return View(Carts);
        }

        public IActionResult AddToCart(int id)
        {
            var gioHang = Carts;

            //tìm xem có hàng hóa với id trong giỏ hàng hay chưa
            var item = gioHang.SingleOrDefault(p => p.Id == id);

            if (item != null)//đã có
            {
                item.Quantity++;
            }
            else
            {
                var hangHoa = _productService.GetById(id);
                item = new CartItem
                {
                    Id = id, Quantity = 1, ProductName = hangHoa.ProductName,
                    Image = hangHoa.Image, Price = hangHoa.Price
                };

                gioHang.Add(item);
            }

            //cập nhật session
            HttpContext.Session.Set<List<CartItem>>(CART_KEY, gioHang);

            //return Redirect("/Cart");
            //return Redirect("/Cart/Index");
            return RedirectToAction("Index");
        }
    }
}
