namespace Dissertation.Data.Context
{
    using MySql.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DataAnalysisContext : DbContext, IDataAnalysisContext
    {
        public DataAnalysisContext()
            : base("name=DataAnalysisContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(string.Empty);
            modelBuilder.Entity<Substance>().Property(m => m.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Post>().Property(m => m.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Weather>().Property(m => m.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Prediction>().Property(m => m.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Measurment>().Property(m => m.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Weather> Weather { get; set; }
        public DbSet<Measurment> Measurment { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Substance> Substance { get; set; }
        public DbSet<Prediction> Predictions { get; set; }
    }


}