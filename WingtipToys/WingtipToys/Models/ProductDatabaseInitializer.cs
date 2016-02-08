using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WingtipToys.Models
{
    public class ProductDatabaseInitializer:DropCreateDatabaseAlways<ProductContext>
    {
        protected override void Seed(ProductContext context)
        {
            GetCategories().ForEach(c => context.Categories.Add(c));
            GetProducts().ForEach(p => context.Products.Add(p));
        }

        private static List<Category> GetCategories()
        {
            var categories = new List<Category>
            {
                new Category
                {
                    CategoryID = 1,
                    CategoryName = "Cars"
                },
               new Category
                {
                    CategoryID = 2,
                    CategoryName = "Planes"
                },
               new Category
                {
                    CategoryID = 3,
                    CategoryName = "Trucks"
                },
               new Category
                {
                    CategoryID = 4,
                    CategoryName = "Boats"
                },
               new Category
                {
                    CategoryID = 5,
                    CategoryName = "Rockets"
                }
            };
        }

        private static List<Product> GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}