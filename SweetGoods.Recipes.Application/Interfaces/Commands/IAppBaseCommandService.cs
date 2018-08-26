using SweetGoods.Recipes.Application.ViewModels;
using System;

namespace SweetGoods.Recipes.Application.Interfaces.Commands
{
    public interface IAppBaseCommandService<TViewModel> : IDisposable where TViewModel : BaseViewModel
    {
        void Add(TViewModel viewModel);

        void Update(TViewModel viewModel);

        void Remove(Guid aggregateId);

        void Restore(Guid aggregateId);
    }
}