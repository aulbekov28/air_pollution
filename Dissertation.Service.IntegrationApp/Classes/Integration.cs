using NLog;
using System;
using Dissertation.Service.IntegrationApp.Context;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dissertation.Service.IntegrationApp.Classes
{
    class Integration
    {
        private bool Active = false;

        private System.Timers.Timer timer;

        private Object mainLock = new Object();

        private Logger Logger = LogManager.GetCurrentClassLogger();

        public void StartCycle()
        {
            Logger.Trace("Start cycle");
            Active = true;

#if DEBUG
            //FindNextValue(null, null);
            MainCycle(null, null);
#endif

            timer = new System.Timers.Timer
            {
                AutoReset = true,
                Interval = Config.Interval,
            };
            timer.Elapsed += new System.Timers.ElapsedEventHandler(FindNextValue);
            timer.Enabled = true;
        }

        public void StopCycle()
        {
            Active = false;
            timer.Enabled = false;
        }

        public string Name
        {
            get
            {
                return "Service.Integration";
            }
        }


        private void MainCycle(object sender, System.Timers.ElapsedEventArgs e)
        {
            lock(mainLock)
            {
                if (Active)
                {
                    Console.WriteLine("Entered to MainCycle");
                    using (var a = new DB_SAPEntities())
                    {
                        using (var b = new DataAnalysisContext())
                        {
                            Executor _do = new Executor(a, b);

                            var _dataSQL = a.ADDD.FirstOrDefault();

                            _do.UpdateSubtances();
                            _do.UpdatePosts();
                            _do.UpdateWeather();
                            _do.UpdateMeasurments();
                            b.SaveChanges();
                        }
                    }
                    Console.WriteLine("Exit from MainCycle");
                }
            }
        }

        private void WeatherMeasurmentMapper(object sender, System.Timers.ElapsedEventArgs e)
        {
            lock (mainLock)
            {
                if (Active)
                {
                    for (int i=0;i<100;i++)
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
