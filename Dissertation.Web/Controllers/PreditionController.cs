using Dissertation.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dissertation.Web.Controllers
{
    public class SummaryImpact
    {
        public string Susbtances { get; set; }
        public DateTime Time { get; set; }
        public TimeSpan Range { get; set; }
        public string Point { get; set; }
        public double ImpactCoeff { get; set; }

    }

    public class PredictionListViewModel
    {
        public IEnumerable<PredictionViewModel> Predictions { get; set; }
        public IEnumerable<SummaryImpact> SummaryImpacts { get; set; }
    }


    public class PreditionController : BaseController
    {
        // GET: Predition
        public ActionResult Index()
        {
            return View();
        }

        // GET: Predition
        public ActionResult List()
        {
            ViewBag.Title = "Prediction.APP";

            var ViewModel = new PredictionListViewModel();;

            var a = (from p in _dataContext.Predictions
                    join s in _dataContext.Substance on p.SubstanceID equals s.ID
                    join st in _dataContext.Post on p.PontID equals st.ID
                    orderby p.PredictionTime descending 
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
                        }).Take(100);

            var SubListOne = new[] { 21L, 25, 23 };
            var SubListOneName = "Диоксид азота, Диоксид серы, Формальдегид";
            
            var b = (from t in (from n in _dataContext.Predictions
                        join s in _dataContext.Substance on n.SubstanceID equals s.ID
                        join p in _dataContext.Post on n.PontID equals p.ID
                        where SubListOne.Contains(n.SubstanceID)
                        select new
                        {
                            SummaryImpact = n.PredictedValue / s.PDK_OneTime,
                            n.PredictionTime,
                            n.PreditionRange,
                            n.PontID,
                            SubName = s.Name,
                            s.NameFull,
                            PointName = p.Name
                        }
                    )
                group t by new {t.PontID, t.PredictionTime, t.PreditionRange, t.PointName}
                into g
                where g.Sum(s => s.SummaryImpact) > 1
                select new SummaryImpact
                {
                    Point = g.Key.PointName,
                    Time = g.Key.PredictionTime,
                    Range = g.Key.PreditionRange,
                    ImpactCoeff = g.Sum(s => s.SummaryImpact.Value),
                    Susbtances = SubListOneName
                });


                ViewModel.Predictions = a;
                ViewModel.SummaryImpacts = b;
                
                return View(ViewModel);
        }

        // GET: Predition/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Predition/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Predition/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Predition/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Predition/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Predition/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Predition/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
