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
    
    public partial class C_SENSIS_CXHY_DD
    {
        public int C_SENSIS_CXHY_DDid { get; set; }
        public int MSid { get; set; }
        public Nullable<double> P3739 { get; set; }
        public Nullable<double> P5739 { get; set; }
    
        public virtual C_MS C_MS { get; set; }
    }
}
