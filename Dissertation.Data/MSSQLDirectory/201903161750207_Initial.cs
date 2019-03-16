namespace Dissertation.Data.MSSQLDirectory
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Measurment",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        SensisID = c.Long(nullable: false),
                        PostID = c.Long(),
                        SubstanceID = c.Long(nullable: false),
                        Time = c.DateTime(),
                        TimeC = c.DateTime(),
                        Value = c.Double(),
                        NextValue = c.Double(),
                        NextValueID = c.Long(),
                        NearestWether = c.Long(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        ID = c.Long(nullable: false),
                        Name = c.String(),
                        ShortName = c.String(),
                        Longi = c.Double(),
                        Lati = c.Double(),
                        type = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.prediction",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        SubstanceID = c.Long(nullable: false),
                        PontID = c.Long(nullable: false),
                        MeasurementID = c.Long(),
                        PredictionTime = c.DateTime(nullable: false),
                        PreditionRange = c.Time(nullable: false, precision: 7),
                        PredictedValue = c.Double(nullable: false),
                        RealValue = c.Double(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Substance",
                c => new
                    {
                        ID = c.Long(nullable: false),
                        Name = c.String(),
                        NameFull = c.String(),
                        PDK_MaxAllowable = c.Double(),
                        PDK_OneTime = c.Double(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Weather",
                c => new
                    {
                        ID = c.Long(nullable: false),
                        MSid = c.Long(nullable: false),
                        V_SENSIS_ID = c.Long(nullable: false),
                        temperature = c.Double(),
                        time = c.DateTime(),
                        wind_dir = c.Double(),
                        wind_speed = c.Double(),
                        humidity = c.Double(),
                        pressure = c.Double(),
                        precipitation = c.Double(),
                        precipitation_intensity = c.Double(),
                        PostID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Weather");
            DropTable("dbo.Substance");
            DropTable("dbo.prediction");
            DropTable("dbo.Post");
            DropTable("dbo.Measurment");
        }
    }
}
