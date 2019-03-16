using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dissertation.Data;
using Dissertation.Data.Context;

namespace Dissertation.Web.Controllers
{
    public class PredictionViewModel
    {
        public long ID { get; set; }
        public string Substance { get; set; }
        public long SubID { get; set; }
        public string Point { get; set; }
        public string PointShort { get; set; }
        public long PoinID { get; set; }
        public double Predicted { get; set; }
        public double Rate { get; set; }
        public double PDK { get; set; }
        public DateTime Time { get; set; }
        public TimeSpan Range { get; set; }

    }

    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Prediction.APP";
         
            var a = from p in (from n in _dataContext.Predictions
                group n by new { n.PontID, n.SubstanceID } into g
                select g.OrderByDescending(t => t.PredictionTime).FirstOrDefault())
                    join s in _dataContext.Substance on p.SubstanceID equals s.ID
                    join st in _dataContext.Post on p.PontID equals st.ID
                    select
                        new PredictionViewModel
                        {
                            ID = p.ID,
                            SubID = p.SubstanceID,
                            PoinID = p.PontID,
                            PointShort = st.ShortName,
                            Substance = s.Name,
                            Point = st.Name,
                            PDK = s.PDK_OneTime.Value,
                            Predicted = p.PredictedValue,
                            Time = p.PredictionTime,
                            Range = p.PreditionRange,
                            Rate = p.PredictedValue / s.PDK_OneTime.Value
                        }
                ;

            return View(a);
        }
    }

    public class PredictionComaper : IEqualityComparer<PredictionViewModel>
    {
        public bool Equals(PredictionViewModel x, PredictionViewModel y)
        {
            return x.Substance == y.Substance && x.Point == y.Point;
        }

        public int GetHashCode(PredictionViewModel obj)
        {
            return obj.ID.GetHashCode();
        }
    }
}
