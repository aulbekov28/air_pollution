using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dissertation.Data.Context
{
    [Table("prediction")]
    public class Prediction : BaseEntity
    {
        //[ForeignKey("Substance")]
        public long SubstanceID { get; set; }
        //public virtual Substance Substance { get; set; }
        //[ForeignKey("Post")]
        public long PontID { get; set; }
        //public virtual Post Post { get; set; }
        //[ForeignKey("Measurement")]
        public long? MeasurementID { get; set; }
        //public virtual Measurment Measurement { get; set; }
        public DateTime PredictionTime { get; set; }
        public TimeSpan PreditionRange { get; set; }
        public double PredictedValue { get; set; }
        public double? RealValue { get; set; }

        public override string ToString()
        {
            return $"{hack[PontID]} - {hack[SubstanceID]} - {PredictionTime.Add(PreditionRange).ToString("dd.MM.yyyy HH:mm")} - {PredictedValue.ToString("F4")}";
        }

        private Dictionary<long,string> hack = new Dictionary<long, string>()  {
                {21,"NO2"},
                {23, "SO2"},
                {25,"CO"},
                {26, "HF"},
                {27, "HCL"},
                {30, "HCOH"},
                {37, "CL2"},
                {39, "CXHY"},
                {1001, "ул. Гастелло, 14"},
                {1002, "Защита, ул. Делегатская"},
                {1003, "Ул. Казахстан, 154Б"},
                {1004, "Пр. Ауэзова, 5"},
                {1005, "Мирный, ул. Пограничная, 59"},
                {1006, " ул. Куйбышева 57а"},
                {1007, "Ул. Путевая, 2"},
                {1008, "ул. Менделеева, 13А"},
                {1009, "Пр. Абая, 102"}
            };
            

    }
}
