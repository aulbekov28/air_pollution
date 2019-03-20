using Newtonsoft.Json.Linq;
using System;
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

namespace Dissertation.Web.Controllers
{
    public class ValuesController : ApiController
    {
        private ILog _log = LogManager.GetLogger(typeof(ValuesController));

        private readonly IDataAnalysisContext _dataAnalysisContext;

        public ValuesController()
        {
            _dataAnalysisContext = new DataAnalysisContext();
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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
                        notify.SendTelegramChannel(message.ToString());
                    }
                    b.SaveChanges();
                }
            }
            catch (Exception e)
            {
               _log.Error(e);
                notify.SendTelegramChannel($"API CALL / Error {e.Message}");
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

        public async Task<IHttpActionResult> GetForVisualization()
        {
            throw new NotImplementedException();
            try
            {
                //var _data = await 
            }
            finally
            {
                
            }

            return BadRequest();
        }


        [HttpPost]
        public void Predictions(Object o)
        {
            //string postData = new System.IO.StreamReader(context.Request.InputStream).ReadToEnd();
            throw new NotImplementedException();
        }
    }
}
