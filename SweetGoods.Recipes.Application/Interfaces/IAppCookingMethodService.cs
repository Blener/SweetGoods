using GiftBagOfBases.Interfaces.Application;
using SweetGoods.Recipes.Application.ViewModels;

namespace SweetGoods.Recipes.Application.Interfaces
{
    public interface IAppCookingMethodService : IAppFullService<CookingMethodViewModel>
    {
        void AddIngredient(CookingMethodIngredientViewModel viewModel);

        void AddStep(CookingStepViewModel viewModel);
    }
}