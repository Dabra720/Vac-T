using System.ComponentModel.DataAnnotations;

namespace Vac_T.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Role { get; set; }
        public UserProfile? Profile { get; set; }
        public Company? Company { get; set; }
        public ICollection<UserJobOffer> UserJobOffers { get; set; } // Opgeslagen joboffers
    }
}
