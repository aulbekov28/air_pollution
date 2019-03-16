using System.ServiceProcess;
using Common.Logging;
using Dissertation.Service.IntegrationService.Classes;

namespace Dissertation.Service.IntegrationService
{
    public partial class IntegrationService : ServiceBase
    {
        private Integration _service;
        private ILog _log = LogManager.GetLogger(typeof(IntegrationService));

        public IntegrationService()
        {
            _service = new Integration();
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
