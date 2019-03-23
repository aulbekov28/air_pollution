using Dissertation.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dissertation.Service.IntegrationService.Classes
{
    public static class Helper
    {
        public static void CheckWeatherData(DateTime time)
        {
            var _monitoringContext = Factory.GetDataMonitoringContext;
            var _dataAnalysisContext = Factory.GetDataAnalysisContext;
            var start = time;
            var end = time.AddYears(1);
 
            var weather = (from ms in _monitoringContext.V_MS
                join wx in _monitoringContext.V_WXT on ms.MSid equals wx.MSid
                where ms.MTime >= time && ms.MTime <= end
                select new Weather
                {
                    ID = ms.MSid,
                    time = ms.MTime,
                    PostID = ms.CPid,
                    temperature = wx.P0202,
                    wind_dir = wx.P0174,
                    wind_speed = wx.P0173,
                    humidity = wx.P0204,
                    pressure = wx.P0205,
                    precipitation = wx.P0175,
                    precipitation_intensity = wx.P0176
                });
            foreach (var a in weather)
            {
                if (!_dataAnalysisContext.Weather.Exists(a.ID))
                {
                    _dataAnalysisContext.Weather.Add(a);
                }
            }

            _dataAnalysisContext.SaveChanges();
        }

        public static void MapWeatherMeasurementData()
        {
            var _dataAnalysisContext = Factory.GetDataAnalysisContext;
            _dataAnalysisContext.Database.CommandTimeout = 700;
            _dataAnalysisContext.Database.ExecuteSqlCommand("call map_measurment_weather()");
        }

        public static void FindNextValues()
        {
            var _dataAnalysisContext = Factory.GetDataAnalysisContext;
            _dataAnalysisContext.Database.CommandTimeout = 700;
            _dataAnalysisContext.Database.ExecuteSqlCommand("call find_nextvalue()");
        }
    }
}
