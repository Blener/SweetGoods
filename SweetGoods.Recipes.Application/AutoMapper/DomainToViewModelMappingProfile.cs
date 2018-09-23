using AutoMapper;
using SweetGoods.Recipes.Application.ViewModels;
using SweetGoods.Recipes.Domain.Models.Entities;

namespace SweetGoods.Recipes.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            RecipeMappings();
        }

        private void RecipeMappings()
        {
            CreateMap<Category, CategoryViewModel>();

            CreateMap<CookingMethod, CookingMethodViewModel>();

            CreateMap<CookingMethodIngredient, CookingMethodIngredientViewModel>();

            CreateMap<CookingStep, CookingStepViewModel>();

            CreateMap<Ingredient, IngredientViewModel>();

            CreateMap<Recipe, RecipeViewModel>();

            CreateMap<RecipeCategory, RecipeCategoryViewModel>();
        }
    }
}