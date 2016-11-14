using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace store.Models
{
    public class OrderInfo
    {
        public int OrderInfoId { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public double UnitPrice { get; set; }
    }
}