//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dissertation.Service.IntegrationApp.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class V_SENSIS
    {
        public int V_SENSISid { get; set; }
        public Nullable<int> MSid { get; set; }
        public Nullable<int> P0480 { get; set; }
        public Nullable<int> P0481 { get; set; }
        public Nullable<int> P0482 { get; set; }
        public Nullable<double> P0051 { get; set; }
        public Nullable<int> P1051 { get; set; }
        public Nullable<int> P6351 { get; set; }
    
        public virtual V_MS V_MS { get; set; }
    }
}
