using System.ComponentModel.DataAnnotations.Schema;

namespace Dissertation.Data.Context
{
    [Table("Substance")]
    public class Substance : BaseEntity
    {
        //[Key]
        //public int SubstanceID { get; set; }
        //public int AddID { get; set; }
        public string Name { get; set; }
        public string NameFull { get; set; }
        public double? PDK_MaxAllowable { get; set; }
        public double? PDK_OneTime { get; set; }
    }
}
