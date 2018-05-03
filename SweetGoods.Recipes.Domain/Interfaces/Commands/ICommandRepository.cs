using System;

namespace SweetGoods.Recipes.Domain.Interfaces.Commands
{
    public interface ICommandRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);

        void Update(TEntity obj);

        void Remove(Guid id);
    }
}