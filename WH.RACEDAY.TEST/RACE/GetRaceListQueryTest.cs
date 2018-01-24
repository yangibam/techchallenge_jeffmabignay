using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using WH.RACEDAY.CORE.ENTITIES.RACE;
using WH.RACEDAY.DAL.INTERFACES;
using WH.RACEDAY.RULE.QUERYHANDLER.RACE;
using WH.RACEDAY.CORE.QUERIES.RACE;

namespace WH.RACEDAY.TEST.RACE
{
    [TestFixture]
    public class GetRaceListQueryTest
    {
        [Test]
        public void Should_Return_List_Of_Races()
        {
            var data = new List<Race>
            {
                new Race{
                    ID = 1,
                    Name = "Race 1",
                    Start = "2018-01-24T02:00:00+00:00",
                    Status = "completed",
                    Horses = new List<Horse>
                    {
                        new Horse
                        {
                            ID = 1,
                            Name = "michaelangelo",
                            Odds = 1.5
                        },
                        new Horse
                        {
                            ID = 2,
                            Name = "donatello",
                            Odds = 2
                        }
                    }
                },
                new Race
                {
                    ID = 1,
                    Name = "Race 2",
                    Start = "2018-01-24T02:00:00+00:00",
                    Status = "pending",
                    Horses = new List<Horse>
                    {
                        new Horse
                        {
                            ID = 3,
                            Name = "leonardo",
                            Odds = 1.5
                        },
                        new Horse
                        {
                            ID = 4,
                            Name = "raphael",
                            Odds = 2
                        }
                    }
                }
            };

            var raceRepository = new Mock<IRaceRepository>();

            raceRepository.Setup(r => r.GetRace()).Returns(data);

            var handler = new GetRaceListQueryHandler(raceRepository.Object);

            var result = handler.Handle(new GetRaceListQuery());

            Assert.AreEqual(result.Count, 2);
        }

        [Test]
        public void Should_Return_Empty()
        {
            var data = new List<Race>();

            var raceRepository = new Mock<IRaceRepository>();

            raceRepository.Setup(r => r.GetRace()).Returns(data);

            var handler = new GetRaceListQueryHandler(raceRepository.Object);

            var result = handler.Handle(new GetRaceListQuery());

            Assert.AreEqual(result.Count, 0);
        }
    }
}
