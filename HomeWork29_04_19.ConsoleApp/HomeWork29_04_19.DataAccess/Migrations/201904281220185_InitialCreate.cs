namespace HomeWork29_04_19.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Surname = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PurchasedTickets",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Ticket_Id = c.Guid(),
                        User_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tickets", t => t.Ticket_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Ticket_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Price = c.Double(nullable: false),
                        DispatchTime = c.DateTime(nullable: false),
                        ArrivalTime = c.DateTime(nullable: false),
                        IsBuyed = c.Boolean(nullable: false),
                        DepartureCity_Id = c.Guid(),
                        LocatedCity_Id = c.Guid(),
                        TicketSeat_Id = c.Guid(),
                        User_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.DepartureCity_Id)
                .ForeignKey("dbo.Cities", t => t.LocatedCity_Id)
                .ForeignKey("dbo.TicketSeats", t => t.TicketSeat_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.DepartureCity_Id)
                .Index(t => t.LocatedCity_Id)
                .Index(t => t.TicketSeat_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.TicketSeats",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RailwayCarriage_Id = c.Guid(),
                        Spot_Id = c.Guid(),
                        Stateroom_Id = c.Guid(),
                        Train_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RailwayCarriages", t => t.RailwayCarriage_Id)
                .ForeignKey("dbo.Spots", t => t.Spot_Id)
                .ForeignKey("dbo.Staterooms", t => t.Stateroom_Id)
                .ForeignKey("dbo.Trains", t => t.Train_Id)
                .Index(t => t.RailwayCarriage_Id)
                .Index(t => t.Spot_Id)
                .Index(t => t.Stateroom_Id)
                .Index(t => t.Train_Id);
            
            CreateTable(
                "dbo.RailwayCarriages",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Number = c.Int(nullable: false),
                        Train_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Trains", t => t.Train_Id)
                .Index(t => t.Train_Id);
            
            CreateTable(
                "dbo.Staterooms",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Number = c.Int(nullable: false),
                        RailwayCarriage_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RailwayCarriages", t => t.RailwayCarriage_Id)
                .Index(t => t.RailwayCarriage_Id);
            
            CreateTable(
                "dbo.Spots",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Number = c.Int(nullable: false),
                        Stateroom_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Staterooms", t => t.Stateroom_Id)
                .Index(t => t.Stateroom_Id);
            
            CreateTable(
                "dbo.Trains",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Model = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Login = c.String(),
                        Password = c.String(),
                        Person_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Person_Id)
                .Index(t => t.Person_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchasedTickets", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Tickets", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "Person_Id", "dbo.People");
            DropForeignKey("dbo.PurchasedTickets", "Ticket_Id", "dbo.Tickets");
            DropForeignKey("dbo.Tickets", "TicketSeat_Id", "dbo.TicketSeats");
            DropForeignKey("dbo.TicketSeats", "Train_Id", "dbo.Trains");
            DropForeignKey("dbo.TicketSeats", "Stateroom_Id", "dbo.Staterooms");
            DropForeignKey("dbo.TicketSeats", "Spot_Id", "dbo.Spots");
            DropForeignKey("dbo.TicketSeats", "RailwayCarriage_Id", "dbo.RailwayCarriages");
            DropForeignKey("dbo.RailwayCarriages", "Train_Id", "dbo.Trains");
            DropForeignKey("dbo.Spots", "Stateroom_Id", "dbo.Staterooms");
            DropForeignKey("dbo.Staterooms", "RailwayCarriage_Id", "dbo.RailwayCarriages");
            DropForeignKey("dbo.Tickets", "LocatedCity_Id", "dbo.Cities");
            DropForeignKey("dbo.Tickets", "DepartureCity_Id", "dbo.Cities");
            DropIndex("dbo.Users", new[] { "Person_Id" });
            DropIndex("dbo.Spots", new[] { "Stateroom_Id" });
            DropIndex("dbo.Staterooms", new[] { "RailwayCarriage_Id" });
            DropIndex("dbo.RailwayCarriages", new[] { "Train_Id" });
            DropIndex("dbo.TicketSeats", new[] { "Train_Id" });
            DropIndex("dbo.TicketSeats", new[] { "Stateroom_Id" });
            DropIndex("dbo.TicketSeats", new[] { "Spot_Id" });
            DropIndex("dbo.TicketSeats", new[] { "RailwayCarriage_Id" });
            DropIndex("dbo.Tickets", new[] { "User_Id" });
            DropIndex("dbo.Tickets", new[] { "TicketSeat_Id" });
            DropIndex("dbo.Tickets", new[] { "LocatedCity_Id" });
            DropIndex("dbo.Tickets", new[] { "DepartureCity_Id" });
            DropIndex("dbo.PurchasedTickets", new[] { "User_Id" });
            DropIndex("dbo.PurchasedTickets", new[] { "Ticket_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Trains");
            DropTable("dbo.Spots");
            DropTable("dbo.Staterooms");
            DropTable("dbo.RailwayCarriages");
            DropTable("dbo.TicketSeats");
            DropTable("dbo.Tickets");
            DropTable("dbo.PurchasedTickets");
            DropTable("dbo.People");
            DropTable("dbo.Cities");
        }
    }
}
