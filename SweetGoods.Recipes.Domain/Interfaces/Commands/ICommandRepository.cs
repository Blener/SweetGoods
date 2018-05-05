using SweetGoods.Recipes.Domain.Core.Models;
using System;
using System.Threading.Tasks;

namespace SweetGoods.Recipes.Domain.Interfaces.Commands
{
    public interface ICommandRepository<TEntity> : IDisposable where TEntity : Entity
    {
        void Add(TEntity obj);

        void Update(TEntity obj);

        Task Remove(Guid id);

        void AddRelation<TRelation>(TRelation relation) where TRelation : Entity;
    }
}