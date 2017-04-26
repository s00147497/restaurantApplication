namespace RestaurantApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingfieldsinrestaurantclass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "RestaurantType", c => c.Int(nullable: false));
            AddColumn("dbo.Restaurants", "NoticeRequired", c => c.DateTime(nullable: false));
            AddColumn("dbo.Restaurants", "FurtherDetails", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Restaurants", "FurtherDetails");
            DropColumn("dbo.Restaurants", "NoticeRequired");
            DropColumn("dbo.Restaurants", "RestaurantType");
        }
    }
}
