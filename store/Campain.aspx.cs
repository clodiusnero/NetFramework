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
    public partial class Campain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public IQueryable<Product> FetchCampain([QueryString("category")] string search)
        {
            var _db = new store.Models.ProductContext();
            IQueryable<Product> query = _db.Products;
            if (search != null)
            {
                query = query.Where(p => p.Tag.Contains(search));
            }
            return query;
        }
    }
}