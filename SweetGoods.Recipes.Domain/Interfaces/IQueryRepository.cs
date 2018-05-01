using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetGoods.Recipes.Domain.Interfaces
{
    public interface IQueryRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity> GetByAggregateId(Guid id);

        IQueryable<TEntity> GetAll();
    }
}