namespace RestaurantApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatingRestaurantClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "Rating", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Restaurants", "Rating");
        }
    }
}
