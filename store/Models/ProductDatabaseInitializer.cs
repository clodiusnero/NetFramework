using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace store.Models
{
    public class ProductDatabaseInitializer : DropCreateDatabaseAlways<ProductContext>
    {
        protected override void Seed(ProductContext context)
        {
            GetCategories().ForEach(c => context.Categories.Add(c));
            GetProducts().ForEach(p => context.Products.Add(p));
        }

        private static List<Category> GetCategories()
        {
            var categories = new List<Category> {
                new Category
                {
                    CategoryID = 1,
                    CategoryName = "Sweaters"
                },
                new Category
                {
                    CategoryID = 2,
                    CategoryName = "Shirts"
                },
                 new Category
                {
                    CategoryID = 3,
                    CategoryName = "Pants"
                },
                new Category
                {
                    CategoryID = 4,
                    CategoryName = "Outwear"
                },
                new Category
                {
                    CategoryID = 5,
                    CategoryName = "Underwear"
                },
                new Category
                {
                    CategoryID = 6,
                    CategoryName = "Accessoriers"
                },

            };

            return categories;
        }

        private static List<Product> GetProducts()
        {
            var products = new List<Product> {
                new Product
                {
                    ProductID = 1,
                    ProductName = "Hoddie Nick Cornflower",
                    Description = "Long-sleeved, textured-knit sweater in a hampa and cotton blend. ",
                    Details = "55% Hampa, 45% Organic Cotton. " +
                              "Machine wash warm. " +
                              "Art.No. 4546-01 ",
                    Tag="New",
                    Size="M",
                    ImagePath ="Nick-Sweater.jpg",
                    UnitPrice = 385,
                    CategoryID = 1
               },
                new Product
                {
                    ProductID = 2,
                    ProductName = "Boxer-2p Himalaya",
                    Description = "Patterned boxer shorts in cotton jersey with short legs, elasticized waistband, and lined front.",
                    Details = "Boxer shorts, 95% Organic Cotton, 5% Elastan GOTS. " +
                              "Machine wash hot. " +
                              "Art.No. 87-4219",
                    Tag="Popular",
                    Size="XL",
                    ImagePath ="Boxer-2p.jpg",
                    UnitPrice = 399,
                    CategoryID = 5
               },
                new Product
                {
                    ProductID = 3,
                    ProductName = "Shirt Terence",
                    Description = "Shirt in woven cotton fabric with sewn panel in hampa with embroidered text. Turn-down collar, concealed buttons at front, and cuffs with buttons. Regular fit.",
                    Details = "86% Organic Cotton, 14% Hampa. " +
                              "Machine wash warm. " +
                              "Art.No. 86-8508",
                    Tag="Campain",
                    Size="XL",
                    ImagePath ="Terance-Ink-Shirt.jpg",
                    UnitPrice = 495,
                    CategoryID = 2
               },
                new Product
                {
                    ProductID = 4,
                    ProductName = "Jeans Hampa",
                    Description = "Jeans in washed denim with a regular waist, button fly, front and back pockets, and straight legs.",
                    Details = " 100% Hampa. " +
                              "Machine wash warm. " +
                              "Art.No. 89-5554",
                    Size="M",
                    ImagePath ="Jeans-Hampa.jpg",
                    UnitPrice = 699,
                    CategoryID = 3
               },
                new Product
                {
                    ProductID = 5,
                    ProductName = "T-shirt White",
                    Description = "T-shirt in cotton jersey.",
                    Details = " 100% Organic Cotton. " +
                              "Machine wash warm. " +
                              "Art.No. 93-7600",
                    Size="M",
                    ImagePath ="T-shirt-White.jpg",
                    UnitPrice = 195,
                    CategoryID = 2
               },
                new Product
                {
                    ProductID = 6,
                    ProductName = "T-shirt White",
                    Description = "T-shirt in cotton jersey.",
                    Details = " 100% Organic Cotton. " +
                              "Machine wash warm. " +
                              "Art.No. 93-7600",
                    Size="L",
                    ImagePath ="T-shirt-White.jpg",
                    UnitPrice = 195,
                    CategoryID = 2
               },

            };
            return products;
        }

        private static List<Order> GetOrders()
        {
            var Orders = new List<Order> {
                 new Order
                {
                     FirstName = "Johan",
                     LastName = "Andersson",
                     OrderDate = DateTime.Now,
                     Address = "Karlsongatan 1",
                     City = "Helsingborg",
                     PostalCode = "12345",
                     Phone = "12345678",
                     Email = "123@123.com",
                     Total = 10000,
                     TotalVAT = 25000,
               }
            };
            return Orders;
        }
    }

}