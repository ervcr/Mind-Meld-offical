using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Mind_Meld.Models
{
    public class Cart
    {
        [Key]
        [Required]
        public int ProdID { get; set; }

        //[Display(Name = "Bar Code")]
        //[Required]
        //public string BarCode { get; set; }

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
    }
}
