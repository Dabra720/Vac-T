using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vac_T.Areas.Identity.Data;

namespace Vac_T.Models
{
    public class UserProfile
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public Vac_TUser User { get; set; } = null!;
        public string Name { get; set; }
        public string Surname { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public string Postcode { get; set; }
        public string City { get; set; }
        //public string Image {get; set; }
    }
}
