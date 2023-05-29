using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Mind_Meld.Areas.Identity.Data;

namespace Mind_Meld.Models
{
    public class Purch_Order
    {
        [Key]
        [Required]
        public int OrderID { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        [Display(Name = "Purch Request Date")]
        [ForeignKey("PurchRequest")]
        public int RequestID { get; set; }
        public virtual PurchRequest PurchRequest { get; set; } 

        [Required]
        public int POTotal { get; set; }

        [Required]
        [Display(Name = "Supplier")]
        [ForeignKey("Supplier")]
        public int SuppID { get; set; }
        public virtual Supplier Supplier { get; set; }  

        [Required]
        public string POProgress { get; set; }  

    }
}
