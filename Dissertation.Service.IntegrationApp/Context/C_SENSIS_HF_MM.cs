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
    
    public partial class C_SENSIS_HF_MM
    {
        public int C_SENSIS_HF_MMid { get; set; }
        public int MSid { get; set; }
        public Nullable<double> P3826 { get; set; }
        public Nullable<double> P5826 { get; set; }
    
        public virtual C_MS C_MS { get; set; }
    }
}
