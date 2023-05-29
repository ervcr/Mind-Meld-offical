using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Mind_Meld.Areas.Identity.Data;

namespace Mind_Meld.Models
{
    public class Dept
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Department ID")]
        [Required]
        public string DeptID { get; set; }

        [Display(Name = "Department Description")]
        [Required]
        public string DeptDesc { get; set; }

        [Display(Name = "Department Name")]
        [Required]
        public string DeptName { get; set; }

    }
}

