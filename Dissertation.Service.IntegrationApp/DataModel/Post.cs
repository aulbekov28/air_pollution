using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dissertation.Service.IntegrationApp.Context
{
    [Table("Post")]
    public class Post : BaseEntity
    {
        //[Key]
        //public int PostID { get; set; }
        //public int CpId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public double? Longi { get; set; }
        public double? Lati { get; set; }
        public int? type { get; set; }
    }
}
