using GiftBagOfBases.Interfaces.Application;
using SweetGoods.Recipes.Application.ViewModels;
using System.Threading.Tasks;

namespace SweetGoods.Recipes.Application.Interfaces
{
    public interface IAppCookingMethodService : IAppFullService<CookingMethodViewModel>
    {
        Task AddIngredient(CookingMethodIngredientViewModel viewModel);

        Task AddStep(CookingStepViewModel viewModel);
    }
}