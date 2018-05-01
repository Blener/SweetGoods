using SweetGoods.Recipes.Application.ViewModels;
using SweetGoods.Recipes.Domain.Core.Commands;
using SweetGoods.Recipes.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SweetGoods.Recipes.Application.Interfaces
{
    public interface IAppCommandBaseService<TViewModel> : IDisposable where TViewModel : ViewModel
    {
    }
}