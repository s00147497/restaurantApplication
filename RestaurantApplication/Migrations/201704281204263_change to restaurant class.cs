namespace RestaurantApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changetorestaurantclass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "RestaurantTown", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Restaurants", "RestaurantAddress", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Restaurants", "County", c => c.String(nullable: false, maxLength: 200));
            DropColumn("dbo.Restaurants", "Lat");
            DropColumn("dbo.Restaurants", "Long");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Restaurants", "Long", c => c.Double(nullable: false));
            AddColumn("dbo.Restaurants", "Lat", c => c.Double(nullable: false));
            AlterColumn("dbo.Restaurants", "County", c => c.String(maxLength: 200));
            AlterColumn("dbo.Restaurants", "RestaurantAddress", c => c.String(maxLength: 200));
            DropColumn("dbo.Restaurants", "RestaurantTown");
        }
    }
}
