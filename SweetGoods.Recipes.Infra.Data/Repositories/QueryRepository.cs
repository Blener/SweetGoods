using Microsoft.EntityFrameworkCore;
using SweetGoods.Recipes.Domain.Core.Models;
using SweetGoods.Recipes.Domain.Interfaces;
using SweetGoods.Recipes.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SweetGoods.Recipes.Infra.Data.Repositories
{
    public abstract class QueryRepository<TEntity, TContext> : IQueryRepository<TEntity> where TEntity : Entity where TContext : DbContext
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

        public Task<TEntity> GetByAggregateId(Guid id)
        {
            return DbSet.FirstOrDefaultAsync(x => x.AggregateId == id);
        }
    }
}