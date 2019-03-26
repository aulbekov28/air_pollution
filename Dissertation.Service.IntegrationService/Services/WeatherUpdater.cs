using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dissertation.Data;
using Dissertation.Data.Context;

namespace Dissertation.Service.IntegrationService.Services
{
    public class WeatherUpdater : BaseUpdater, IUpdater<Weather>
    {
        public WeatherUpdater(IDB_SAPEntities _monitoringContext, IDataAnalysisContext _analysisContext) : base(_monitoringContext, _analysisContext)
        {
        }

        public void Execute()
        {
            WriteData(GetData());
            _analysisContext.SaveChanges();
        }

        public IEnumerable<Weather> GetData()
        {
            var lastId = _analysisContext.Weather.DefaultIfEmpty().Max(x => x == null ? 0 : x.ID);

            var weather = (from ms in _monitoringContext.V_MS
                join wx in _monitoringContext.V_WXT on ms.MSid equals wx.MSid
                where ms.MSid > lastId
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
                }).OrderBy(x => x.ID).Take(5000).ToList();
            return weather;
        }

        public void WriteData(IEnumerable<Weather> weather)
        {
            if (weather != null && weather.Count() > 0)
            {
                _log.Trace($"Added weather data {weather.FirstOrDefault().time}");
                _analysisContext.Weather.AddRange(weather);
                _analysisContext.ChangeTracker.DetectChanges();
            }
        }
    }
}
