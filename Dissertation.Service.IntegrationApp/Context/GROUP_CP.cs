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
    
    public partial class GROUP_CP
    {
        public int GrCPid { get; set; }
        public int ParentCPid { get; set; }
        public int ChildCPid { get; set; }
        public int IDRD { get; set; }
    
        public virtual CP CP { get; set; }
        public virtual DEV DEV { get; set; }
        public virtual RepDev RepDev { get; set; }
    }
}