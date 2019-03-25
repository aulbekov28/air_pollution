﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dissertation.Data.Context;

namespace Dissertation.Data
{
    public interface IDataAnalysisContext : IDbContext
    {
        DbSet<Weather> Weather { get; set; }
        DbSet<Measurment> Measurment { get; set; }
        DbSet<Post> Post { get; set; }
        DbSet<Substance> Substance { get; set; }
        DbSet<Prediction> Predictions { get; set; }
        
    }
}
