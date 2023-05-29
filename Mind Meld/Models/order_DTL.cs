using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Mind_Meld.Areas.Identity.Data;

namespace Mind_Meld.Models
{
    public class order_DTL
    {
        [Key]
        [Required]
        public int order_DTLid { get; set; }

        [Required]
        public int OrderID { get; set; }

        [Required]
        public int ProdID  { get; set; }

        [Required]
        public string Qty { get; set; }

        [Required]
        public float price { get; set; }

    }
}
