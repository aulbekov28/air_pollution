using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;
using Dissertation.Data;
using Dissertation.Data.Context;
using Dissertation.Notification;
using Dissertation.Notification.Services;
using Dissertation.Service.IntegrationService.Classes;
using Dissertation.Service.IntegrationService.Services;

namespace Dissertation.Service.IntegrationService
{
    public static class Factory
    {
        public static IDataAnalysisContext GetDataAnalysisContext=> new DataAnalysisContext();

        public static DB_SAPEntities GetDataMonitoringContext => new DB_SAPEntities();

        public static ILog GetLogger()
        {
            return GetLogger();
        }

        public static ILog GetLogger(Type type)
        {
            return LogManager.GetLogger(type);
        }

        public static IUpdater<Weather> GetWeatherUpdater()
        {
            return new WeatherUpdater(GetDataMonitoringContext,GetDataAnalysisContext);
        }

        public static IUpdater<Post> GetPostUpdater()
        {
            return new PostUpdater(GetDataMonitoringContext,GetDataAnalysisContext);
        }

        public static IUpdater<Substance> GetSubtanceUpdater()
        {
            return new SubstanceUpdater(GetDataMonitoringContext,GetDataAnalysisContext);
        }

        public static IUpdater<Measurment> GetMeasurmentUpdater()
        {
            return new MeasurementUpdater(GetDataMonitoringContext,GetDataAnalysisContext);
        }

        public static INotifier GetNotifier()
        {
            return new Notifier();
        }

        public static IIntegration GetIntegrationService()
        {
            return new Integration();
        }

        public static IPredictor GetPredictor()
        {
            return new Predictor();
        }

    }
}
