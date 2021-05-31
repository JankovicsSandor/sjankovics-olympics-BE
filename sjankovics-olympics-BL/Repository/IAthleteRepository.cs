using sjankovics_olympics_Database.Models;
using System.Linq;

namespace sjankovics_olympics_BL.Repository
{
    public interface IAthleteRepository
    {
        IQueryable<Athlete> GetAllAthlete();
        Athlete InsertNewAthlete(Athlete newAthlete);
        Athlete UpdateOneAthlete(Athlete updatedAthlete);
    }
}