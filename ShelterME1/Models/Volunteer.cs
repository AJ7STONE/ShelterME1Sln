using SQLite;

namespace ShelterME1.Models
{
    public class Volunteer
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string ContactDetails { get; set; }
        public string Email { get; set; }
    }
}
