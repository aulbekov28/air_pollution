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
    
    public partial class IT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IT()
        {
            this.DEV = new HashSet<DEV>();
            this.MI = new HashSet<MI>();
        }
    
        public int ITid { get; set; }
        public string Name { get; set; }
        public string TabName { get; set; }
        public Nullable<int> PollCycle { get; set; }
        public Nullable<int> PTid { get; set; }
        public string CodIT { get; set; }
        public Nullable<int> IdTypeDevice { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEV> DEV { get; set; }
        public virtual TypeDevice TypeDevice { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MI> MI { get; set; }
    }
}