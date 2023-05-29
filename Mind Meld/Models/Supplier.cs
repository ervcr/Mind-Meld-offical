using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Mind_Meld.Areas.Identity.Data;

namespace Mind_Meld.Models
{
    public class Supplier
    {
        [Key]
        [Required]
        public int SuppID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
