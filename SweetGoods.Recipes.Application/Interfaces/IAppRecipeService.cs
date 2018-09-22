using GiftBagOfBases.Interfaces.Application;
using SweetGoods.Recipes.Application.ViewModels;

namespace SweetGoods.Recipes.Application.Interfaces
{
    public interface IAppRecipeService : IAppFullService<RecipeViewModel>
    {
        void AddCategory(RecipeCategoryViewModel viewModel);
    }
}