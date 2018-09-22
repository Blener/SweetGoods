using GiftBagOfBases.Repositories;
using SweetGoods.Recipes.Domain.Interfaces.Commands;
using SweetGoods.Recipes.Domain.Models.Entities;
using SweetGoods.Recipes.Infra.Data.Context;

namespace SweetGoods.Recipes.Infra.Data.Repositories.Commands
{
    public class CategoryCommandRepository : CommandOnlyRepository<Category, SweetGoodsRecipesContext>, ICategoryCommandRepository
    {
        public CategoryCommandRepository(SweetGoodsRecipesContext db) : base(db)
        {
        }
    }
}