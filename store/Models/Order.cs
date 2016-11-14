using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace store.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        public System.DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "Requried field")]
        [DisplayName("First Name")]
        [StringLength(160)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Requried field")]
        [DisplayName("Last Name")]
        [StringLength(160)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Requried field")]
        [StringLength(70)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Requried field")]
        [StringLength(40)]
        public string City { get; set; }


        [Required(ErrorMessage = "Requried field")]
        [DisplayName("Postal Code")]
        [StringLength(10)]
        public string PostalCode { get; set; }

        [StringLength(24)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Requried field")]
        [DisplayName("Email Address")]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        public decimal Total { get; set; }

        [ScaffoldColumn(false)]
        public double TotalVAT { get; set; }

        [ScaffoldColumn(false)]
        public List<OrderInfo> OrderInfos { get; set; }
    }
}