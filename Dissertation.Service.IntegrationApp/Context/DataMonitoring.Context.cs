﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DB_SAPEntities : DbContext
    {
        public DB_SAPEntities()
            : base("name=DB_SAPEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ADDD> ADDD { get; set; }
        public virtual DbSet<ALG> ALG { get; set; }
        public virtual DbSet<BD> BD { get; set; }
        public virtual DbSet<BOUNDS> BOUNDS { get; set; }
        public virtual DbSet<C_MS> C_MS { get; set; }
        public virtual DbSet<C_SENSIS_CL2_D> C_SENSIS_CL2_D { get; set; }
        public virtual DbSet<C_SENSIS_CL2_DD> C_SENSIS_CL2_DD { get; set; }
        public virtual DbSet<C_SENSIS_CL2_M> C_SENSIS_CL2_M { get; set; }
        public virtual DbSet<C_SENSIS_CL2_MM> C_SENSIS_CL2_MM { get; set; }
        public virtual DbSet<C_SENSIS_CL2_Y> C_SENSIS_CL2_Y { get; set; }
        public virtual DbSet<C_SENSIS_CL2_YY> C_SENSIS_CL2_YY { get; set; }
        public virtual DbSet<C_SENSIS_CO_D> C_SENSIS_CO_D { get; set; }
        public virtual DbSet<C_SENSIS_CO_DD> C_SENSIS_CO_DD { get; set; }
        public virtual DbSet<C_SENSIS_CO_M> C_SENSIS_CO_M { get; set; }
        public virtual DbSet<C_SENSIS_CO_MM> C_SENSIS_CO_MM { get; set; }
        public virtual DbSet<C_SENSIS_CO_Y> C_SENSIS_CO_Y { get; set; }
        public virtual DbSet<C_SENSIS_CO_YY> C_SENSIS_CO_YY { get; set; }
        public virtual DbSet<C_SENSIS_CXHY_D> C_SENSIS_CXHY_D { get; set; }
        public virtual DbSet<C_SENSIS_CXHY_DD> C_SENSIS_CXHY_DD { get; set; }
        public virtual DbSet<C_SENSIS_CXHY_M> C_SENSIS_CXHY_M { get; set; }
        public virtual DbSet<C_SENSIS_CXHY_MM> C_SENSIS_CXHY_MM { get; set; }
        public virtual DbSet<C_SENSIS_CXHY_Y> C_SENSIS_CXHY_Y { get; set; }
        public virtual DbSet<C_SENSIS_CXHY_YY> C_SENSIS_CXHY_YY { get; set; }
        public virtual DbSet<C_SENSIS_HCL_D> C_SENSIS_HCL_D { get; set; }
        public virtual DbSet<C_SENSIS_HCL_DD> C_SENSIS_HCL_DD { get; set; }
        public virtual DbSet<C_SENSIS_HCL_M> C_SENSIS_HCL_M { get; set; }
        public virtual DbSet<C_SENSIS_HCL_MM> C_SENSIS_HCL_MM { get; set; }
        public virtual DbSet<C_SENSIS_HCL_Y> C_SENSIS_HCL_Y { get; set; }
        public virtual DbSet<C_SENSIS_HCL_YY> C_SENSIS_HCL_YY { get; set; }
        public virtual DbSet<C_SENSIS_HCOH_D> C_SENSIS_HCOH_D { get; set; }
        public virtual DbSet<C_SENSIS_HCOH_DD> C_SENSIS_HCOH_DD { get; set; }
        public virtual DbSet<C_SENSIS_HCOH_M> C_SENSIS_HCOH_M { get; set; }
        public virtual DbSet<C_SENSIS_HCOH_MM> C_SENSIS_HCOH_MM { get; set; }
        public virtual DbSet<C_SENSIS_HCOH_Y> C_SENSIS_HCOH_Y { get; set; }
        public virtual DbSet<C_SENSIS_HCOH_YY> C_SENSIS_HCOH_YY { get; set; }
        public virtual DbSet<C_SENSIS_HF_D> C_SENSIS_HF_D { get; set; }
        public virtual DbSet<C_SENSIS_HF_DD> C_SENSIS_HF_DD { get; set; }
        public virtual DbSet<C_SENSIS_HF_M> C_SENSIS_HF_M { get; set; }
        public virtual DbSet<C_SENSIS_HF_MM> C_SENSIS_HF_MM { get; set; }
        public virtual DbSet<C_SENSIS_HF_Y> C_SENSIS_HF_Y { get; set; }
        public virtual DbSet<C_SENSIS_HF_YY> C_SENSIS_HF_YY { get; set; }
        public virtual DbSet<C_SENSIS_NO2_D> C_SENSIS_NO2_D { get; set; }
        public virtual DbSet<C_SENSIS_NO2_DD> C_SENSIS_NO2_DD { get; set; }
        public virtual DbSet<C_SENSIS_NO2_M> C_SENSIS_NO2_M { get; set; }
        public virtual DbSet<C_SENSIS_NO2_MM> C_SENSIS_NO2_MM { get; set; }
        public virtual DbSet<C_SENSIS_NO2_Y> C_SENSIS_NO2_Y { get; set; }
        public virtual DbSet<C_SENSIS_NO2_YY> C_SENSIS_NO2_YY { get; set; }
        public virtual DbSet<C_SENSIS_SO2_D> C_SENSIS_SO2_D { get; set; }
        public virtual DbSet<C_SENSIS_SO2_DD> C_SENSIS_SO2_DD { get; set; }
        public virtual DbSet<C_SENSIS_SO2_M> C_SENSIS_SO2_M { get; set; }
        public virtual DbSet<C_SENSIS_SO2_MM> C_SENSIS_SO2_MM { get; set; }
        public virtual DbSet<C_SENSIS_SO2_Y> C_SENSIS_SO2_Y { get; set; }
        public virtual DbSet<C_SENSIS_SO2_YY> C_SENSIS_SO2_YY { get; set; }
        public virtual DbSet<COND> COND { get; set; }
        public virtual DbSet<CP> CP { get; set; }
        public virtual DbSet<CRIT> CRIT { get; set; }
        public virtual DbSet<DC> DC { get; set; }
        public virtual DbSet<DEV> DEV { get; set; }
        public virtual DbSet<DIM> DIM { get; set; }
        public virtual DbSet<FORMAT> FORMAT { get; set; }
        public virtual DbSet<FPS> FPS { get; set; }
        public virtual DbSet<GROUP_CP> GROUP_CP { get; set; }
        public virtual DbSet<IT> IT { get; set; }
        public virtual DbSet<MI> MI { get; set; }
        public virtual DbSet<MSG> MSG { get; set; }
        public virtual DbSet<NC> NC { get; set; }
        public virtual DbSet<OPERS> OPERS { get; set; }
        public virtual DbSet<OTT_SET> OTT_SET { get; set; }
        public virtual DbSet<PAR> PAR { get; set; }
        public virtual DbSet<REGIM> REGIM { get; set; }
        public virtual DbSet<RepDev> RepDev { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TLevelSql> TLevelSql { get; set; }
        public virtual DbSet<TM> TM { get; set; }
        public virtual DbSet<TRepColumns> TRepColumns { get; set; }
        public virtual DbSet<TRepList> TRepList { get; set; }
        public virtual DbSet<TYPE> TYPE { get; set; }
        public virtual DbSet<TypeDevice> TypeDevice { get; set; }
        public virtual DbSet<V_ALARM> V_ALARM { get; set; }
        public virtual DbSet<V_EPC> V_EPC { get; set; }
        public virtual DbSet<V_GPS> V_GPS { get; set; }
        public virtual DbSet<V_GT> V_GT { get; set; }
        public virtual DbSet<V_MGT> V_MGT { get; set; }
        public virtual DbSet<V_MS> V_MS { get; set; }
        public virtual DbSet<V_OTT> V_OTT { get; set; }
        public virtual DbSet<V_POLY> V_POLY { get; set; }
        public virtual DbSet<V_POLY_CL2> V_POLY_CL2 { get; set; }
        public virtual DbSet<V_POLY_CO> V_POLY_CO { get; set; }
        public virtual DbSet<V_POLY_HCL> V_POLY_HCL { get; set; }
        public virtual DbSet<V_POLY_HF> V_POLY_HF { get; set; }
        public virtual DbSet<V_POLY_NH3> V_POLY_NH3 { get; set; }
        public virtual DbSet<V_POLY_NO2> V_POLY_NO2 { get; set; }
        public virtual DbSet<V_POLY_SO2> V_POLY_SO2 { get; set; }
        public virtual DbSet<V_REGARD> V_REGARD { get; set; }
        public virtual DbSet<V_REGARD_CL2> V_REGARD_CL2 { get; set; }
        public virtual DbSet<V_SENSIS> V_SENSIS { get; set; }
        public virtual DbSet<V_SENSIS_CL2> V_SENSIS_CL2 { get; set; }
        public virtual DbSet<V_SENSIS_CO> V_SENSIS_CO { get; set; }
        public virtual DbSet<V_SENSIS_CXHY> V_SENSIS_CXHY { get; set; }
        public virtual DbSet<V_SENSIS_HCL> V_SENSIS_HCL { get; set; }
        public virtual DbSet<V_SENSIS_HCOH> V_SENSIS_HCOH { get; set; }
        public virtual DbSet<V_SENSIS_HF> V_SENSIS_HF { get; set; }
        public virtual DbSet<V_SENSIS_NH3> V_SENSIS_NH3 { get; set; }
        public virtual DbSet<V_SENSIS_NO> V_SENSIS_NO { get; set; }
        public virtual DbSet<V_SENSIS_NO2> V_SENSIS_NO2 { get; set; }
        public virtual DbSet<V_SENSIS_SO2> V_SENSIS_SO2 { get; set; }
        public virtual DbSet<V_SSD> V_SSD { get; set; }
        public virtual DbSet<V_STAT> V_STAT { get; set; }
        public virtual DbSet<V_UTP> V_UTP { get; set; }
        public virtual DbSet<V_WXT> V_WXT { get; set; }
        public virtual DbSet<WS> WS { get; set; }
    }
}
