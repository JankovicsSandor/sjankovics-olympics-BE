using sjankovics_olympics_BL.Input;
using sjankovics_olympics_Database.Input;
using sjankovics_olympics_Database.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sjankovics_olympics_BL.AthleteLogic
{
    public class AthleteLogic : IAthleteLogic
    {
        private OlympicsContext context;

        public AthleteLogic(OlympicsContext _context)
        {
            context = _context;
        }

        public IQueryable<Athlete> GetAllAthlete()
        {
            return context.Athletes;
        }

        public Athlete GetOneAthlete(int athleteId)
        {
            if (athleteId <= 0)
            {
                throw new ArgumentException(nameof(athleteId));
            }
            return GetAllAthlete().FirstOrDefault(e => e.Id == athleteId);
        }

        public void UpdateOneAthlete(int athleteId, UpdateAthleteModel updatedAthleteModel)
        {
            Athlete actualAthlete = this.GetOneAthlete(athleteId);
            if (actualAthlete != null && updatedAthleteModel != null && updatedAthleteModel.IsModelValid())
            {
                actualAthlete.DateOfBirth = updatedAthleteModel.DateOfBirth;
                actualAthlete.Height = updatedAthleteModel.Height;
                actualAthlete.Weight = updatedAthleteModel.Weight;
                actualAthlete.Name = updatedAthleteModel.Name;
                actualAthlete.Nation = updatedAthleteModel.Nation;
                actualAthlete.Sport = updatedAthleteModel.Sport;

                context.Athletes.Update(actualAthlete);
                context.SaveChanges();
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public Athlete InsertNewAthlete(BaseAthleteCUModel newAthlete)
        {
            if (newAthlete.IsModelValid())
            {
                Athlete newAthleteDataBase = new Athlete();
                newAthleteDataBase.DateOfBirth = newAthlete.DateOfBirth;
                newAthleteDataBase.Height = newAthlete.Height;
                newAthleteDataBase.Weight = newAthlete.Weight;
                newAthleteDataBase.Name = newAthlete.Name;
                newAthleteDataBase.Nation = newAthlete.Nation;
                newAthleteDataBase.Sport = newAthlete.Sport;

                context.Athletes.Add(newAthleteDataBase);
                context.SaveChanges();

                return newAthleteDataBase;
            }

            throw new ArgumentException();
        }
    }
}
