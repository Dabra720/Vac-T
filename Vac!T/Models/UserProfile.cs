namespace Vac_T.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public string Postcode { get; set; }
        public string City { get; set; }
        //public string Image {get; set; }
    }
}
