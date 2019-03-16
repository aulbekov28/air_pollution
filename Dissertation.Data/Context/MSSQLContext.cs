using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dissertation.Data.Context
{
    public class MSSQLContext: DbContext, IDataAnalysisContext
    {
        public MSSQLContext()
            : base("MSSQLAnalysisContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<Substance>().Property(m => m.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Post>().Property(m => m.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Weather>().Property(m => m.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Prediction>().Property(m => m.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Measurment>().Property(m => m.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            base.OnModelCreating(modelBuilder);
        }


        public virtual DbSet<Weather> Weather { get; set; }
        public virtual DbSet<Measurment> Measurment { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<Substance> Substance { get; set; }
        public virtual DbSet<Prediction> Predictions { get; set; }
    }
}
