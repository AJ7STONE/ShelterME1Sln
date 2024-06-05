using SQLite;

namespace ShelterME1.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ContactDetails { get; set; }
        public string Email { get; set; }
        public string OtherDetails { get; set; }
    }
}
