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
    
    public partial class DC
    {
        public int DCid { get; set; }
        public Nullable<int> Source { get; set; }
        public Nullable<int> Target { get; set; }
        public Nullable<double> Factor { get; set; }
        public Nullable<int> PARid { get; set; }
    
        public virtual PAR PAR { get; set; }
    }
}