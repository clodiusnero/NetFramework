using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace store.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext() : base("store")
        {
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderInfo> OrderDetails { get; set; }
        public DbSet<CartProduct> ShoppingCartProducts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}