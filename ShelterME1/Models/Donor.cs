using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ShelterME1.Models
{
    public class Donor
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactDetails { get; set; }
        public string Email { get; set; }
        public string Details { get; set; }
        public string DonatedItem { get; set; }
    }
}
