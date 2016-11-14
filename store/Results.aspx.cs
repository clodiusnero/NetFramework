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
    public partial class Results : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Product> SearchResult([QueryString("srch")] string search)
        {
            var _db = new store.Models.ProductContext();
            IQueryable<Product> query = _db.Products;
            if (search != null )
            {
                query = query.Where(p => p.ProductName.Contains(search) || p.Description.Contains(search) || p.Details.Contains(search));
            }
            return query;
        }
    }
}