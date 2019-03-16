using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;

namespace Dissertation.Data.Context
{
    public class BaseEntity
    {
        [Key]
        public long ID { get; set; }
    }


    public static class DbContextExtensions
    {
        public static Tuple<bool,TModel> GetOrCreate<TModel>(this DbSet<TModel> model, long id) where TModel : BaseEntity, new()
        {
            var entity = model.SingleOrDefault(x => x.ID == id);
            Tuple<bool, TModel> EntityModel = new Tuple<bool, TModel>(entity == null, entity ?? new TModel());
            return EntityModel;
        }

        public static bool Exists<TModel>(this DbSet<TModel> model, long id) where TModel : BaseEntity
        {
            return model.SingleOrDefault(x => x.ID == id) != null;
        }

    }
}
