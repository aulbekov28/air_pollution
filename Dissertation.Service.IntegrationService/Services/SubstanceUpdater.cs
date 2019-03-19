using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dissertation.Data;
using Dissertation.Data.Context;

namespace Dissertation.Service.IntegrationService.Services
{
    class SubstanceUpdater : BaseUpdater, IUpdater<Substance>
    {
        public SubstanceUpdater(DB_SAPEntities _monitoringContext, IDataAnalysisContext _analysisContext) : base(_monitoringContext, _analysisContext)
        {
        }

        public void Execute()
        {
            if (_analysisContext.Substance.FirstOrDefault() != null)
            {
                return;
            }
            WriteData(GetData());
        }

        public IEnumerable<Substance> GetData()
        {

            var substances = (from x in _monitoringContext.ADDD
                select new Substance
                {
                    ID = x.ADDid,
                    Name = x.Name,
                    PDK_MaxAllowable = x.PDKCCAir,
                    PDK_OneTime = x.PDKMPAir
                });
            return substances;
        }

        public void WriteData(IEnumerable<Substance> obtainedData)
        {
            foreach (var entity in obtainedData)
            {
                if (!_analysisContext.Substance.Exists(entity.ID))
                {
                    _log.Trace($"Added new substance {entity.Name}");
                    _analysisContext.Substance.Add(entity);
                }
            }
        }
    }
}
