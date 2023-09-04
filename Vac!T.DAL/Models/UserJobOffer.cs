
using Vac_T.Areas.Identity.Data;

namespace Vac_T.Models
{
    public class UserJobOffer
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public Vac_TUser User { get; set; } = null!;
        public int JobOfferId { get; set; }
        public JobOffer JobOffer { get; set; } = null!;
        public bool Invited { get; set; } = false;
    }
}
