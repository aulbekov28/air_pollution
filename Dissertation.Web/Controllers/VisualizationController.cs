using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace Dissertation.Web.Controllers
{
    public class VisualizationController : BaseController
    {
        // GET: Visualize
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AirMap()
        {
            return View();
        }

        public IHttpActionResult GetStations()
        {

            throw new NotImplementedException();
        }
    }
}