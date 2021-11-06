using MyWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApp.Services
{
    public class ProductServiceFile : IProductService
    {
        static List<Product> products = new List<Product>() {
            new Product
            {
                Id = 1, ProductName = "Iphone 13", Price = 1399, Discount = 0,
                Description = "N/A", Image = "N/A", CategoryId = 1
            },
            new Product
            {
                Id = 2,
                ProductName = "Dell Latitude 3420",
                Price = 1399,
                Discount = 0,
                Description = "N/A",
                Image = "N/A",
                CategoryId = 2
            }
        };     
        
        public ProductServiceFile()
        {           
        }

        public void Add(Product product)
        {
            products.Add(product);
        }

        public void Delete(int id)
        {
            var product = products.SingleOrDefault(p => p.Id == id);
            if(product != null)
            {
                products.Remove(product);
            }
        }

        public List<Product> GetAll()
        {
            return products;
        }

        public Product GetById(int id)
        {
            return products.SingleOrDefault(p => p.Id == id);
        }

        public List<Product> GetProductByCategory(int category)
        {
            return products.Where(p => p.CategoryId == category).ToList();
        }

        void IProductService.Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
