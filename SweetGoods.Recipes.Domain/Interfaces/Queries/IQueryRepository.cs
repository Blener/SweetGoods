using System;
using System.Linq;
using System.Threading.Tasks;

namespace SweetGoods.Recipes.Domain.Interfaces.Queries
{
    public interface IQueryRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity> GetByAggregateId(Guid aggregateId);

        IQueryable<TEntity> GetAll();

        Task<bool> ExistAggregateId(Guid aggregateId);
    }
}