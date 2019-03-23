using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Common.Logging;
using Dissertation.Data;
using  Dissertation.Data.Context;

namespace Dissertation.Service.IntegrationService.Classes
{
    [Obsolete]
    public class Executor
    {
        readonly DB_SAPEntities _monitoringContext;
        readonly IDataAnalysisContext _dataAnalysisContext;

        private ILog _log = LogManager.GetLogger(typeof(Executor));

        public Executor(DB_SAPEntities monitoringContext, IDataAnalysisContext dataAnalysisContext)
        {
            _monitoringContext = monitoringContext;
            _dataAnalysisContext = dataAnalysisContext;
        }

        [Obsolete]
        public void AllWeatherDataCheker(DateTime time)
        {
            var start = time;
            var end = time.AddYears(1);
            _log.Trace(start);

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
        }
        [Obsolete]
        public void UpdatePosts()
        {
            //TODO: Think about posts and substances updates
            if (_dataAnalysisContext.Post.FirstOrDefault() != null)
            {
                return;
            }

            var posts = (from x in _monitoringContext.CP
                         select new Post
                         {
                             ID = x.CPid,
                             Name = x.Name,
                             ShortName = x.ShortName,
                             Longi = x.Longi,
                             Lati = x.Lati,
                             type = x.FPSid
                         });

            foreach (var a in posts)
            {
                if (!_dataAnalysisContext.Post.Exists(a.ID))
                {
                    _log.Trace($"Added new post {a.Name}");
                    _dataAnalysisContext.Post.Add(a);
                }
            }
        }

