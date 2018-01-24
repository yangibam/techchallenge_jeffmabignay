using System;
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
    public class GetRaceDetailsQueryTest
    {
        [Test]
        public void Should_Return_RaceDetails()
        {
            var raceData = new List<Race>
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
            var betData = new List<Bet>
            {
                new Bet
                {
                    CustomerId = 1,
                    RaceId = 1,
                    HorseId = 1,
                    Stake = 100
                },
                new Bet
                {
                    CustomerId = 2,
                    RaceId = 1,
                    HorseId = 1,
                    Stake = 150
                },
                new Bet
                {
                    CustomerId = 3,
                    RaceId = 1,
                    HorseId = 2,
                    Stake = 200
                }
            };

            var raceRepository = new Mock<IRaceRepository>();

            raceRepository.Setup(r => r.GetRace()).Returns(raceData);
            raceRepository.Setup(r => r.GetBet()).Returns(betData);

            var handler = new GetRaceDetailsQueryHandler(raceRepository.Object);

            var result = handler.Handle(new GetRaceDetailsQuery() { ID = 1 });

            Assert.NotNull(result);
        }

        [Test]
        public void Should_Return_Null_For_Invalid_RaceID()
        {
            var raceData = new List<Race>
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
            var betData = new List<Bet>
            {
                new Bet
                {
                    CustomerId = 1,
                    RaceId = 1,
                    HorseId = 1,
                    Stake = 100
                },
                new Bet
                {
                    CustomerId = 2,
                    RaceId = 1,
                    HorseId = 1,
                    Stake = 150
                },
                new Bet
                {
                    CustomerId = 3,
                    RaceId = 1,
                    HorseId = 2,
                    Stake = 200
                }
            };

            var raceRepository = new Mock<IRaceRepository>();

            raceRepository.Setup(r => r.GetRace()).Returns(raceData);
            raceRepository.Setup(r => r.GetBet()).Returns(betData);

            var handler = new GetRaceDetailsQueryHandler(raceRepository.Object);

            var result = handler.Handle(new GetRaceDetailsQuery() { ID = 3 });

            Assert.IsNull(result);
        }

        [Test]
        public void Should_Return_Valid_Bet_Amount()
        {
            var raceData = new List<Race>
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
            var betData = new List<Bet>
            {
                new Bet
                {
                    CustomerId = 1,
                    RaceId = 1,
                    HorseId = 1,
                    Stake = 100
                },
                new Bet
                {
                    CustomerId = 2,
                    RaceId = 1,
                    HorseId = 1,
                    Stake = 150
                },
                new Bet
                {
                    CustomerId = 3,
                    RaceId = 1,
                    HorseId = 2,
                    Stake = 200
                }
            };

            var raceRepository = new Mock<IRaceRepository>();

            raceRepository.Setup(r => r.GetRace()).Returns(raceData);
            raceRepository.Setup(r => r.GetBet()).Returns(betData);

            var handler = new GetRaceDetailsQueryHandler(raceRepository.Object);

            var result = handler.Handle(new GetRaceDetailsQuery() { ID = 1 });

            Assert.AreEqual(450, result.TotalBets);
        }

        [Test]
        public void Should_Return_Valid_Payout()
        {
            var raceData = new List<Race>
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

            var betData = new List<Bet>
            {
                new Bet
                {
                    CustomerId = 1,
                    RaceId = 1,
                    HorseId = 1,
                    Stake = 100
                },
                new Bet
                {
                    CustomerId = 2,
                    RaceId = 1,
                    HorseId = 1,
                    Stake = 150
                },
                new Bet
                {
                    CustomerId = 3,
                    RaceId = 1,
                    HorseId = 2,
                    Stake = 200
                }
            };

            var raceRepository = new Mock<IRaceRepository>();

            raceRepository.Setup(r => r.GetRace()).Returns(raceData);
            raceRepository.Setup(r => r.GetBet()).Returns(betData);

            var handler = new GetRaceDetailsQueryHandler(raceRepository.Object);

            var result = handler.Handle(new GetRaceDetailsQuery() { ID = 1 });

            var payout =  result.Horses.Find(h => h.ID == 1).Payout;

            Assert.AreEqual(375, payout);
        }
    }
}
