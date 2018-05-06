using Microsoft.EntityFrameworkCore;
using SweetGoods.Recipes.Domain.Core.Models;
using SweetGoods.Recipes.Domain.Interfaces.Queries;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SweetGoods.Recipes.Infra.Data.Repositories.Queries
{
    public class QueryRepository<TEntity, TContext> : IQueryRepository<TEntity> where TEntity : Entity where TContext : DbContext
    {
        protected readonly TContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public QueryRepository(TContext db)
        {
            Db = db;
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public Task<TEntity> GetByAggregateId(Guid aggregateId)
        {
            return DbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == aggregateId);
        }

        public Task<bool> ExistAggregateId(Guid aggregateId)
        {
            return DbSet
                .AnyAsync(x => x.Id == aggregateId);
        }
    }
}