using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Vac_T.Models
{
    public class User : IdentityUser
    {
        public UserProfile? Profile { get; set; }
        public Company? Company { get; set; }
        public ICollection<UserJobOffer> UserJobOffers { get; set; } // Opgeslagen joboffers
    }
}
