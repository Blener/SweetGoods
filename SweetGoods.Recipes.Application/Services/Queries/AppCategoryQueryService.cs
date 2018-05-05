using AutoMapper;
using SweetGoods.Recipes.Application.Interfaces.Queries;
using SweetGoods.Recipes.Application.ViewModels;
using SweetGoods.Recipes.Domain.Models.Entities;
using SweetGoods.Recipes.Domain.Interfaces.Queries;

namespace SweetGoods.Recipes.Application.Services.Queries
{
    public class AppCategoryQueryService : AppQueryBaseService<Category, CategoryViewModel>, IAppCategoryQueryService
    {
        public AppCategoryQueryService(IQueryRepository<Category> queryRepository, IMapper mapper) : base(queryRepository, mapper)
        {
        }
    }
}