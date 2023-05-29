using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Mind_Meld.Areas.Identity.Data;

// Add profile data for application users by adding properties to the MindMeldUser class
public class MindMeldUser : IdentityUser
{

     [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }

        [PersonalData]
        [DisplayFormat(DataFormatString = "{dd MMM yyyy}")]
        [Display(Name = "Date of Birthday")]
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime DOB { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string Gender { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string Status { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string Role { get; set; }
 
         //[PersonalData]
         [Display(Name = "Recover Account Email")]
         public string RecoverEmail { get; set; }

    [PersonalData]
    [Display(Name = "Active")]
    public string Active { get; set; }

    [PersonalData]
    [Display(Name = "User Type")]
    public string UserType { get; set; }

}

