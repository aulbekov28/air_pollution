namespace Dissertation.Service.IntegrationApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMeasurmentLinks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Measurment", "NextValueID", c => c.Long());
            AddColumn("dbo.Measurment", "NearestWether", c => c.Long());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Measurment", "NearestWether");
            DropColumn("dbo.Measurment", "NextValueID");
        }
    }
}
