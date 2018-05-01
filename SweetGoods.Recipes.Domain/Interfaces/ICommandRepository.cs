using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SweetGoods.Recipes.Domain.Interfaces
{
    public interface ICommandRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);

        void Update(TEntity obj);

        void Remove(Guid id);
    }
}