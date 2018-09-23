using AutoMapper;
using SweetGoods.Recipes.Application.ViewModels;
using SweetGoods.Recipes.Domain.Commands.Category;
using SweetGoods.Recipes.Domain.Commands.CookingMethod;
using SweetGoods.Recipes.Domain.Commands.Ingredient;
using SweetGoods.Recipes.Domain.Commands.Recipe;

namespace SweetGoods.Recipes.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            RecipeMappings();
        }

        private void RecipeMappings()
        {
            CreateMap<CategoryViewModel, AddNewCategory>();
            CreateMap<CategoryViewModel, UpdateCategory>();

            CreateMap<CookingMethodIngredientViewModel, AddNewIngredient>();

            CreateMap<CookingMethodViewModel, AddNewCookingMethod>();
            CreateMap<CookingMethodViewModel, UpdateCookingMethod>();

            CreateMap<CookingStepViewModel, AddStep>();

            CreateMap<IngredientViewModel, AddNewIngredient>();
            CreateMap<IngredientViewModel, UpdateIngredient>();

            CreateMap<RecipeCategoryViewModel, AddCategory>();

            CreateMap<RecipeViewModel, AddNewRecipe>();
            CreateMap<RecipeViewModel, UpdateRecipe>();
        }
    }
}