using sjankovics_olympics_Database.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace sjankovics_olympics_Test
{
    public class InvalidUpdateAthleteTestData : TheoryData<UpdateAthleteModel>
    {
        public InvalidUpdateAthleteTestData()
        {
            Add(new UpdateAthleteModel()
            {
                Name="",
                DateOfBirth=new DateTime(1978,1,1)
            });
            Add(new UpdateAthleteModel()
            {
                Name = "a",
                DateOfBirth = new DateTime(1978, 1, 1)
            });
            Add(new UpdateAthleteModel()
            {
                Name = "teIyPWHaKtPYLTDwbbgj wkpNezNBKnZDxVoABCoRwkpNezNBKnZDxVoABCoR",
                DateOfBirth = new DateTime(1978, 1, 1)
            });
        }
    }
}
