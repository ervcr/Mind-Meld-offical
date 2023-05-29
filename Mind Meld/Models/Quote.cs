using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Mind_Meld.Areas.Identity.Data;

namespace Mind_Meld.Models
{
    public class Quote
    {
        [Key]
        [Required]
        public int QuoteID { get; set; }

        [Required]
        public DateTime QuoteDate { get; set; }

        [Required]
        public DateTime ExpiryDate { get; set; }
        [Required]
        public string CustomerId { get; set; }
        [Required]
        public string productDescription { get; set; }
        [Required]
        public string message { get; set; }

    }
}
