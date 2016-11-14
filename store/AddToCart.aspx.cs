using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using store.Logic;

namespace store
{
    public partial class AddToCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string rawId = Request.QueryString["ProductID"];
            int productId;
            if (!String.IsNullOrEmpty(rawId) && int.TryParse(rawId, out productId))
            {
                using (Cart usersShoppingCart = new Cart())
                {
                    usersShoppingCart.AddToCart(Convert.ToInt16(rawId));
                }

            }
            else
            {
                throw new Exception("Error 14. See Documentation");
            }
            Response.Redirect("ShoppingCart.aspx");
        }
    }
}