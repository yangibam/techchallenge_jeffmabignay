using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using WH.RACEDAY.CORE.ENTITIES.CUSTOMER;
using WH.RACEDAY.DAL.INTERFACES;
using WH.RACEDAY.RULE.QUERYHANDLER.CUSTOMER;
using WH.RACEDAY.CORE.QUERIES.CUSTOMER;
using WH.RACEDAY.CORE.ENTITIES.RACE;

namespace WH.RACEDAY.TEST.CUSTOMER
{
    [TestFixture]
    public class GetCustomerDetailsQueryTest
    {
        [Test]
        public void Should_Return_CustomerList()
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
            var customerData = new List<Customer>
            {
                new Customer
                {
                    ID = 1,
                    Name = "Steve Roger"
                },
                new Customer
                {
                    ID = 2,
                    Name = "Tony Stark"
                },
                new Customer
                {
                    ID = 3,
                    Name = "Clint Barton"
                }
            };

            var raceRepository = new Mock<IRaceRepository>();
            var customerRepository = new Mock<ICustomerRepository>();

            raceRepository.Setup(r => r.GetRace()).Returns(raceData);
            raceRepository.Setup(r => r.GetBet()).Returns(betData);

            customerRepository.Setup(c => c.GetCustomer()).Returns(customerData);

            var handler = new GetCustomerDetailsQueryHandler(customerRepository.Object, raceRepository.Object);

            var result = handler.Handle(new GetCustomerDetailsQuery());

            Assert.IsNotNull(result);
        }

        [Test]
        public void Should_Return_Null_For_Empty_CustomerList()
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
            var betData = new List<Bet>();
            var customerData = new List<Customer>();

            var raceRepository = new Mock<IRaceRepository>();
            var customerRepository = new Mock<ICustomerRepository>();

            raceRepository.Setup(r => r.GetRace()).Returns(raceData);
            raceRepository.Setup(r => r.GetBet()).Returns(betData);

            customerRepository.Setup(c => c.GetCustomer()).Returns(customerData);

            var handler = new GetCustomerDetailsQueryHandler(customerRepository.Object, raceRepository.Object);

            var result = handler.Handle(new GetCustomerDetailsQuery());

            Assert.IsNull(result);
        }

        [Test]
        public void Should_Return_True_If_Customer_Is_AtRisk()
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
                    CustomerId = 1,
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
            var customerData = new List<Customer>
            {
                new Customer
                {
                    ID = 1,
                    Name = "Steve Roger"
                },
                new Customer
                {
                    ID = 2,
                    Name = "Tony Stark"
                },
                new Customer
                {
                    ID = 3,
                    Name = "Clint Barton"
                }
            };

            var raceRepository = new Mock<IRaceRepository>();
            var customerRepository = new Mock<ICustomerRepository>();

            raceRepository.Setup(r => r.GetRace()).Returns(raceData);
            raceRepository.Setup(r => r.GetBet()).Returns(betData);

            customerRepository.Setup(c => c.GetCustomer()).Returns(customerData);

            var handler = new GetCustomerDetailsQueryHandler(customerRepository.Object, raceRepository.Object);

            var result = handler.Handle(new GetCustomerDetailsQuery());

            var isAtRisk = result.Customers.Where(c => c.ID == 1).FirstOrDefault().isAtRisk;

            Assert.AreEqual(true, isAtRisk);
        }

        [Test]
        public void Should_Return_False_If_Customer_Is_Not_AtRisk()
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
                    CustomerId = 1,
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
            var customerData = new List<Customer>
            {
                new Customer
                {
                    ID = 1,
                    Name = "Steve Roger"
                },
                new Customer
                {
                    ID = 2,
                    Name = "Tony Stark"
                },
                new Customer
                {
                    ID = 3,
                    Name = "Clint Barton"
                }
            };

            var raceRepository = new Mock<IRaceRepository>();
            var customerRepository = new Mock<ICustomerRepository>();

            raceRepository.Setup(r => r.GetRace()).Returns(raceData);
            raceRepository.Setup(r => r.GetBet()).Returns(betData);

            customerRepository.Setup(c => c.GetCustomer()).Returns(customerData);

            var handler = new GetCustomerDetailsQueryHandler(customerRepository.Object, raceRepository.Object);

            var result = handler.Handle(new GetCustomerDetailsQuery());

            var isAtRisk = result.Customers.Where(c => c.ID == 2).FirstOrDefault().isAtRisk;

            Assert.AreEqual(false, isAtRisk);
        }

        [Test]
        public void Should_Return_Valid_Total_Bet()
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
                    CustomerId = 1,
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
            var customerData = new List<Customer>
            {
                new Customer
                {
                    ID = 1,
                    Name = "Steve Roger"
                },
                new Customer
                {
                    ID = 2,
                    Name = "Tony Stark"
                },
                new Customer
                {
                    ID = 3,
                    Name = "Clint Barton"
                }
            };

            var raceRepository = new Mock<IRaceRepository>();
            var customerRepository = new Mock<ICustomerRepository>();

            raceRepository.Setup(r => r.GetRace()).Returns(raceData);
            raceRepository.Setup(r => r.GetBet()).Returns(betData);

            customerRepository.Setup(c => c.GetCustomer()).Returns(customerData);

            var handler = new GetCustomerDetailsQueryHandler(customerRepository.Object, raceRepository.Object);

            var result = handler.Handle(new GetCustomerDetailsQuery());

            Assert.AreEqual(450, result.TotalBets);
        }

        [Test]
        public void Should_Return_Valid_Total_Bet_Per_Customer()
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
                    CustomerId = 1,
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
            var customerData = new List<Customer>
            {
                new Customer
                {
                    ID = 1,
                    Name = "Steve Roger"
                },
                new Customer
                {
                    ID = 2,
                    Name = "Tony Stark"
                },
                new Customer
                {
                    ID = 3,
                    Name = "Clint Barton"
                }
            };

            var raceRepository = new Mock<IRaceRepository>();
            var customerRepository = new Mock<ICustomerRepository>();

            raceRepository.Setup(r => r.GetRace()).Returns(raceData);
            raceRepository.Setup(r => r.GetBet()).Returns(betData);

            customerRepository.Setup(c => c.GetCustomer()).Returns(customerData);

            var handler = new GetCustomerDetailsQueryHandler(customerRepository.Object, raceRepository.Object);

            var result = handler.Handle(new GetCustomerDetailsQuery());

            var customerBet = result.Customers.Where(c => c.ID == 1).FirstOrDefault().Bet;

            Assert.AreEqual(250, customerBet);
        }
    }
}
