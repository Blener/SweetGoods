using SweetGoods.Recipes.Application.ViewModels;
using SweetGoods.Recipes.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SweetGoods.Recipes.Application.Interfaces
{
    public interface IAppQueryBaseService<TViewModel> : IDisposable where TViewModel : ViewModel
    {
        Task<TViewModel> GetByAggregateId(Guid aggregateId);

        IEnumerable<TViewModel> GetAll();
    }
}