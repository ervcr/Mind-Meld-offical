using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Mind_Meld.Areas.Identity.Data;


namespace Mind_Meld.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        
        [Display(Name = "Employee")]
        [Required]
        [ForeignKey("User")]
        public string UserID { get; set; }  
        public virtual MindMeldUser User { get; set; }

        [Display(Name = "Gender")]
       // [Required]
        public string Gender { get; set; }

        [Display(Name = "GradeLevel")]
        [Required]
        public string GradeLevel { get; set; }

        [Display(Name = "Department")]
        [Required]
        [ForeignKey("Dept")]
        public string DeptID { get; set; }
        public virtual Dept Dept { get; set; }
    }
}
