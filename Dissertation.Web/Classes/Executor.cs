using Dissertation.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dissertation.Data;

namespace Dissertation.Web.Classes
{
    public class Executor
    {
        readonly DB_SAPEntities Moniroting;
        readonly IDataAnalysisContext Analysis;
        //private ILog _log = LogManager.GetLogger(typeof(Executor));

        public Executor(DB_SAPEntities _Monitoring, IDataAnalysisContext _Analysis)
        {
            Moniroting = _Monitoring;
            Analysis = _Analysis;
        }

        public void WritePredictions(IEnumerable<Prediction> predicitons)
        {
            if (predicitons != null && predicitons.Count() > 0)
            {
                //_log.Trace($"Added measurments ({Entities.First().SubstanceID}) entities - {Entities.Count()}");
                Analysis.Predictions.AddRange(predicitons);
                Analysis.ChangeTracker.DetectChanges();
            }
        }

    }
}