using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using store.Models;

namespace store.Logic
{
    public class OrderActions : IDisposable
    {
        public string ShoppingOrderId { get; set; }

        private ProductContext _db = new ProductContext();

        public const string OrderSessionId = "OrderId";

        public void AddToOrder(int id)
        {
            ShoppingOrderId = GetOrderId();

            var orderItem = _db.OrderDetails.SingleOrDefault(
                c => c.CartId == ShoppingCartId
                && c.ProductId == id);


        }

        public string GetOrderId()
        {
            if (HttpContext.Current.Session[OrderSessionId] == null)
            {
                if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
                {
                    HttpContext.Current.Session[OrderSessionId] = HttpContext.Current.User.Identity.Name;
                }
                else
                {
                    Guid tempOrderId = Guid.NewGuid();
                    HttpContext.Current.Session[OrderSessionId] = tempOrderId.ToString();
                }
            }
            return HttpContext.Current.Session[OrderSessionId].ToString();
        }


        public void Dispose()
        {
            if (_db != null)
            {
                _db.Dispose();
                _db = null;
            }
        }
    }
}