using GiftBagOfBases.Repositories;
using SweetGoods.Recipes.Domain.Interfaces.Queries;
using SweetGoods.Recipes.Domain.Models.Entities;
using SweetGoods.Recipes.Infra.Data.Context;

namespace SweetGoods.Recipes.Infra.Data.Repositories.Queries
{
    public class CookingMethodQueryRepository : QueryOnlyRepository<CookingMethod, SweetGoodsRecipesContext>, ICookingMethodQueryRepository
    {
        public CookingMethodQueryRepository(SweetGoodsRecipesContext db) : base(db)
        {
        }
    }
}