namespace Dissertation.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPredictions : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "Measurment",
            //    c => new
            //        {
            //            ID = c.Long(nullable: false, identity: true),
            //            MeasurmentID = c.Long(nullable: false),
            //            SensisID = c.Long(nullable: false),
            //            PostID = c.Long(),
            //            SubstanceID = c.Long(nullable: false),
            //            Time = c.DateTime(precision: 0),
            //            TimeC = c.DateTime(precision: 0),
            //            Value = c.Double(),
            //            NextValue = c.Double(),
            //            NextValueID = c.Long(),
            //            NearestWether = c.Long(),
            //        })
            //    .PrimaryKey(t => t.ID);
            
            //CreateTable(
            //    "Post",
            //    c => new
            //        {
            //            ID = c.Long(nullable: false),
            //            Name = c.String(unicode: false),
            //            ShortName = c.String(unicode: false),
            //            Longi = c.Double(),
            //            Lati = c.Double(),
            //            type = c.Int(),
            //        })
            //    .PrimaryKey(t => t.ID);
            
            CreateTable(
                "prediction",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        SubstanceID = c.Long(nullable: false),
                        PontID = c.Long(nullable: false),
                        MeasurementID = c.Long(),
                        PredictionTime = c.DateTime(nullable: false, precision: 0),
                        PreditionRange = c.Time(nullable: false, precision: 0),
                        PredictedValue = c.Double(nullable: false),
                        RealValue = c.Double(),
                    })
                .PrimaryKey(t => t.ID);
            
            //CreateTable(
            //    "Substance",
            //    c => new
            //        {
            //            ID = c.Long(nullable: false),
            //            Name = c.String(unicode: false),
            //            NameFull = c.String(unicode: false),
            //            PDK_MaxAllowable = c.Double(),
            //            PDK_OneTime = c.Double(),
            //        })
            //    .PrimaryKey(t => t.ID);
            
            //CreateTable(
            //    "Weather",
            //    c => new
            //        {
            //            ID = c.Long(nullable: false),
            //            MSid = c.Long(nullable: false),
            //            V_SENSIS_ID = c.Long(nullable: false),
            //            temperature = c.Double(),
            //            time = c.DateTime(precision: 0),
            //            wind_dir = c.Double(),
            //            wind_speed = c.Double(),
            //            humidity = c.Double(),
            //            pressure = c.Double(),
            //            precipitation = c.Double(),
            //            precipitation_intensity = c.Double(),
            //            PostID = c.Int(),
            //        })
            //    .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            //DropTable("Weather");
            //DropTable("Substance");
            DropTable("prediction");
            //DropTable("Post");
            //DropTable("Measurment");
        }
    }
}
