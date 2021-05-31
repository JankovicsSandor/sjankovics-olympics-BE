using Microsoft.EntityFrameworkCore;
using Moq;
using sjankovics_olympics_BL.AthleteLogic;
using sjankovics_olympics_BL.Input;
using sjankovics_olympics_BL.Repository;
using sjankovics_olympics_Database.Input;
using sjankovics_olympics_Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace sjankovics_olympics_Test
{
    public class AthleteLogicTest
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(454)]
        public void UpdateOneAthleteWhenNoSuchAthlete(int athleteId)
        {
            var _athleteLogic = new AthleteLogic(new Mock<IAthleteRepository>().Object);

            Assert.Throws<ArgumentException>(() => _athleteLogic.UpdateOneAthlete(athleteId, null));
        }

        [Theory]
        [ClassData(typeof(InvalidUpdateAthleteTestData))]
        public void UpdateOneAthleteWhenSuchAthleteButInvalidAthlete(UpdateAthleteModel updateAthlete)
        {
            Athlete sportAthlete = new Athlete() { Id = 1, DateOfBirth = new DateTime(1972, 2, 4), Gender = "F", Height = 152, Name = "Josh Bolt", Nation = "GB", Sport = "Archery", Weight = 78 };

            Mock<IAthleteRepository> mockAthleteRepo = new Mock<IAthleteRepository>();
            mockAthleteRepo.Setup(e => e.GetAllAthlete()).Returns(() => new List<Athlete>() { sportAthlete }.AsQueryable());

            var _athleteLogic = new AthleteLogic(mockAthleteRepo.Object);

            Assert.Throws<ArgumentException>(() => _athleteLogic.UpdateOneAthlete(1, updateAthlete));
        }

        [Fact]
        public void UpdateOneAthleteWhenSuchAthleteAndValidAthlete()
        {
            Athlete sportAthlete = new Athlete() { Id = 1, DateOfBirth = new DateTime(1972, 2, 4), Gender = "F", Height = 152, Name = "Josh Bolt", Nation = "GB", Sport = "Archery", Weight = 78 };

            Mock<IAthleteRepository> mockAthleteRepo = new Mock<IAthleteRepository>();
            mockAthleteRepo.Setup(e => e.GetAllAthlete()).Returns(() => new List<Athlete>() { sportAthlete }.AsQueryable());

            var _athleteLogic = new AthleteLogic(mockAthleteRepo.Object);
            UpdateAthleteModel updatedAthlete = new UpdateAthleteModel() { Id = 1, DateOfBirth = new DateTime(1972, 2, 4), Gender = "F", Height = 152, Name = "Josh Bolt", Nation = "GB", Sport = "Archery", Weight = 78 };
            _athleteLogic.UpdateOneAthlete(1, updatedAthlete);

            mockAthleteRepo.Verify(func => func.UpdateOneAthlete(It.IsAny<Athlete>()), Times.Once);
        }

        [Theory]
        [ClassData(typeof(InvalidInsertAthleteTestData))]
        public void InsertNewAthleteWhenAthleteIsInvalid(BaseAthleteCUModel newAthlete)
        {
            Mock<IAthleteRepository> mockAthleteRepo = new Mock<IAthleteRepository>();

            var _athleteLogic = new AthleteLogic(mockAthleteRepo.Object);
            UpdateAthleteModel updatedAthlete = new UpdateAthleteModel() { Id = 1, DateOfBirth = new DateTime(1972, 2, 4), Gender = "F", Height = 152, Name = "Josh Bolt", Nation = "GB", Sport = "Archery", Weight = 78 };
            
            Assert.Throws<ArgumentException>(() => _athleteLogic.InsertNewAthlete(newAthlete));
            mockAthleteRepo.Verify(func => func.InsertNewAthlete(It.IsAny<Athlete>()), Times.Never);
        }

        [Fact]
        public void InsertNewAthleteWhenAthleteIsvalid()
        {
            Mock<IAthleteRepository> mockAthleteRepo = new Mock<IAthleteRepository>();
            var _athleteLogic = new AthleteLogic(mockAthleteRepo.Object);
            BaseAthleteCUModel updatedAthlete = new BaseAthleteCUModel() { DateOfBirth = new DateTime(1972, 2, 4), Gender = "F", Height = 152, Name = "Josh Bolt", Nation = "GB", Sport = "Archery", Weight = 78 };
            _athleteLogic.InsertNewAthlete(updatedAthlete);

            mockAthleteRepo.Verify(func => func.InsertNewAthlete(It.IsAny<Athlete>()), Times.Once);
        }
    }
}
