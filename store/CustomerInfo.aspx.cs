using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using store.Models;



namespace store.Checkout
{
    public partial class CheckoutReview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void CheckoutConfirm_Click(object sender, EventArgs e)
        {
            var myOrder = new Order();
            myOrder.OrderDate = DateTime.Now;
            myOrder.FirstName = userLastName.Text;
            myOrder.LastName = userAdress.Text;
            myOrder.Address = userAdress.Text;
            myOrder.City = userCity.Text;
            myOrder.PostalCode = userPostal.Text;
            myOrder.Phone = userPhone.Text;
            myOrder.Email = userEmail.Text;

            ProductContext _db = new ProductContext();

            _db.Orders.Add(myOrder);
            _db.SaveChanges();


            Response.Redirect("~/Checkout/CheckoutComplete.aspx");
        }
    }
}
