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

        public string CustomerId { get; set; }

        public DateTime ExpiryDate { get; set; }

    }
}
