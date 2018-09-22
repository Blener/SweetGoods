using GiftBagOfBases.Repositories;
using SweetGoods.Recipes.Domain.Interfaces.Commands;
using SweetGoods.Recipes.Domain.Models.Entities;
using SweetGoods.Recipes.Infra.Data.Context;

namespace SweetGoods.Recipes.Infra.Data.Repositories.Commands
{
    public class IngredientCommandRepository : CommandOnlyRepository<Ingredient, SweetGoodsRecipesContext>, IIngredientCommandRepository
    {
        public IngredientCommandRepository(SweetGoodsRecipesContext db) : base(db)
        {
        }
    }
}