using System.ComponentModel.DataAnnotations;

namespace Vac_T.Models
{
    public class JobOffer
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Datum")]
        public DateTime Date { get; set; }
        [Display(Name = "Titel")]
        public string Title { get; set; }
        [Display(Name = "Beschrijving")]
        public string Description { get; set; }
        [Display(Name = "Niveau")]
        public string Level { get; set; }
        public int CompanyId { get; set; }
        public Company? Company { get; set; }
        //public string Image { get; set; }

        virtual public ICollection<UserJobOffer> UserJobOffers { get; set; }
    }
}
