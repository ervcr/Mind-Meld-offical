using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using Mind_Meld.Areas.Identity.Data;

namespace Mind_Meld.Models
{
    public class Product
    {
        [Key]
        [Required]
        public int ProdID { get; set; }

        [Display(Name = "Bar Code")]
        [Required]
        public string BarCode { get; set; }

        [Display(Name = "Product Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Product Description")]
        [Required]
        public string Description { get; set; }

        [Display(Name = "Product Image")]
        [Required]
        [NotMapped]
        public IFormFile Image { get; set; } // Use IFormFile to receive the uploaded image
        public string ImagePath { get; set; } // Store the image path in the database

        [Required]
        public float Price { get; set; }

        [Display(Name = "Supplier")]
        [Required]
        [ForeignKey("Supplier")]
        public int SuppID { get; set; }
        public virtual Supplier Supplier { get; set; }

    }
}
