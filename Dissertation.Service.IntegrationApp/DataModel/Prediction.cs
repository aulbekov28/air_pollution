using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dissertation.Service.IntegrationApp.Context;

namespace Dissertation.Service.IntegrationApp.DataModel
{
    class Prediction : BaseEntity
    {
        public long  SubstanceID { get; set; }
        public long  PontID { get; set; }
        public long? MeasurementID { get; set; }
        public DateTime PredictionTime { get; set; }
        public int TimeSpan { get; set; }
        public double PredictedValue { get; set; }
        public double? RealValue { get; set; }
    }
}
