using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dissertation.Data;
using Dissertation.Data.Context;

namespace Dissertation.Service.IntegrationService.Services
{
    class PostUpdater : BaseUpdater, IUpdater<Post>
    {
        public PostUpdater(IDB_SAPEntities _monitoringContext, IDataAnalysisContext _analysisContext) : base(_monitoringContext, _analysisContext)
        {
        }

        public void Execute()
        {
            if (_analysisContext.Post.FirstOrDefault() != null)
            {
                Console.WriteLine("Daijobu");
                return;
            }
            WriteData(GetData());
            _analysisContext.SaveChanges();
        }

        public IEnumerable<Post> GetData()
        {
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

            return posts;
        }

        public void WriteData(IEnumerable<Post> posts)
        {
            foreach (var a in posts)
            {
                if (_analysisContext.Post.Exists(a.ID)) continue;
                _log.Trace($"Added new post {a.Name}");
                _analysisContext.Post.Add(a);
            }
        }
    }
}
