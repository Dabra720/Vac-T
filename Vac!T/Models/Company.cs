using System.ComponentModel.DataAnnotations;

namespace Vac_T.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        //public string Image { get; set; }
        virtual public ICollection<User> Users { get; set; }
        virtual public ICollection<JobOffer> JobOffers { get; set; }
    }
}
