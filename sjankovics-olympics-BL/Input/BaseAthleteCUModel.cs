using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sjankovics_olympics_BL.Input
{
    public class BaseAthleteCUModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Name must be at least 2 char")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public string Nation { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }

        [Required]
        public string Sport { get; set; }

        public bool IsModelValid()
        {
            bool valid = true;

            if (string.IsNullOrEmpty(Name) || Name.Length < 2)
            {
                valid = false;
            }

            if (DateOfBirth == default(DateTime))
            {
                valid = false;
            }

            return valid;
        }
    }
}
