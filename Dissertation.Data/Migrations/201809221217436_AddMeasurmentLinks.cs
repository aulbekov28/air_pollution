namespace Dissertation.Service.IntegrationService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMeasurmentLinks : DbMigration
    {
        public override void Up()
        {
            AddColumn("Measurment", "NextValueID", c => c.Long());
            AddColumn("Measurment", "NearestWether", c => c.Long());
        }
        
        public override void Down()
        {
            DropColumn("Measurment", "NearestWether");
            DropColumn("Measurment", "NextValueID");
        }
    }
}
