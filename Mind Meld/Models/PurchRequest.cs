using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Mind_Meld.Areas.Identity.Data;

namespace Mind_Meld.Models
{
    public class PurchRequest
    {
        [Key]
        [Required]
        [Display(Name = "Purch Request")]
        public int RequestID { get; set; }

        [Required]
        [Display(Name = "Request Date")]
        public DateTime RequestDate { get; set; }

        [Display(Name = "Employee")]
        [Required]
        [ForeignKey("User")]
        public string UserID { get; set; }
        public virtual MindMeldUser User { get; set; }

        [Required]
        [Display(Name = "Purchase Request Status")]
        public string PRStatus { get; set; }
    }
}
