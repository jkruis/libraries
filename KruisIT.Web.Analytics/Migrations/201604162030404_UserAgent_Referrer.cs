namespace KruisIT.Web.Analytics.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserAgent_Referrer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Analytics_Visits", "UserAgent", c => c.String());
            AddColumn("dbo.Analytics_Visits", "Referrer", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Analytics_Visits", "Referrer");
            DropColumn("dbo.Analytics_Visits", "UserAgent");
        }
    }
}
