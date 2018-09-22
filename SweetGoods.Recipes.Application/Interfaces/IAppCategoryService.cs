using GiftBagOfBases.Interfaces.Application;
using SweetGoods.Recipes.Application.ViewModels;

namespace SweetGoods.Recipes.Application.Interfaces
{
    public interface IAppCategoryService : IAppFullService<CategoryViewModel>
    {
    }
}