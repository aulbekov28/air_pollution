//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dissertation.Data.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class DIM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DIM()
        {
            this.PAR = new HashSet<PAR>();
        }
    
        public int DIMid { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public Nullable<int> IDTM { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PAR> PAR { get; set; }
        public virtual TM TM { get; set; }
    }
}
