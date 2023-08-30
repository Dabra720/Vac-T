/*using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Vac_T.Models
{
    public class User : IdentityUser
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Gebruikersnaam")]
        [Required]
        public string Email { get; set; }
        [Display(Name = "Wachtwoord")]
        [Required]
        public string Password { get; set; }
        public string Role { get; set; } = "ROLE_CANDIDATE";
        public UserProfile? Profile { get; set; }
        public Company? Company { get; set; }
        public ICollection<UserJobOffer> UserJobOffers { get; set; } // Opgeslagen joboffers
    }
}
*/