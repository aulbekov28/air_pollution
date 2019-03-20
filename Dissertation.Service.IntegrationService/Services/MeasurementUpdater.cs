using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dissertation.Data;
using Dissertation.Data.Context;

namespace Dissertation.Service.IntegrationService.Services
{
    internal class MeasurementUpdater : BaseUpdater, IUpdater<Measurment>
    {
        public MeasurementUpdater(DB_SAPEntities _monitoringContext, IDataAnalysisContext _analysisContext) : base(_monitoringContext, _analysisContext)
        {
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Measurment> GetData()
        {
            throw new NotImplementedException();
        }

        //TODO REWRITE THAT STUFF
        public void WriteData()
        {
            int NumOfRows = 5_000;


            #region CL2 Entities / 37
            var max = _analysisContext.Measurment.Where(x => x.SubstanceID == 37).DefaultIfEmpty().Max(r => r == null ? 0 : r.SensisID);
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
            WriteData(CL2Entities);
            #endregion

            #region CO Entities / 25
            max = _analysisContext.Measurment.Where(x => x.SubstanceID == 25).DefaultIfEmpty().Max(r => r == null ? 0 : r.SensisID);
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
            WriteData(COEntities);
            #endregion

            #region CxHy Entities / 39
            max = _analysisContext.Measurment.Where(x => x.SubstanceID == 39).DefaultIfEmpty().Max(r => r == null ? 0 : r.SensisID);
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
            WriteData(CXHYEntities);
            #endregion

            #region HCl / 27
            max = _analysisContext.Measurment.Where(x => x.SubstanceID == 27).DefaultIfEmpty().Max(r => r == null ? 0 : r.SensisID);
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
            WriteData(HCLEntities);


            #endregion

            #region HCOH / 30
            max = _analysisContext.Measurment.Where(x => x.SubstanceID == 30).DefaultIfEmpty().Max(r => r == null ? 0 : r.SensisID);
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
            WriteData(HCOHEntities);
            #endregion

            #region HF / 26
            max = _analysisContext.Measurment.Where(x => x.SubstanceID == 26).DefaultIfEmpty().Max(r => r == null ? 0 : r.SensisID);
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
            WriteData(HFEntities);
            #endregion

            #region NO2 / 21
            max = _analysisContext.Measurment.Where(x => x.SubstanceID == 21).DefaultIfEmpty().Max(r => r == null ? 0 : r.SensisID);
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
            WriteData(NO2Entities);
            #endregion

            #region SO2
            max = _analysisContext.Measurment.Where(x => x.SubstanceID == 23).DefaultIfEmpty().Max(r => r == null ? 0 : r.SensisID);
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
            WriteData(SO2Entities);
            #endregion
        }

        public void WriteData(IEnumerable<Measurment> obtainedData)
        {
            if (obtainedData != null && obtainedData.Count() > 0)
            {
                _log.Trace($"Added measurments ({obtainedData.First().SubstanceID}) entities - {obtainedData.Count()}");
                _analysisContext.Measurment.AddRange(obtainedData);
                _analysisContext.ChangeTracker.DetectChanges();
            }
        }

        private IQueryable<T> GetValues<T, E>(int SubID) where T : class
        {
            var subDbSet = _monitoringContext.Set<T>();
            var max = _analysisContext.Measurment.Where(x => x.SubstanceID == SubID).DefaultIfEmpty().Max(r => r == null ? 0 : r.SensisID);

            var CL2Entities = (from x in _monitoringContext.V_SENSIS_CL2
                join z in _monitoringContext.V_MS on x.MSid equals z.MSid
                where z.MSid > max
                select new Measurment
                {
                    //Value = x.P0037,
                    SensisID = z.MSid,
                    Time = z.MTime,
                    TimeC = z.CTime,
                    PostID = z.CPid,
                    SubstanceID = SubID
                }).OrderBy(v => v.SensisID).Take(5000);

            var Entities = (from x in subDbSet

                            select new Measurment
                {

                });

            throw new NotImplementedException();
        }

    }
}
