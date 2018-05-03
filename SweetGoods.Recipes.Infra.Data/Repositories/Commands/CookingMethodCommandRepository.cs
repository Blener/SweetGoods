using SweetGoods.Recipes.Domain.Interfaces.Commands;
using SweetGoods.Recipes.Domain.Models.Entities;
using SweetGoods.Recipes.Infra.Data.Context;

namespace SweetGoods.Recipes.Infra.Data.Repositories.Commands
{
    public class CookingMethodCommandRepository : CommandRepository<CookingMethod, SweetGoodsRecipesContext>, ICookingMethodCommandRepository
    {
        public CookingMethodCommandRepository(SweetGoodsRecipesContext db) : base(db)
        {
        }
    }
}