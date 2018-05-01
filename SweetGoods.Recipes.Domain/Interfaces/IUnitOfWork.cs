using SweetGoods.Recipes.Domain.Core.Commands;
using System;

namespace SweetGoods.Recipes.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}