using MyWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApp.Services
{
    public class ProductServiceFile : IProductService
    {
        static List<Product> products = new List<Product>();     
        
        public ProductServiceFile()
        {
            products.Add(new Product
            {
                Id = 1, ProductName = "Iphone 13", Price = 1399, Discount = 0,
                Description = "N/A", Image = "N/A"
            });
            products.Add(new Product
            {
                Id = 2,
                ProductName = "Dell Latitude 3420",
                Price = 1399,
                Discount = 0,
                Description = "N/A",
                Image = "N/A"
            });
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

        void IProductService.Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
