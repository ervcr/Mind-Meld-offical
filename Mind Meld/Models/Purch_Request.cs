using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Mind_Meld.Areas.Identity.Data;

namespace Mind_Meld.Models
{
    public class Purch_Request
    {
        [Key]
        [Required]
        [Display(Name = "Purch Request")]
        public int RequestID { get; set; }

        [Required]
        [Display(Name = "Request Date")]
        public DateTime RequestDate { get; set; }

       
        [Required]
        [Display(Name = "Employee")]
        [ForeignKey("Employee")]
        public int EmpID { get; set; }
        public virtual Employee user { get; set; }  

        [Required]
        [Display(Name = "Purchase Request Status")]
        public string PRStatus { get; set; }

    }
}
