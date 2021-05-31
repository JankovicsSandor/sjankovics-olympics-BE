using NUnit.Framework;

namespace sjankovics_olymipcs_Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            _athleteLogic=new Mock<IAthleteLogic>
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}