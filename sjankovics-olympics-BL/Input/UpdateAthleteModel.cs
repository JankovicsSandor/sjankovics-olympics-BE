using sjankovics_olympics_BL.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sjankovics_olympics_Database.Input
{
    public class UpdateAthleteModel: BaseAthleteCUModel
    {
        public int Id { get; set; }

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
