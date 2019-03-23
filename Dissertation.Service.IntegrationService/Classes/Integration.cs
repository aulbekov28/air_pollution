using Common.Logging;
using Dissertation.Data.Context;
using System;
using System.Linq;
using Dissertation.Notification.Services;

namespace Dissertation.Service.IntegrationService.Classes
{
    class Integration : IIntegration
    {
        private bool Active = false;

        private System.Timers.Timer timer;

        private Object mainLock = new Object();

        private ILog _log = Factory.GetLogger();

        public void StartCycle()
        {
            _log.Trace("Start cycle");
            INotifier _notifier = Factory.GetNotifier();
            _notifier.Notify("Service started");
            Active = true;

#if DEBUG
            MainCycle(null, null);
#endif
            timer = new System.Timers.Timer
            {
                AutoReset = true,
                Interval = Config.Interval,
            };

            timer.Elapsed += new System.Timers.ElapsedEventHandler(MainCycle);
            timer.Enabled = true;
        }

        public void StopCycle()
        {
            Active = false;
            timer.Enabled = false;
            _log.Trace("Stop cycle");
        }


        public void MainCycle(object sender, System.Timers.ElapsedEventArgs e)
        {
            lock(mainLock)
            {
                if (Active)
                {
                    _log.Trace("MainCycle run");

                    Services.Executor executor = new Services.Executor();
                    executor.WorkExecuted += AfterWorker;
                    executor.Start();
                    
                    var predcitor = Factory.GetPredictor();
                    predcitor.Make();
                }
            }
        }


        private void AfterWorker()
        {
            try
            {
                var _analysis = Factory.GetDataAnalysisContext;
                _analysis.Database.ExecuteSqlCommand("call map_measurment_weather()");
            }
            catch (Exception exception)
            {
                _log.Error(exception);
                throw;
            }
 
        }
     
    }
}
