using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dissertation.Data.Context
{
    [Table("Measurment")]
    public class Measurment : BaseEntity
    {
        //public long MeasurmentID { get; set; }
        public long SensisID { get; set; }
        //[ForeignKey("Post")]
        public long? PostID { get; set; }
        //public virtual Post Post { get; set; }
        //[ForeignKey("Substance")]
        public long SubstanceID { get; set; }
        //public virtual Substance Substance { get; set; }
        public DateTime? Time { get; set; }
        public DateTime? TimeC { get; set; }
        public double? Value { get; set; }
        public double? NextValue { get; set; }
        //=[ForeignKey("NextMeasurment")]
        public long? NextValueID { get; set; }
        //public virtual Measurment NextMeasurment { get; set; }
        //[ForeignKey("Weather")]
        public long? NearestWether { get; set; }
        //public virtual Weather Weather { get; set; }
    }
}
