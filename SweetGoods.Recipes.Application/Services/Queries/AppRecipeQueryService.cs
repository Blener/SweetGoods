using SweetGoods.Recipes.Application.Interfaces.Queries;
using SweetGoods.Recipes.Application.ViewModels;
using SweetGoods.Recipes.Domain.Models.Entities;
using SweetGoods.Recipes.Domain.Interfaces.Queries;
using AutoMapper;

namespace SweetGoods.Recipes.Application.Services.Queries
{
    public class AppRecipeQueryService : AppQueryBaseService<Recipe, RecipeViewModel>, IAppRecipeQueryService
    {
        public AppRecipeQueryService(IQueryRepository<Recipe> queryRepository, IMapper mapper) : base(queryRepository, mapper)
        {
        }
    }
}