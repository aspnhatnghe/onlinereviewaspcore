using MyWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApp.Services
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category GetById(int id);     
    }

    public class CategoryServiceStatic : ICategoryService
    {
        static List<Category> categories = new List<Category>
        {
            new Category
            {
                Id = 1, CategoryName = "Phone"
            },
            new Category
            {
                Id = 2, CategoryName = "Laptop"
            },
            new Category
            {
                Id = 3, CategoryName = "Tablet"
            },
        };

        public List<Category> GetAll()
        {
            return categories;
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
