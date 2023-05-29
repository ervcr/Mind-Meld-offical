using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Mind_Meld.Areas.Identity.Data;

namespace Mind_Meld.Models
{
    public class PR_DTL
    {
        [Key]
        [Required]
        public int PR_DTLid { get; set; }   

        [Required]
        [Display(Name = "Purch Request Date")]
        [ForeignKey("PurchRequest")]
        public int RequestID { get; set; }
        public virtual PurchRequest PurchRequest { get; set; }

        [Display(Name = "Product Name")]
        [Required]
        [ForeignKey("Product")]
        public int ProdID { get; set; }
        public virtual Product  Product { get; set; }   


       [Display(Name = "Product Quantity")]
        [Required]
        public String Qty { get; set; }
    }
}
