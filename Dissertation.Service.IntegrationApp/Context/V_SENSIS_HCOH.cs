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
    
    public partial class V_SENSIS_HCOH
    {
        public int V_SENSIS_HCOHid { get; set; }
        public Nullable<int> MSid { get; set; }
        public Nullable<double> P0030 { get; set; }
        public Nullable<int> P1030 { get; set; }
        public Nullable<int> P6330 { get; set; }
        public Nullable<int> On { get; set; }
    
        public virtual V_MS V_MS { get; set; }
    }
}
