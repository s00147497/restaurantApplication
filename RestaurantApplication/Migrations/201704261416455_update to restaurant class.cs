namespace RestaurantApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetorestaurantclass : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Restaurants", "RestaurantEmailAddress", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Restaurants", "RestaurantEmailAddress", c => c.String(nullable: false));
        }
    }
}
