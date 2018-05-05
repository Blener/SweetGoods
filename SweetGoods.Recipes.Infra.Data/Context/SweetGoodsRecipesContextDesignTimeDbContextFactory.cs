using Microsoft.EntityFrameworkCore;

namespace SweetGoods.Recipes.Infra.Data.Context
{
    public class SweetGoodsRecipesContextDesignTimeDbContextFactory : DesignTimeContextFactoryBase<SweetGoodsRecipesContext>
    {
        protected override string ConnectionStringName => "SweetGoodsRecipes";

        protected override SweetGoodsRecipesContext CreateNewInstance(DbContextOptions<SweetGoodsRecipesContext> options)
        {
            return new SweetGoodsRecipesContext(options);
        }
    }
}