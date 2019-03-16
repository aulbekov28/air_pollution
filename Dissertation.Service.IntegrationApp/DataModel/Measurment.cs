using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dissertation.Service.IntegrationApp.Context
{
    [Table("Measurment")]
    public class Measurment : BaseEntity
    {
        //public long MeasurmentID { get; set; }
        public long SensisID { get; set; }
        public int? PostID { get; set; }
        public int SubstanceID { get; set; }
        public DateTime? Time { get; set; }
        public DateTime? TimeC { get; set; }
        public double? Value { get; set; }
        public double? NextValue { get; set; }
        public long? NextValueID { get; set; }
        public long? NearestWether { get; set; }
    }
}
