using Microsoft.EntityFrameworkCore;

namespace SweetGoods.Recipes.Infra.Data.Context
{
    public class SweetGoodsRecipesContext : ContextBase<SweetGoodsRecipesContext>
    {
        public SweetGoodsRecipesContext(DbContextOptions<SweetGoodsRecipesContext> options) : base(options)
        {
        }
    }
}