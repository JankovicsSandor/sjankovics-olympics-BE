using sjankovics_olympics_BL.Input;
using sjankovics_olympics_Database.Input;
using sjankovics_olympics_Database.Models;
using System.Linq;

namespace sjankovics_olympics_BL.AthleteLogic
{
    public interface IAthleteLogic
    {
        IQueryable<Athlete> GetAllAthlete();
        Athlete GetOneAthlete(int athleteId);
        Athlete InsertNewAthlete(BaseAthleteCUModel newAthlete);
        void UpdateOneAthlete(int athleteId, UpdateAthleteModel updatedAthleteModel);
    }
}