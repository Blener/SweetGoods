using AutoMapper;
using SweetGoods.Recipes.Application.Interfaces.Queries;
using SweetGoods.Recipes.Application.ViewModels;
using SweetGoods.Recipes.Domain.Models.Entities;
using SweetGoods.Recipes.Domain.Interfaces.Queries;

namespace SweetGoods.Recipes.Application.Services.Queries
{
    public class AppCookingMethodQueryService : AppQueryBaseService<CookingMethod, CookingMethodViewModel>, IAppCookingMethodQueryService
    {
        public AppCookingMethodQueryService(IQueryRepository<CookingMethod> queryRepository, IMapper mapper) : base(queryRepository, mapper)
        {
        }
    }
}