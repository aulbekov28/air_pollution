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
    
    public partial class V_OTT
    {
        public int V_OTTid { get; set; }
        public Nullable<int> MSid { get; set; }
        public Nullable<double> P0198 { get; set; }
        public Nullable<double> P0199 { get; set; }
        public Nullable<double> P0200 { get; set; }
        public Nullable<int> P0460 { get; set; }
        public Nullable<int> P0461 { get; set; }
        public Nullable<int> P1200 { get; set; }
        public Nullable<int> P1199 { get; set; }
        public Nullable<int> P1198 { get; set; }
    
        public virtual V_MS V_MS { get; set; }
    }
}
