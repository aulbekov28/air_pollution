using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;
using Dissertation.Data;
using Dissertation.Data.Context;

namespace Dissertation.Service.IntegrationService.Services
{
    internal abstract class BaseUpdater
    {
        protected IDataAnalysisContext _analysisContext;
        protected DB_SAPEntities _monitoringContext;
        protected ILog _log = LogManager.GetLogger(typeof(BaseUpdater));

        public BaseUpdater(DB_SAPEntities _monitoringContext, IDataAnalysisContext _analysisContext)
        {
            this._analysisContext = _analysisContext;
            this._monitoringContext = _monitoringContext;
        }
    }
}
