namespace Dissertation.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wtf : DbMigration
    {
        public override void Up()
        {
            //DropColumn("Measurment", "MeasurmentID");
        }
        
        public override void Down()
        {
            //AddColumn("Measurment", "MeasurmentID", c => c.Long(nullable: false));
        }
    }
}
