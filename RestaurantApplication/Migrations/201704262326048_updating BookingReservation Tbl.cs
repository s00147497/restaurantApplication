namespace RestaurantApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatingBookingReservationTbl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RestaurantReservationEvents", "BookingNumberOfPeople", c => c.Int(nullable: false));
            AddColumn("dbo.RestaurantReservationEvents", "BookingStatus", c => c.String());
            AddColumn("dbo.RestaurantReservationEvents", "BookingEmailSent", c => c.String());
            AlterColumn("dbo.RestaurantReservationEvents", "BookingDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RestaurantReservationEvents", "BookingDate", c => c.String(nullable: false));
            DropColumn("dbo.RestaurantReservationEvents", "BookingEmailSent");
            DropColumn("dbo.RestaurantReservationEvents", "BookingStatus");
            DropColumn("dbo.RestaurantReservationEvents", "BookingNumberOfPeople");
        }
    }
}
