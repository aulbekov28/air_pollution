using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Dissertation.Data;
using Dissertation.Data.Context;
using Dissertation.Web.Classes;
using Common.Logging;
using Dissertation.Notification;
using Microsoft.Ajax.Utilities;
using System.Threading.Tasks;
using System.Web.Http.Results;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace Dissertation.Web.Controllers
{
    public class AirMapModel
    {
        public DateTime date { get; set; }

        public ICollection<AirMapData> samples { get; set; }
    }

    public class AirMapData
    {
        public int stationId { get; set; }
        public double? hcoh { get; set; }
        public double? hcl { get; set; }
        public double? no2 { get; set; }
        public double? hf { get; set; }
        public double? cl2 { get; set; }
        public double? so2 { get; set; }
        public double? co { get; set; }
        public double? cxhy { get; set; }
        public double wd { get; set; }
        public double wv { get; set; }
        public double temp { get; set; }
        public double hum { get; set; }
    }

    public class ValuesController : ApiController
    {
        private ILog _log = LogManager.GetLogger(typeof(ValuesController));

        private readonly IDataAnalysisContext _dataAnalysisContext;

        public ValuesController()
        {
            _dataAnalysisContext = new DataAnalysisContext();
        }

        
        
        // GET api/values
        public HttpResponseMessage Get()
        {
            var jsonData= JsonConvert.SerializeObject(GetData(),Formatting.None);
            
            System.IO.File.WriteAllText("~/src/sample/sample-data.json",jsonData);

            return new HttpResponseMessage()
            {
                Content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK
            };

        }

        // GET api/values/5
        public string Get(int id)
        {
            return $"value {id}";
        }

        // POST api/values
        public void Post([FromBody]string data)
        {
            JObject obj = JObject.Parse(data);
            List<Prediction> predictions = new List<Prediction>();
            StringBuilder message = new StringBuilder();
            var notify = new Notification.Notifier();

            _log.Trace($"API CALL / Records received {obj.Count}");
            try
            {
                using (var b = new DataAnalysisContext())
                {

                    foreach (var x in obj)
                    {
                        string name = x.Key;
                        JToken value = x.Value;

                        var itemPrediction = new Prediction
                        {
                            MeasurementID = (long?)value["id"],
                            PontID = (long)value["point"],
                            SubstanceID = (long)value["substance"],
                            PredictedValue = (double)value["predicted"],
                            PredictionTime = Convert.ToDateTime(value["time"]).Add(TimeSpan.FromMinutes((int?)value["prediction_range"] ?? 20)),
                            PreditionRange = TimeSpan.FromMinutes((int?)value["prediction_range"] ?? 20)
                        };
                        b.Predictions.Add(itemPrediction);
                        
                        double rate = (double) value["rate"];
                        if (rate >= 0.95)
                        {
                            message.AppendLine($"{itemPrediction.ToString()} критичный уровень {rate.ToString("F2")} ПДК");
                        } else if (rate >= 0.80)
                        {
                            message.AppendLine($"{itemPrediction.ToString()} повышенный уровень {rate.ToString("F2")} ПДК");
                        }
                        else
                        {
                            message.AppendLine($"{itemPrediction.ToString()} {rate.ToString("F2")} ПДК");
                        }
                    }

                    if (message.Length > 0)
                    {
                        notify.Notify(message.ToString());
                    }
                    b.SaveChanges();
                }
            }
            catch (Exception e)
            {
               _log.Error(e);
                notify.Notify($"API CALL / Error {e.Message}");
            }


            _log.Trace($"API CALL / Prediction is done");
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        private AirMapModel GetData()
        {
            var result = (from t in _dataAnalysisContext.Measurment
                          join s in _dataAnalysisContext.Substance on t.SubstanceID equals s.ID
                          group t by new { t.PostID, t.SubstanceID }
                into grp
                          select new
                          {
                              post = grp.Key.PostID,
                              sub = grp.Key.SubstanceID,
                              val = grp.Select(v => v.Value).FirstOrDefault(),
                              date = grp.Select(d => d.Time).FirstOrDefault()
                          }).ToList();

            var meteoData = (from t in _dataAnalysisContext.Weather
                             orderby t.ID descending
                             select t).First();

            var response = new AirMapModel
            {
                date = result[0].date.Value,
                samples = new List<AirMapData>()
            };

            IEnumerable<int> postIds = Enumerable.Range(1001, 9);

            foreach (var id in postIds)
            {
                foreach (var row in result.Where(x => x.post == id))
                {
                    var airMapData = response.samples.Where(x => x.stationId == id).FirstOrDefault();
                    if (airMapData is null)
                    {
                        airMapData = new AirMapData
                        {
                            stationId = id,
                            hum = meteoData.humidity.Value,
                            wd = meteoData.wind_dir.Value,
                            wv = meteoData.wind_speed.Value
                        };
                        response.samples.Add(airMapData);
                    }

                    switch (row.sub)
                    {
                        case 21: airMapData.no2 = row.val; break;
                        case 23: airMapData.so2 = row.val; break;
                        case 25: airMapData.co = row.val; break;
                        case 26: airMapData.hf = row.val; break;
                        case 27: airMapData.hcl = row.val; break;
                        case 30: airMapData.hcoh = row.val; break;
                        case 37: airMapData.cl2 = row.val; break;
                        case 39: airMapData.cxhy = row.val; break;
                    }
                }
            }

            return response;
        }
    }
}
