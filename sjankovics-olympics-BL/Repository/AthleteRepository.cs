using sjankovics_olympics_Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sjankovics_olympics_BL.Repository
{
    public class AthleteRepository : IAthleteRepository
    {
        private olympicsContext context;

        public AthleteRepository(olympicsContext _context)
        {
            context = _context;
        }


        public IQueryable<Athlete> GetAllAthlete()
        {
            return context.Athletes;
        }

        public Athlete UpdateOneAthlete(Athlete updatedAthlete)
        {
            context.Athletes.Update(updatedAthlete);
            context.SaveChanges();

            return updatedAthlete;
        }

        public Athlete InsertNewAthlete(Athlete newAthlete)
        {
            context.Athletes.Add(newAthlete);
            context.SaveChanges();

            return newAthlete;
        }
    }


}
