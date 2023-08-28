﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vac_T.Models
{
    public class JobOffer
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Level { get; set; }
        public Company Company { get; set; }
        //public string Image { get; set; }

        virtual public ICollection<UserJobOffer> UserJobOffers { get; set; }
    }
}
