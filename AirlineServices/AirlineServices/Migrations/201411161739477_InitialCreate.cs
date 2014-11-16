namespace AirlineServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Flight",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        PlaneId = c.Int(),
                        SourceId = c.Int(),
                        DestinationId = c.Int(),
                        departureDate = c.DateTime(nullable: false),
                        ticketPrice = c.Double(nullable: false),
                        status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Location", t => t.DestinationId)
                .ForeignKey("dbo.Plane", t => t.PlaneId)
                .ForeignKey("dbo.Location", t => t.SourceId)
                .Index(t => t.PlaneId)
                .Index(t => t.SourceId)
                .Index(t => t.DestinationId);
            
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        airportCode = c.String(nullable: false),
                        city = c.String(nullable: false),
                        country = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Plane",
                c => new
                    {
                        tailNumber = c.Int(nullable: false),
                        firstClassCapacity = c.Int(nullable: false),
                        coachCapacity = c.Int(nullable: false),
                        economyCapacity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.tailNumber);
            
            CreateTable(
                "dbo.Ticket",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FlightId = c.Int(),
                        PassengerId = c.Int(),
                        status = c.Int(nullable: false),
                        type = c.Int(nullable: false),
                        AmountPaid = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Flight", t => t.FlightId)
                .ForeignKey("dbo.Passenger", t => t.PassengerId)
                .Index(t => t.FlightId)
                .Index(t => t.PassengerId);
            
            CreateTable(
                "dbo.Passenger",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        givenName = c.String(nullable: false, maxLength: 50),
                        familyName = c.String(nullable: false, maxLength: 50),
                        phoneNumber = c.String(nullable: false),
                        address = c.String(nullable: false),
                        country = c.String(nullable: false),
                        birthdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ticket", "PassengerId", "dbo.Passenger");
            DropForeignKey("dbo.Ticket", "FlightId", "dbo.Flight");
            DropForeignKey("dbo.Flight", "SourceId", "dbo.Location");
            DropForeignKey("dbo.Flight", "PlaneId", "dbo.Plane");
            DropForeignKey("dbo.Flight", "DestinationId", "dbo.Location");
            DropIndex("dbo.Ticket", new[] { "PassengerId" });
            DropIndex("dbo.Ticket", new[] { "FlightId" });
            DropIndex("dbo.Flight", new[] { "DestinationId" });
            DropIndex("dbo.Flight", new[] { "SourceId" });
            DropIndex("dbo.Flight", new[] { "PlaneId" });
            DropTable("dbo.Passenger");
            DropTable("dbo.Ticket");
            DropTable("dbo.Plane");
            DropTable("dbo.Location");
            DropTable("dbo.Flight");
        }
    }
}
