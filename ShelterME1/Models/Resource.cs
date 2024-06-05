using SQLite;
using System;

namespace ShelterME1.Models
{
    public class Resource
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
       
    }
}
