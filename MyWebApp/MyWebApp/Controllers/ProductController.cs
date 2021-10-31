using Microsoft.AspNetCore.Mvc;
using MyWebApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApp.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View(_productService.GetAll());
        }

        public IActionResult Detail(int id)
        {
            return View();
        }
    }
}
