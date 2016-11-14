using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using store.Models;

namespace store.Logic
{
    public class Cart : IDisposable
    {
        public string ShoppingCartId { get; set; }

        private ProductContext _db = new ProductContext();

        public const string CartSessionKey = "CartId";

        public void AddToCart(int id)
        {   
            ShoppingCartId = GetCartId();

            var cartItem = _db.ShoppingCartProducts.SingleOrDefault(
                c => c.CartId == ShoppingCartId
                && c.ProductId == id);


            if (cartItem == null)
            {           
                cartItem = new CartProduct
                {
                    ItemId = Guid.NewGuid().ToString(),
                    ProductId = id,
                    CartId = ShoppingCartId,
                    Product = _db.Products.SingleOrDefault(
                   p => p.ProductID == id),
                    Quantity = 1,
                    DateCreated = DateTime.Now
                };

                _db.ShoppingCartProducts.Add(cartItem);
            }
            else
            {            
                cartItem.Quantity++;
            }
            _db.SaveChanges();
        }

        public void Dispose()
        {
            if (_db != null)
            {
                _db.Dispose();
                _db = null;
            }
        }

        public string GetCartId()
        {
            if (HttpContext.Current.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
                {
                    HttpContext.Current.Session[CartSessionKey] = HttpContext.Current.User.Identity.Name;
                }
                else
                {  
                    Guid tempCartId = Guid.NewGuid();
                    HttpContext.Current.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return HttpContext.Current.Session[CartSessionKey].ToString();
        }

        public List<CartProduct> GetCartItems()
        {
            ShoppingCartId = GetCartId();

            return _db.ShoppingCartProducts.Where(
                c => c.CartId == ShoppingCartId).ToList();
        }



        public decimal GetTotal()
        {
            ShoppingCartId = GetCartId();

            decimal? total = decimal.Zero;
            total = (decimal?)(from cartItems in _db.ShoppingCartProducts
                               where cartItems.CartId == ShoppingCartId
                               select cartItems.Quantity *
                               cartItems.Product.UnitPrice).Sum();
            return total ?? decimal.Zero;
        }

        public double GetTotalVAT()
        {
            ShoppingCartId = GetCartId();

            double totalVAT = 0;
            totalVAT = (double)(from cartItems in _db.ShoppingCartProducts
                               where cartItems.CartId == ShoppingCartId
                               select cartItems.Quantity *
                               cartItems.Product.UnitPrice).Sum() * 0.25;
            return totalVAT;
        }

        public Cart GetCart(HttpContext context)
        {
            using (var cart = new Cart())
            {
                cart.ShoppingCartId = cart.GetCartId();
                return cart;
            }
        }

        public void UpdateShoppingCartDatabase(String cartId, ShoppingCartUpdates[] CartItemUpdates)
        {
            using (var db = new store.Models.ProductContext())
            {
                try
                {
                    int CartItemCount = CartItemUpdates.Count();
                    List<CartProduct> myCart = GetCartItems();
                    foreach (var cartItem in myCart)
                    {
                        for (int i = 0; i < CartItemCount; i++)
                        {
                            if (cartItem.Product.ProductID == CartItemUpdates[i].ProductId)
                            {
                                if (CartItemUpdates[i].PurchaseQuantity < 1 || CartItemUpdates[i].RemoveItem == true)
                                {
                                    RemoveItem(cartId, cartItem.ProductId);
                                }
                                else
                                {
                                    UpdateItem(cartId, cartItem.ProductId, CartItemUpdates[i].PurchaseQuantity);
                                }
                            }
                        }
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("Unable to Update Cart Database - " + exp.Message.ToString(), exp);
                }
            }
        }

        public void RemoveItem(string removeCartID, int removeProductID)
        {
            using (var _db = new store.Models.ProductContext())
            {
                try
                {
                    var myItem = (from c in _db.ShoppingCartProducts where c.CartId == removeCartID && c.Product.ProductID == removeProductID select c).FirstOrDefault();
                    if (myItem != null)
                    {
                        _db.ShoppingCartProducts.Remove(myItem);
                        _db.SaveChanges();
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("ERROR: Unable to Remove Cart Item - " + exp.Message.ToString(), exp);
                }
            }
        }

        public void UpdateItem(string updateCartID, int updateProductID, int quantity)
        {
            using (var _db = new store.Models.ProductContext())
            {
                try
                {
                    var myItem = (from c in _db.ShoppingCartProducts where c.CartId == updateCartID && c.Product.ProductID == updateProductID select c).FirstOrDefault();
                    if (myItem != null)
                    {
                        myItem.Quantity = quantity;
                        _db.SaveChanges();
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("Unable to Update Cart Item - " + exp.Message.ToString(), exp);
                }
            }
        }

        public void EmptyCart()
        {
            ShoppingCartId = GetCartId();
            var cartItems = _db.ShoppingCartProducts.Where(
                c => c.CartId == ShoppingCartId);
            foreach (var cartItem in cartItems)
            {
                _db.ShoppingCartProducts.Remove(cartItem);
            }           
            _db.SaveChanges();
        }

        public void MigrateCart(string cartId, string userName)
        {
            var shoppingCart = _db.ShoppingCartProducts.Where(c => c.CartId == cartId);
            foreach (CartProduct item in shoppingCart)
            {
                item.CartId = userName;
            }
            HttpContext.Current.Session[CartSessionKey] = userName;
            _db.SaveChanges();
        }


        public int GetCount()
        {
            ShoppingCartId = GetCartId();

            int? count = (from cartItems in _db.ShoppingCartProducts
                          where cartItems.CartId == ShoppingCartId
                          select (int?)cartItems.Quantity).Sum();
            return count ?? 0;
        }

        public struct ShoppingCartUpdates
        {
            public int ProductId;
            public int PurchaseQuantity;
            public bool RemoveItem;
        }
    }
}