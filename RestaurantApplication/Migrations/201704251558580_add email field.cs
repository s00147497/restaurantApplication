namespace RestaurantApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addemailfield : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "RestaurantEmailAddress", c => c.String(nullable: false));
            DropColumn("dbo.Restaurants", "NoticeRequired");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Restaurants", "NoticeRequired", c => c.DateTime(nullable: false));
            DropColumn("dbo.Restaurants", "RestaurantEmailAddress");
        }
    }
}
