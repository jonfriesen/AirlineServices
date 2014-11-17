namespace AirlineServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class passenger_createdate_field : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Passenger", "CreateDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Passenger", "CreateDate");
        }
    }
}
