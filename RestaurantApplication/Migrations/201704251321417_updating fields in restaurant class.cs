namespace RestaurantApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatingfieldsinrestaurantclass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "County", c => c.String(maxLength: 200));
            AddColumn("dbo.Restaurants", "Lat", c => c.Double(nullable: false));
            AddColumn("dbo.Restaurants", "Long", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Restaurants", "Long");
            DropColumn("dbo.Restaurants", "Lat");
            DropColumn("dbo.Restaurants", "County");
        }
    }
}
