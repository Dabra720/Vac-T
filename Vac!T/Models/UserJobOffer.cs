namespace Vac_T.Models
{
    public class UserJobOffer
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public int JobOfferId { get; set; }
        public JobOffer JobOffer { get; set; } = null!;
    }
}
