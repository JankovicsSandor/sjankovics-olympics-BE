using sjankovics_olympics_BL.Input;
using sjankovics_olympics_BL.Repository;
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
        private IAthleteRepository athleteRepo;

        public AthleteLogic(IAthleteRepository _athleteRepository)
        {
            athleteRepo = _athleteRepository;
        }

        public IQueryable<Athlete> GetAllAthlete()
        {
            return athleteRepo.GetAllAthlete();
        }


        public Athlete GetOneAthlete(int athleteId)
        {
            if (athleteId <= 0)
            {
                throw new ArgumentException(nameof(athleteId));
            }
            return athleteRepo.GetAllAthlete().FirstOrDefault(e => e.Id == athleteId);
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
                actualAthlete.Gender = updatedAthleteModel.Gender;
                actualAthlete.Nation = updatedAthleteModel.Nation;
                actualAthlete.Sport = updatedAthleteModel.Sport;

                athleteRepo.UpdateOneAthlete(actualAthlete);
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
                newAthleteDataBase.Gender = newAthlete.Gender;
                newAthleteDataBase.Nation = newAthlete.Nation;
                newAthleteDataBase.Sport = newAthlete.Sport;

                newAthleteDataBase = athleteRepo.InsertNewAthlete(newAthleteDataBase);

                return newAthleteDataBase;
            }

            throw new ArgumentException();
        }
    }
}
