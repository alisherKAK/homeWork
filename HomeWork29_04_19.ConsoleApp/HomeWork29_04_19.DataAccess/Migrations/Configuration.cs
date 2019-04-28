namespace HomeWork29_04_19.DataAccess.Migrations
{
    using HomeWork29_04_19.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HomeWork29_04_19.DataAccess.TicketContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HomeWork29_04_19.DataAccess.TicketContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Cities.AddRange(new List<City>()
            {
                new City() { Name = "Astana"},
                new City() { Name = "Almaty"},
            });
            context.SaveChanges();
            context.Trains.AddRange(new List<Train>()
            {
                new Train(){Model = "Тальго"}
            });
            context.SaveChanges();
            context.RailwayCarriages.AddRange(new List<RailwayCarriage>()
            {
                new RailwayCarriage(){ Number = 1, Train = context.Trains.ToList()[0]}
            });
            context.SaveChanges();
            context.Staterooms.AddRange(new List<Stateroom>()
            {
                new Stateroom() { Number = 1, RailwayCarriage = context.RailwayCarriages.ToList()[0]},
                new Stateroom() { Number = 2, RailwayCarriage = context.RailwayCarriages.ToList()[0]},
                new Stateroom() { Number = 3, RailwayCarriage = context.RailwayCarriages.ToList()[0]},
                new Stateroom() { Number = 4, RailwayCarriage = context.RailwayCarriages.ToList()[0]},
            });
            context.SaveChanges();
            context.Spots.AddRange(new List<Spot>()
            {
                new Spot() { Number = 1, Stateroom = context.Staterooms.ToList()[0]},
                new Spot() { Number = 2, Stateroom = context.Staterooms.ToList()[0]},
                new Spot() { Number = 3, Stateroom = context.Staterooms.ToList()[0]},
                new Spot() { Number = 4, Stateroom = context.Staterooms.ToList()[0]},

                new Spot() { Number = 5, Stateroom = context.Staterooms.ToList()[1]},
                new Spot() { Number = 6, Stateroom = context.Staterooms.ToList()[1]},
                new Spot() { Number = 7, Stateroom = context.Staterooms.ToList()[1]},
                new Spot() { Number = 8, Stateroom = context.Staterooms.ToList()[1]},

                new Spot() { Number = 9, Stateroom = context.Staterooms.ToList()[2]},
                new Spot() { Number = 10, Stateroom = context.Staterooms.ToList()[2]},
                new Spot() { Number = 11, Stateroom = context.Staterooms.ToList()[2]},
                new Spot() { Number = 12, Stateroom = context.Staterooms.ToList()[2]},

                new Spot() { Number = 13, Stateroom = context.Staterooms.ToList()[3]},
                new Spot() { Number = 14, Stateroom = context.Staterooms.ToList()[3]},
                new Spot() { Number = 15, Stateroom = context.Staterooms.ToList()[3]},
                new Spot() { Number = 16, Stateroom = context.Staterooms.ToList()[3]},
            });
            context.SaveChanges();

            for (int i = 0; i < context.Trains.ToList().Count; i++)
            {
                var train = context.Trains.ToList()[i];
                for (int j = 0; j < train.RailwayCarriages.Count; j++)
                {
                    var railwayCarriage = train.RailwayCarriages.ToList()[j];
                    for (int a = 0; a < railwayCarriage.Staterooms.Count; a++)
                    {
                        var stateroom = railwayCarriage.Staterooms.ToList()[a];
                        for (int b = 0; b < stateroom.Spots.Count; b++)
                        {
                            context.TicketSeats.Add(new TicketSeat()
                            {
                                Train = train,
                                RailwayCarriage = railwayCarriage,
                                Stateroom = stateroom,
                                Spot = stateroom.Spots.ToList()[b]
                            });
                        }
                    }
                }
            }
            context.SaveChanges();

            for (int i = 0; i < context.TicketSeats.ToList().Count; i++)
            {
                var ticketSeat = context.TicketSeats.ToList()[i];
                context.Tickets.Add(new Ticket()
                {
                    LocatedCity = context.Cities.ToList()[0],
                    DepartureCity = context.Cities.ToList()[1],
                    Price = 2500,
                    TicketSeat = ticketSeat,
                    DispatchTime = Convert.ToDateTime("29.04.19 15:00:00"),
                    ArrivalTime = Convert.ToDateTime("30.04.19 6:00:00"),
                });
            }
            context.SaveChanges();
        }
    }
}
