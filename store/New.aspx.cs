using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using store.Models;
using System.Web.ModelBinding;

namespace store
{
    public partial class New : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public IQueryable<Product> FetchNewArrivals([QueryString("category")] string newArrivals)
        {
            var _db = new store.Models.ProductContext();
            IQueryable<Product> query = _db.Products;
            if (newArrivals != null)
            {
                query = query.Where(p => p.Tag.Contains(newArrivals));
            }
            return query;
        }
    }
}