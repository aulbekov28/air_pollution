using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dissertation.Data.Context;

namespace Dissertation.Service.IntegrationService.Services
{
    public class Executor
    {
        private readonly IUpdater<Weather> weatherUpdater;
        private readonly IUpdater<Measurment> measureUpdater;
        private readonly IUpdater<Post> postUpdater;
        private readonly IUpdater<Substance> subUpdater;

        public delegate void UpdaterExecuted();
        public event UpdaterExecuted WorkExecuted;

        public Executor()
        {
            postUpdater = Factory.GetPostUpdater();
            subUpdater = Factory.GetSubtanceUpdater();
            measureUpdater = Factory.GetMeasurmentUpdater();
            weatherUpdater = Factory.GetWeatherUpdater();
        }

        public void Start()
        {
            postUpdater.Execute();
            subUpdater.Execute();
            measureUpdater.Execute();
            weatherUpdater.Execute();
            RiseEvent();
        }


        private void RiseEvent()
        {
            WorkExecuted.Invoke();
        }

    }
}