        [Obsolete]
        public void UpdateSubtances()
        {
            if (_dataAnalysisContext.Substance.FirstOrDefault() != null)
            {
                return;
            }
            var substances = (from x in _monitoringContext.ADDD
                              select new
                              {
                                  x.ADDid,
                                  x.Name,
                                  x.PDKCCAir,
                                  x.PDKMPAir
                              });

            foreach (var a in substances)
            {
                if (!_dataAnalysisContext.Substance.Exists(a.ADDid))
                {
                    _log.Trace($"Added new substance {a.Name}");
                    var entity = new Substance
                    {
                        ID = a.ADDid,
                        Name = a.Name,
                        PDK_MaxAllowable = a.PDKCCAir,
                        PDK_OneTime = a.PDKMPAir
                    };
                    _dataAnalysisContext.Substance.Add(entity);
                }
            }
        }
        [Obsolete]
        public void WritePrediction(string prediction)
        {
            throw new NotImplementedException();
        }
        [Obsolete]
        public void UpdateWeather()
        {
            var lastid = _dataAnalysisContext.Weather.DefaultIfEmpty().Max(x => x == null ? 0 : x.ID);
            var weather = (from ms in _monitoringContext.V_MS
                           join wx in _monitoringContext.V_WXT on ms.MSid equals wx.MSid
                           where ms.MSid > lastid
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
                           }).OrderBy(x => x.ID).Take(5000);
            if (weather != null && weather.Count() > 0)
            {
                _log.Trace($"Added weather data {weather.FirstOrDefault().time}");
                _dataAnalysisContext.Weather.AddRange(weather);
                _dataAnalysisContext.ChangeTracker.DetectChanges();
            }
        }
        [Obsolete]
        private IQueryable<T> GetValues<T, E>(int SubID) where T : class
        {
            //var prop = _monitoringContext.V_SENSIS_CL2.ElementType.GetProperty("")

            //var Entities = (from x in _monitoringContext.Set(typeof(E))

            //                select new Measurment
            //                {

            //                })

            throw new NotImplementedException();
        }
        [Obsolete]
        public void UpdateMeasurments()
        {
            //TODO: 
            //var dbsets = typeof(DB_SAPEntities).GetProperties().Where(p => p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>));
            //var dbset = typeof(DB_SAPEntities).GetProperty("V_SENSIS_CL2");
            int NumOfRows = 5_000;


            #region CL2 Entities / 37
            var max = _dataAnalysisContext.Measurment.Where(x => x.SubstanceID == 37).DefaultIfEmpty().Max(r => r == null ? 0 : r.SensisID);
            var CL2Entities = (from x in _monitoringContext.V_SENSIS_CL2
                               join z in _monitoringContext.V_MS on x.MSid equals z.MSid
                               where z.MSid > max
                               select new Measurment
                               {
                                   Value = x.P0037,
                                   SensisID = z.MSid,
                                   Time = z.MTime,
                                   TimeC = z.CTime,
                                   PostID = z.CPid,
                                   SubstanceID = 37
                               }).OrderBy(v => v.SensisID).Take(NumOfRows);
            AddMeasurments(CL2Entities);
            #endregion

            #region CO Entities / 25
            max = _dataAnalysisContext.Measurment.Where(x => x.SubstanceID == 25).DefaultIfEmpty().Max(r => r == null ? 0 : r.SensisID);
            var COEntities = (from x in _monitoringContext.V_SENSIS_CO
                              join z in _monitoringContext.V_MS on x.MSid equals z.MSid
                              where z.MSid > max
                              orderby z.MSid ascending
                              select new Measurment
                              {
                                  Value = x.P0025,
                                  SensisID = z.MSid,
                                  Time = z.MTime,
                                  TimeC = z.CTime,
                                  PostID = z.CPid,
                                  SubstanceID = 25
                              }).OrderBy(v => v.SensisID).Take(NumOfRows);
            AddMeasurments(COEntities);
            #endregion

            #region CxHy Entities / 39
            max = _dataAnalysisContext.Measurment.Where(x => x.SubstanceID == 39).DefaultIfEmpty().Max(r => r == null ? 0 : r.SensisID);
            var CXHYEntities = (from x in _monitoringContext.V_SENSIS_CXHY
                                join z in _monitoringContext.V_MS on x.MSid equals z.MSid
                                where z.MSid > max
                                orderby z.MSid ascending
                                select new Measurment
                                {
                                    Value = x.P0039,
                                    SensisID = z.MSid,
                                    Time = z.MTime,
                                    TimeC = z.CTime,
                                    PostID = z.CPid,
                                    SubstanceID = 39
                                }).OrderBy(v => v.SensisID).Take(NumOfRows);
            AddMeasurments(CXHYEntities);
            #endregion

            #region HCl / 27
            max = _dataAnalysisContext.Measurment.Where(x => x.SubstanceID == 27).DefaultIfEmpty().Max(r => r == null ? 0 : r.SensisID);
            var HCLEntities = (from x in _monitoringContext.V_SENSIS_HCL
                               join z in _monitoringContext.V_MS on x.MSid equals z.MSid
                               where z.MSid > max
                               orderby z.MSid ascending
                               select new Measurment
                               {
                                   Value = x.P0027,
                                   SensisID = z.MSid,
                                   Time = z.MTime,
                                   TimeC = z.CTime,
                                   PostID = z.CPid,
                                   SubstanceID = 27
                               }).OrderBy(v => v.SensisID).Take(NumOfRows);
            AddMeasurments(HCLEntities);


            #endregion

            #region HCOH / 30
            max = _dataAnalysisContext.Measurment.Where(x => x.SubstanceID == 30).DefaultIfEmpty().Max(r => r == null ? 0 : r.SensisID);
            var HCOHEntities = (from x in _monitoringContext.V_SENSIS_HCOH
                                join z in _monitoringContext.V_MS on x.MSid equals z.MSid
                                where z.MSid > max
                                orderby z.MSid ascending
                                select new Measurment
                                {
                                    Value = x.P0030,
                                    SensisID = z.MSid,
                                    Time = z.MTime,
                                    TimeC = z.CTime,
                                    PostID = z.CPid,
                                    SubstanceID = 30
                                }).OrderBy(v => v.SensisID).Take(NumOfRows);
            AddMeasurments(HCOHEntities);
            #endregion

            #region HF / 26
            max = _dataAnalysisContext.Measurment.Where(x => x.SubstanceID == 26).DefaultIfEmpty().Max(r => r == null ? 0 : r.SensisID);
            var HFEntities = (from x in _monitoringContext.V_SENSIS_HF
                join z in _monitoringContext.V_MS on x.MSid equals z.MSid
                where z.MSid > max
                orderby z.MSid ascending
                select new Measurment
                {
                    Value = x.P0026,
                    SensisID = z.MSid,
                    Time = z.MTime,
                    TimeC = z.CTime,
                    PostID = z.CPid,
                    SubstanceID = 26
                }).OrderBy(v => v.SensisID).Take(NumOfRows);
            AddMeasurments(HFEntities);
            #endregion

            #region NO2 / 21
            max = _dataAnalysisContext.Measurment.Where(x => x.SubstanceID == 21).DefaultIfEmpty().Max(r => r == null ? 0 : r.SensisID);
            var NO2Entities = (from x in _monitoringContext.V_SENSIS_NO2
                join z in _monitoringContext.V_MS on x.MSid equals z.MSid
                where z.MSid > max
                orderby z.MSid ascending
                select new Measurment
                {
                    Value = x.P0021,
                    SensisID = z.MSid,
                    Time = z.MTime,
                    TimeC = z.CTime,
                    PostID = z.CPid,
                    SubstanceID = 21
                }).OrderBy(v => v.SensisID).Take(NumOfRows);
            AddMeasurments(NO2Entities);
            #endregion

            #region SO2
            max = _dataAnalysisContext.Measurment.Where(x => x.SubstanceID == 23).DefaultIfEmpty().Max(r => r == null ? 0 : r.SensisID);
            var SO2Entities = (from x in _monitoringContext.V_SENSIS_SO2
                join z in _monitoringContext.V_MS on x.MSid equals z.MSid
                where z.MSid > max
                orderby z.MSid ascending
                select new Measurment
                {
                    Value = x.P0023,
                    SensisID = z.MSid,
                    Time = z.MTime,
                    TimeC = z.CTime,
                    PostID = z.CPid,
                    SubstanceID = 23
                }).OrderBy(v => v.SensisID).Take(NumOfRows);
            AddMeasurments(SO2Entities);
            #endregion
        }

        private void AddMeasurments(IQueryable<Measurment> Entities)
        {
            if (Entities != null && Entities.Count() > 0)
            {
                _log.Trace($"Added measurments ({Entities.First().SubstanceID}) entities - {Entities.Count()}");
                _dataAnalysisContext.Measurment.AddRange(Entities);
                _dataAnalysisContext.ChangeTracker.DetectChanges();
            }
        }
    }
}
