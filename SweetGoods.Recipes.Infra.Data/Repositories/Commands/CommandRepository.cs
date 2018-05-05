using Microsoft.EntityFrameworkCore;
using SweetGoods.Recipes.Domain.Core.Models;
using SweetGoods.Recipes.Domain.Interfaces.Commands;
using System;
using System.Threading.Tasks;

namespace SweetGoods.Recipes.Infra.Data.Repositories.Commands
{
    public class CommandRepository<TEntity, TContext> : ICommandRepository<TEntity> where TEntity : Entity where TContext : DbContext
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

        public async Task Remove(Guid id)
        {
            DbSet.Remove(await DbSet.FirstOrDefaultAsync(x => x.AggregateId == id));
        }

        public void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }
    }
}