using System.ComponentModel.DataAnnotations;
using Vac_T.Areas.Identity.Data;

namespace Vac_T.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Bedrijf")]
        public string Name { get; set; }
        [Display(Name = "Stad")]
        public string City { get; set; }
        //public string Image { get; set; }
        virtual public ICollection<Vac_TUser> Users { get; set; }
        virtual public ICollection<JobOffer> JobOffers { get; set; }
    }
}
