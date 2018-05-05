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
            CreateMap<Category, CategoryViewModel>().ReverseMap();

            CreateMap<CookingMethod, CookingMethodViewModel>().ReverseMap();

            CreateMap<CookingMethodIngredient, CookingMethodIngredientViewModel>().ReverseMap();

            CreateMap<CookingStep, CookingStepViewModel>().ReverseMap();

            CreateMap<Ingredient, IngredientViewModel>().ReverseMap();

            CreateMap<Recipe, RecipeViewModel>().ReverseMap();

            CreateMap<RecipeCategory, RecipeCategoryViewModel>().ReverseMap();
        }
    }
}