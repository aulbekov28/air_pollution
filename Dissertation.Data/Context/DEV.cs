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
    
    public partial class DEV
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DEV()
        {
            this.GROUP_CP = new HashSet<GROUP_CP>();
            this.RepDev = new HashSet<RepDev>();
        }
    
        public int Number { get; set; }
        public Nullable<int> ITid { get; set; }
        public Nullable<int> CPid { get; set; }
        public Nullable<int> Ndev { get; set; }
        public Nullable<int> ON { get; set; }
        public Nullable<int> MIid { get; set; }
        public Nullable<int> ADDid { get; set; }
        public Nullable<int> Cycle { get; set; }
    
        public virtual CP CP { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GROUP_CP> GROUP_CP { get; set; }
        public virtual IT IT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RepDev> RepDev { get; set; }
    }
}