using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WingtipToys.Models
{
    public class ProductDatabaseInitializer:DropCreateDatabaseIfModelChanges<ProductContext>
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

            return categories;
        }

        private static List<Product> GetProducts()
        {
            var products = new List<Product>
            {
                new Product()
                {
                    ProductID = 1,
                    ProductName = "Convertible Car",
                    Description = "This convertible car is fast ! Engine is powered by a neutrino based battery (not included). Power it up and let it go",
                    ImagePath = "carconvert.png",
                    UnitPrice = 22.50,
                    CategegoryID = 1
                },
                new Product()
                {
                    ProductID = 2,
                    ProductName = "Old-Time Car",
                    Description = "There is nothing old about this toy car.except its looks. Power it up and let it go",
                    ImagePath = "carearly.png",
                    UnitPrice = 15.95,
                    CategegoryID = 1
                },
                new Product()
                {
                    ProductID = 3,
                    ProductName = "Fast Car",
                    Description = "This car is fast but it also floats in water. Power it up and let it go",
                    ImagePath = "carfast.png",
                    UnitPrice = 32.99,
                    CategegoryID = 1
                },
                new Product()
                {
                    ProductID = 4,
                    ProductName = "Super Fast Car",
                    Description = "Use this super fast car to entertain guests. Lights and doors work",
                    ImagePath = "carfaster.png",
                    UnitPrice = 8.95,
                    CategegoryID = 1
                },
                new Product()
                {
                    ProductID = 5,
                    ProductName = "Old Style Racer",
                    Description = "This old style racer can fly (with user assistance). Gravity controls flight duration. No batteries required.",
                    ImagePath = "carracer.png",
                    UnitPrice = 34.95,
                    CategegoryID = 1
                },
                new Product()
                {
                    ProductID = 6,
                    ProductName = "Ace Plane",
                    Description = "Authentic air plane toy. Features realistic colors and details",
                    ImagePath = "planeance.png",
                    UnitPrice = 95.00,
                    CategegoryID = 2
                },
                new Product()
                {
                    ProductID = 7,
                    ProductName = "Glider",
                    Description = "This fun glider is made from real balsa wood. Some assembly required",
                    ImagePath = "planeglider.png",
                    UnitPrice = 4.95,
                    CategegoryID = 2
                },
                new Product()
                {
                    ProductID = 8,
                    ProductName = "Paper Plane",
                    Description = "This paper plane is like no other paper plane. Some folding required",
                    ImagePath = "planepaper.png",
                    UnitPrice = 2.95,
                    CategegoryID = 2
                },
                new Product()
                {
                    ProductID = 9,
                    ProductName = "Propeller Plane",
                    Description = "Rubber band powered plane features two woods.",
                    ImagePath = "planeprop.png",
                    UnitPrice = 32.95,
                    CategegoryID = 2
                },
                new Product()
                {
                    ProductID = 10,
                    ProductName = "Early Truck",
                    Description = "This toy truck has a real gas powered engine. Requires regular tune ups",
                    ImagePath = "truckearly.png",
                    UnitPrice = 15.00,
                    CategegoryID = 3
                },
                new Product()
                {
                    ProductID = 11,
                    ProductName = "Fire Truck",
                    Description = "You will have endless fun with this quarter sized fire truck",
                    ImagePath = "truckfire.png",
                    UnitPrice = 26.00,
                    CategegoryID = 3
                },
                new Product()
                {
                    ProductID = 12,
                    ProductName = "Big Truck",
                    Description = "This fun toy truck can be used to toy other trucks that are not as big",
                    ImagePath = "truckbig.png",
                    UnitPrice = 29.00,
                    CategegoryID = 3
                },
                new Product()
                {
                    ProductID = 13,
                    ProductName = "Big Ship",
                    Description = "Is it a boat or a ship. Let this floating cehicle decide by using its artificially intelligent computer brain",
                    ImagePath = "boatbig.png",
                    UnitPrice = 95.00,
                    CategegoryID = 4
                },
                new Product()
                {
                    ProductID = 14,
                    ProductName = "Paper Boat",
                    Description = "Floating fun for all ! This toy boat can be assembled in seconds. Floats for minutes! Some folding required",
                    ImagePath = "boatpaper.png",
                    UnitPrice = 42.95,
                    CategegoryID = 4
                },
                new Product()
                {
                    ProductID = 15,
                    ProductName = "Sail Boat",
                    Description = "Put this fun toy sail boat in water and let it go",
                    ImagePath = "boatsail.png",
                    UnitPrice = 42.95,
                    CategegoryID = 4
                },
                new Product()
                {
                    ProductID = 16,
                    ProductName = "Rocket",
                    Description = "This fun rocket will travel upto the height of 200 feet",
                    ImagePath = "rocket.png",
                    UnitPrice = 122.95,
                    CategegoryID = 5
                },
            };

            return products;
        }
    }
}