using System.ServiceProcess;
using Common.Logging;
using Dissertation.Service.IntegrationService.Classes;

namespace Dissertation.Service.IntegrationService
{
    public partial class IntegrationService : ServiceBase
    {
        private IIntegration _service;
        private ILog _log = Factory.GetLogger();

        public IntegrationService()
        {
            _service = Factory.GetIntegrationService();
            InitializeComponent();
        }

        public void OnDebug()
        {
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
           _log.Trace("IntegrationService onStart");
            _service.StartCycle();
        }

        protected override void OnStop()
        {
            _log.Trace("IntegrationService onStop");
            _service.StopCycle();
        }
    }
}
