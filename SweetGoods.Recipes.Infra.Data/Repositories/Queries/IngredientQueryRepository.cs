using GiftBagOfBases.Repositories;
using Microsoft.EntityFrameworkCore;
using SweetGoods.Recipes.Domain.Interfaces.Queries;
using SweetGoods.Recipes.Domain.Models.Entities;
using SweetGoods.Recipes.Infra.Data.Context;
using System.Threading.Tasks;

namespace SweetGoods.Recipes.Infra.Data.Repositories.Queries
{
    public class IngredientQueryRepository : QueryOnlyRepository<Ingredient, SweetGoodsRecipesContext>, IIngredientQueryRepository
    {
        public IngredientQueryRepository(SweetGoodsRecipesContext db) : base(db)
        {
        }

        public Task<bool> NameExist(string name)
        {
            return DbSet.AnyAsync(x => x.Name.Name == name);
        }
    }
}