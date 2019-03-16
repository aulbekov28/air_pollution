using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dissertation.Service.IntegrationApp.Context
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
