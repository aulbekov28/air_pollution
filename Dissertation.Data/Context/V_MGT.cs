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
    
    public partial class V_MGT
    {
        public int V_MGTid { get; set; }
        public Nullable<int> MSid { get; set; }
        public Nullable<double> P0113 { get; set; }
        public Nullable<int> P1113 { get; set; }
        public Nullable<double> P0114 { get; set; }
        public Nullable<int> P1114 { get; set; }
        public Nullable<double> P0213 { get; set; }
        public Nullable<int> P1213 { get; set; }
        public Nullable<int> P0426 { get; set; }
        public Nullable<int> P0420 { get; set; }
        public Nullable<int> P0421 { get; set; }
        public Nullable<int> P0423 { get; set; }
        public Nullable<int> P0424 { get; set; }
        public Nullable<int> P0428 { get; set; }
        public Nullable<double> P0429 { get; set; }
    
        public virtual V_MS V_MS { get; set; }
    }
}
