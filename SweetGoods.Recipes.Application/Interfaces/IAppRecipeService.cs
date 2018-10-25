using GiftBagOfBases.Interfaces.Application;
using SweetGoods.Recipes.Application.ViewModels;
using System.Threading.Tasks;

namespace SweetGoods.Recipes.Application.Interfaces
{
    public interface IAppRecipeService : IAppFullService<RecipeViewModel>
    {
        Task AddCategory(RecipeCategoryViewModel viewModel);
    }
}