using SweetGoods.Recipes.Application.ViewModels;

namespace SweetGoods.Recipes.Application.Interfaces.Commands
{
    public interface IAppCookingMethodCommandService : IAppBaseCommandService<CookingMethodViewModel>
    {
        void AddIngredient(CookingMethodIngredientViewModel viewModel);

        void AddStep(CookingStepViewModel viewModel);
    }
}