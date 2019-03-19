using Common.Logging;
using Dissertation.Data.Context;
using System;
using System.Linq;

namespace Dissertation.Service.IntegrationService.Classes
{
    class Integration
    {
        private bool Active = false;

        private System.Timers.Timer timer;

        private Object mainLock = new Object();

        private ILog _log = LogManager.GetLogger(typeof(Integration));

        public void StartCycle()
        {
            _log.Trace("Start cycle");
            Dissertation.Notification.Notification _notification = new Notification.Notification();
            _notification.SendTelegramChannel("Service started");
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

       
        private void MainCycle(object sender, System.Timers.ElapsedEventArgs e)
        {
            lock(mainLock)
            {
                if (Active)
                {
                    _log.Trace("MainCycle run");
                    using (var a = new DB_SAPEntities())
                    {
                        using (var b = new DataAnalysisContext())
                        {

                            Executor _do = new Executor(a, b);
                            RunTryCatch(_do.UpdateSubtances);
                            RunTryCatch(_do.UpdatePosts);
                            RunTryCatch(_do.UpdateWeather);
                            RunTryCatch(_do.UpdateMeasurments);

                            try
                            {
                                b.SaveChanges();
                                b.Database.ExecuteSqlCommand("call map_measurment_weather()");
                            }
                            catch (Exception exception)
                            {
                                _log.Error(exception);
                                throw;
                            }
                        }
                    }
                    var prediction = RunTryCatch(Prediction.ExecturePythonScript);
                }
            }
        }


        //WTF is that
        private void RunTryCatch(object v)
        {
            throw new NotImplementedException();
        }

        private void RunTryCatch(Action<string> methodAction, string data)
        {
            try
            {
                methodAction.Invoke(data);
            }
            catch (Exception e)
            {
                _log.Error(e);
                throw;
            }
        }

        private T RunTryCatch<T>(Func<T> methodAction)
        {
            try
            {
                return methodAction.Invoke();
            }
            catch (Exception e)
            {
                _log.Error(e);
            }
            return default(T);
        }

        private void RunTryCatch(Action methodAction)
        {
            try
            {
                methodAction.Invoke();
            }
            catch (Exception e)
            {
                _log.Error(e);
                throw;
            }
        }


        private void WeatherMeasurmentMapper(object sender, System.Timers.ElapsedEventArgs e)
        {
            lock (mainLock)
            {
                if (Active)
                {
                    for (int i = 0; i < 100; i++)
                    {
                        Console.WriteLine($"Entered to {System.Reflection.MethodBase.GetCurrentMethod().Name}");
                        using (var b = new DataAnalysisContext())
                        {
                            b.Database.CommandTimeout = 650;
                            b.Database.ExecuteSqlCommand("call map_measurment_weather()");
                        }
                        Console.WriteLine("Exit");
                    }
                }
            }
        }

        private void FindNextValue(object sender, System.Timers.ElapsedEventArgs e)
        {
            lock (mainLock)
            {
                if (Active)
                {
                    for (int i = 0; i < 100; i++)
                    {
                        Console.WriteLine($"Entered to {System.Reflection.MethodBase.GetCurrentMethod().Name}");
                        using (var b = new DataAnalysisContext())
                        {
                            b.Database.CommandTimeout = 650;
                            b.Database.ExecuteSqlCommand("call find_nextvalue()");
                        }
                        Console.WriteLine("Exit");
                    }
                }
            }
        }

        private void DataUpdater(object sender, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine("Entered to MainCycle");
            DateTime time = new DateTime(2018,1,1);
            using (var a = new DB_SAPEntities())
            {
                using (var b = new DataAnalysisContext())
                {
                    Executor _do = new Executor(a, b);
                    _do.AllWeatherDataCheker(time);
                    b.SaveChanges();
                }
            }
            Console.WriteLine("Exit from MainCycle");
        }
        
    }
}
