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
    
    public partial class C_SENSIS_HCOH_M
    {
        public int C_SENSIS_HCOH_Mid { get; set; }
        public int MSid { get; set; }
        public Nullable<double> P2830 { get; set; }
        public Nullable<double> P4830 { get; set; }
    
        public virtual C_MS C_MS { get; set; }
    }
}
