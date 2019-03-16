using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dissertation.Data.Context
{
    [Table("Weather")]
    public class Weather : BaseEntity
    {
        //[Key]
        //public long WeatherID { get; set; }
        public long MSid { get; set; }
        public long V_SENSIS_ID { get; set; }
        public double? temperature { get; set; }
        public DateTime? time { get; set; }
        public double? wind_dir { get; set; }
        public double? wind_speed { get; set; }
        public double? humidity { get; set; }
        public double? pressure { get; set; }
        public double? precipitation { get; set; }
        public double? precipitation_intensity { get; set; }
        public int? PostID { get; set; }
        //public virtual Post Post { get; set; }

    }
}
