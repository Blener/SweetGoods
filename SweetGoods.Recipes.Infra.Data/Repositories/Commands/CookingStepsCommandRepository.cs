using GiftBagOfBases.Repositories;
using SweetGoods.Recipes.Domain.Interfaces.Commands;
using SweetGoods.Recipes.Domain.Models.Entities;
using SweetGoods.Recipes.Infra.Data.Context;

namespace SweetGoods.Recipes.Infra.Data.Repositories.Commands
{
    public class CookingStepsCommandRepository : CommandOnlyRepository<CookingStep, SweetGoodsRecipesContext>, ICookingStepsCommandRepository
    {
        public CookingStepsCommandRepository(SweetGoodsRecipesContext db) : base(db)
        {
        }
    }
}