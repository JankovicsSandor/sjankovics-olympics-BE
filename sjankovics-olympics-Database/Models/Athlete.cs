using System;
using System.Collections.Generic;

#nullable disable

namespace sjankovics_olympics_Database.Models
{
    public partial class Athlete
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nation { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string Sport { get; set; }
    }
}
