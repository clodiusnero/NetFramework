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
    public partial class Popular : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public IQueryable<Product> FetchPopular([QueryString("category")] string popular)
        {
            var _db = new store.Models.ProductContext();
            IQueryable<Product> query = _db.Products;
            if (popular != null)
            {
                query = query.Where(p => p.Tag.Contains(popular));
            }
            return query;
        }
    }
}