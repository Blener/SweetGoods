using SweetGoods.Recipes.Domain.Interfaces.Commands;
using SweetGoods.Recipes.Domain.Models.Entities;
using SweetGoods.Recipes.Infra.Data.Context;

namespace SweetGoods.Recipes.Infra.Data.Repositories.Commands
{
    public class RecipeCommandRepository : CommandRepository<Recipe, SweetGoodsRecipesContext>, IRecipeCommandRepository
    {
        public RecipeCommandRepository(SweetGoodsRecipesContext db) : base(db)
        {
        }
    }
}