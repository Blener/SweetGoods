using SweetGoods.Recipes.Application.ViewModels;
using System;

namespace SweetGoods.Recipes.Application.Interfaces.Commands
{
    public interface IAppRecipeCommandService : IAppBaseCommandService<RecipeViewModel>
    {
        void AddCategory(RecipeCategoryViewModel viewModel);
    }
}