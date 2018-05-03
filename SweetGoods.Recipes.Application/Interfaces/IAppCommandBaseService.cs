using SweetGoods.Recipes.Application.ViewModels;
using System;

namespace SweetGoods.Recipes.Application.Interfaces
{
    public interface IAppCommandBaseService<TViewModel> : IDisposable where TViewModel : ViewModel
    {
    }
}