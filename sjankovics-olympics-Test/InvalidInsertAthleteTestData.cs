using sjankovics_olympics_BL.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace sjankovics_olympics_Test
{
    class InvalidInsertAthleteTestData : TheoryData<BaseAthleteCUModel>
    {
        public InvalidInsertAthleteTestData()
        {
            Add(new BaseAthleteCUModel()
            {
                Name = "",
                DateOfBirth = new DateTime(1978, 1, 1)
            });
            Add(new BaseAthleteCUModel()
            {
                Name = "a",
                DateOfBirth = new DateTime(1978, 1, 1)
            });
            Add(new BaseAthleteCUModel()
            {
                Name = "teIyPWHaKtPYLTDwbbgj wkpNezNBKnZDxVoABCoRKnZDxVoABCoRKnZDxVoABCoRKnZDxVoABCoR",
                DateOfBirth = new DateTime(1978, 1, 1)
            });
        }
    }
}
