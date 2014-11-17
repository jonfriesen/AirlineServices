namespace AirlineServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PassengerLastMod_and_Create_dates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Passenger", "LastModified", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Passenger", "LastModified");
        }
    }
}
