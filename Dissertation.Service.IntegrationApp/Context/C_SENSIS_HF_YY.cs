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
    
    public partial class C_SENSIS_HF_YY
    {
        public int C_SENSIS_HF_YYid { get; set; }
        public int MSid { get; set; }
        public Nullable<double> P3926 { get; set; }
        public Nullable<double> P5926 { get; set; }
    
        public virtual C_MS C_MS { get; set; }
    }
}
