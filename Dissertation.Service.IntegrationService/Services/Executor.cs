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
        private readonly IUpdater<Weather> _weatherUpdater;
        private readonly IUpdater<Measurment> _measureUpdater;
        private readonly IUpdater<Post> _postUpdater;
        private readonly IUpdater<Substance> _subUpdater;

        public delegate void UpdaterExecuted();
        public event UpdaterExecuted WorkExecuted;

        public Executor()
        {
            _postUpdater = Factory.GetPostUpdater();
            _subUpdater = Factory.GetSubtanceUpdater();
            _measureUpdater = Factory.GetMeasurmentUpdater();
            _weatherUpdater = Factory.GetWeatherUpdater();
        }

        public void Start()
        {
            _postUpdater.Execute();
            _subUpdater.Execute();
            _measureUpdater.Execute();
            _weatherUpdater.Execute();
            RiseEvent();
        }


        private void RiseEvent()
        {
            WorkExecuted?.Invoke();
        }

    }
}
