using System;
using System.Threading.Tasks;

namespace SweetGoods.Recipes.Domain.Interfaces.Commands
{
    public interface ICommandRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);

        void Update(TEntity obj);

        Task Remove(Guid id);
    }
}