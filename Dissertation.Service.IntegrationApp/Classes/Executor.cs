using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Dissertation.Service.IntegrationApp.Context;
using System.Text;
using System.Threading.Tasks;

namespace Dissertation.Service.IntegrationApp.Classes
{
    public class Executor
    {
        private DB_SAPEntities Moniroting;
        private DataAnalysisContext Analysis;


        public Executor(DB_SAPEntities _Monitoring, DataAnalysisContext _Analysis)
        {
            Moniroting = _Monitoring;
            Analysis = _Analysis;
        }

        public void AllWeatherDataCheker(DateTime time)
        {
            var start = time;
            var end = time.AddYears(1);
            Console.WriteLine(start);
            
            var weather = (from ms in Moniroting.V_MS
                           join wx in Moniroting.V_WXT on ms.MSid equals wx.MSid
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
            //var b = Analysis.Weather.Exists(43684);
            Console.WriteLine(weather.Count());
            foreach (var a in weather)
            {
                if (!Analysis.Weather.Exists(a.ID))
                {
                    Analysis.Weather.Add(a);
                }
            }
        }


        public void UpdatePosts()
        {
            //TODO: Think about posts and substances updates
            if (Analysis.Post.FirstOrDefault() != null)
            {
                return;
            }

            var posts = (from x in Moniroting.CP
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
                if (!Analysis.Post.Exists(a.ID))
                {
                    Console.WriteLine($"Added new post {a.Name}");
                    Analysis.Post.Add(a);
                }
            }
        }
        

        public void UpdateSubtances()
        {
            if (Analysis.Substance.FirstOrDefault() != null)
            {
                return;
            }
            var substances = (from x in Moniroting.ADDD
                              select new 
                              {
                                  x.ADDid,
                                  x.Name,
                                  x.PDKCCAir,
                                  x.PDKMPAir
                              });

            foreach(var a in substances)
            {
                //var model = Analysis.Substance.GetOrCreate(a.ADDid);
                //var entity = model.Item2;
                //entity.ID = a.ADDid;
                //entity.Name = a.Name;
                //entity.PDK_MaxAllowable = a.PDKCCAir;
                //entity.PDK_OneTime = a.PDKMPAir;

                if (!Analysis.Substance.Exists(a.ADDid))
                {
                    Console.WriteLine($"Added new substance {a.Name}");
                    var entity = new Substance();
                    entity.ID = a.ADDid;
                    entity.Name = a.Name;
                    entity.PDK_MaxAllowable = a.PDKCCAir;
                    entity.PDK_OneTime = a.PDKMPAir;
                    Analysis.Substance.Add(entity);
                }
            }
        }

        public void UpdateWeather()
        {
            var lastid = Analysis.Weather.DefaultIfEmpty().Max(x => x == null ? 0 : x.ID);
            var weather = (from ms in Moniroting.V_MS
                           join wx in Moniroting.V_WXT on ms.MSid equals wx.MSid
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
                Console.WriteLine($"Added weather data {weather.FirstOrDefault().time}");
                Analysis.Weather.AddRange(weather);
                Analysis.ChangeTracker.DetectChanges();
            }
        }

        public void UpdateMeasurments()
        {
            //TODO: 
            //var dbsets = typeof(DB_SAPEntities).GetProperties().Where(p => p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>));
            //var dbset = typeof(DB_SAPEntities).GetProperty("V_SENSIS_CL2");
            int NumOfRows = 50_000;


            #region CL2 Entities / 37
            var max = Analysis.Measurment.Where(x => x.SubstanceID == 37).DefaultIfEmpty().Max(r => r == null ? 0 : r.SensisID);
            var CL2Entities = (from x in Moniroting.V_SENSIS_CL2
                               join z in Moniroting.V_MS on x.MSid equals z.MSid
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
            max = Analysis.Measurment.Where(x => x.SubstanceID == 25).DefaultIfEmpty().Max(r => r == null ? 0 : r.SensisID);
            var COEntities = (from x in Moniroting.V_SENSIS_CO
                               join z in Moniroting.V_MS on x.MSid equals z.MSid
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

            max = Analysis.Measurment.Where(x => x.SubstanceID == 39).DefaultIfEmpty().Max(r => r == null ? 0 : r.SensisID);
            var CXHYEntities = (from x in Moniroting.V_SENSIS_CXHY
                              join z in Moniroting.V_MS on x.MSid equals z.MSid
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

            max = Analysis.Measurment.Where(x => x.SubstanceID == 27).DefaultIfEmpty().Max(r => r == null ? 0 : r.SensisID);
            var HCLEntities = (from x in Moniroting.V_SENSIS_HCL
                                join z in Moniroting.V_MS on x.MSid equals z.MSid
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

            max = Analysis.Measurment.Where(x => x.SubstanceID == 30).DefaultIfEmpty().Max(r => r == null ? 0 : r.SensisID);
            var HCOHEntities = (from x in Moniroting.V_SENSIS_HCOH
                               join z in Moniroting.V_MS on x.MSid equals z.MSid
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

            max = Analysis.Measurment.Where(x => x.SubstanceID == 26).DefaultIfEmpty().Max(r => r == null ? 0 : r.SensisID);
            var HFEntities = (from x in Moniroting.V_SENSIS_HF
                                join z in Moniroting.V_MS on x.MSid equals z.MSid
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

            max = Analysis.Measurment.Where(x => x.SubstanceID == 21).DefaultIfEmpty().Max(r => r == null ? 0 : r.SensisID);
            var NO2Entities = (from x in Moniroting.V_SENSIS_NO2
                              join z in Moniroting.V_MS on x.MSid equals z.MSid
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

            max = Analysis.Measurment.Where(x => x.SubstanceID == 23).DefaultIfEmpty().Max(r => r == null ? 0 : r.SensisID);
            var SO2Entities = (from x in Moniroting.V_SENSIS_SO2
                              join z in Moniroting.V_MS on x.MSid equals z.MSid
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

        }

        private void AddMeasurments(IQueryable<Measurment> Entities)
        {
            if (Entities != null && Entities.Count() > 0)
            {
                Console.WriteLine($"Added measurments ebtities - {Entities.First().SubstanceID} of {Entities.Count()}");
                Analysis.Measurment.AddRange(Entities);
                Analysis.ChangeTracker.DetectChanges();
            }
        }

        

    }
}
