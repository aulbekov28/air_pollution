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
    
    public partial class V_REGARD
    {
        public int V_REGARDid { get; set; }
        public Nullable<int> MSid { get; set; }
        public Nullable<int> P2303 { get; set; }
        public Nullable<int> P5303 { get; set; }
    
        public virtual V_MS V_MS { get; set; }
    }
}