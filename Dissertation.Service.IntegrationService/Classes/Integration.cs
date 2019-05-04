using Common.Logging;
using Dissertation.Data.Context;
using System;
using System.Linq;
using Dissertation.Notification.Services;

namespace Dissertation.Service.IntegrationService.Classes
{
    internal class Integration : IIntegration
    {
        private bool Active = false;

        private System.Timers.Timer timer;

        private readonly Object mainLock = new Object();

        private readonly ILog _log = Factory.GetLogger(typeof(Integration));

        public void StartCycle()
        {
            _log.Trace("Start cycle");

            //TODO separate class(?)
            var notifier = Factory.GetNotifier();
            notifier.Notify("Service started");
            Active = true;

#if DEBUG
            MainCycle(null, null);
#endif
            timer = new System.Timers.Timer
            {
                AutoReset = true,
                Interval = Config.Interval,
            };

            timer.Elapsed += MainCycle;
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
                if (!Active) return;

                _log.Trace("MainCycle run");

                var executor = new Services.Executor();
                executor.WorkExecuted += AfterWorker;
                executor.Start();

                var predictor = Factory.GetPredictor();
                predictor.Make();
            }
        }


        private void AfterWorker()
        {
            try
            {
                var analysis = Factory.GetDataAnalysisContext;
                analysis.Database.CommandTimeout = 300;
                analysis.Database.ExecuteSqlCommand(SqlCommands.MeasuementWeatherMapProcedure);
            }
            catch (Exception exception)
            {
                _log.Error(exception);
                throw;
            }
 
        }
     
    }
}
