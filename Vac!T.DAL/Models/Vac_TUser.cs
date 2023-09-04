using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Vac_T.Models;

namespace Vac_T.Areas.Identity.Data;

// Add profile data for application users by adding properties to the Vac_TUser class
public class Vac_TUser : IdentityUser
{
    /*[Key]
    public int Id { get; set; }
    [Display(Name = "Gebruikersnaam")]
    public string Email { get; set; }
    [Display(Name = "Wachtwoord")]
    public string Password { get; set; }
    public string Role { get; set; } = "ROLE_CANDIDATE";*/
    //[ForeignKey("ProfileId")]
    public int? ProfileId { get; set; }
    public UserProfile Profile { get; set; }
    //[ForeignKey("CompanyId")]
    public int? CompanyId { get; set; }
    public Company Company { get; set; }
    public ICollection<UserJobOffer> UserJobOffers { get; set; } // Opgeslagen joboffers

}

