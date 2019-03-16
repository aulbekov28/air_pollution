namespace Dissertation.Service.IntegrationApp.Context
{
    using MySql.Data.Entity;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DataAnalysisContext : DbContext
    {
        public DataAnalysisContext()
            : base("name=DataAnalysisContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Substance>().Property(m => m.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Post>().Property(m => m.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Weather>().Property(m => m.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Weather> Weather { get; set; }
        public virtual DbSet<Measurment> Measurment { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<Substance> Substance { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}



}