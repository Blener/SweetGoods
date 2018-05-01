using Microsoft.EntityFrameworkCore;
using SweetGoods.Recipes.Domain.Core.Models;
using SweetGoods.Recipes.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SweetGoods.Recipes.Infra.Data.Repositories
{
    public abstract class CommandRepository<TEntity, TContext> : ICommandRepository<TEntity> where TEntity : Entity where TContext : DbContext
    {
        protected readonly TContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public CommandRepository(TContext db)
        {
            Db = db;
        }

        public void Add(TEntity obj)
        {
            DbSet.AddAsync(obj);
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }
    }
}