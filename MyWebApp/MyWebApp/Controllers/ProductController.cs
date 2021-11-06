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

        public IActionResult Index(int? category)
        {
            var data = category.HasValue ? _productService.GetProductByCategory(category.Value) : _productService.GetAll();

            return View(data);
        }

        public IActionResult Detail(int id)
        {
            var product = _productService.GetById(id);
            if (product != null)
            {
                return View(product);
            }
            return NotFound();
        }
    }
}
