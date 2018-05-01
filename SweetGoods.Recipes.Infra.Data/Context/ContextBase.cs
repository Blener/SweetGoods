using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SweetGoods.Recipes.Infra.Data.Context
{
    public class ContextBase<T> : DbContext where T : DbContext
    {
        public ContextBase(DbContextOptions<T> options) : base(options)
        {
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker
                                    .Entries()
                                    .Where(entry => entry.Entity.GetType().GetProperty("SoftDeleted") != null
                                                    && entry.State == EntityState.Deleted))
            {
                entry.State = EntityState.Modified;
                entry.Property("SoftDeleted").CurrentValue = true;
            }

            return base.SaveChanges();
        }
    }
}