using System.ComponentModel.DataAnnotations.Schema;

namespace Dissertation.Data.Context
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
