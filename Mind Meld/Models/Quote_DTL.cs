using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Mind_Meld.Areas.Identity.Data;

namespace Mind_Meld.Models
{
    public class Quote_DTL
    {
        [Key]
        [Required]  
        public int QuoteDTLid { get; set; }
        [Required]
        public int ProdID { get; set; }
        [Required]
        public int QuoteID { get; set; }
        [Required]
        public int Qty { get; set; }
        [Required]
        public float price { get; set; }    

    }
}
