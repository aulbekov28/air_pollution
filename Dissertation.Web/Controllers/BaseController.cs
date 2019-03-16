using Dissertation.Data;
using Dissertation.Data.Context;
using System.Web.Mvc;

namespace Dissertation.Web.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IDataAnalysisContext _dataContext;

        public BaseController()
        {
            _dataContext = new DataAnalysisContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dataContext.Dispose();
        }
    }
}