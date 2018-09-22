using GiftBagOfBases.Contexts;
using Microsoft.EntityFrameworkCore;

namespace SweetGoods.Recipes.Infra.Data.Context
{
    public class EventStoresSQLContextDesignTimeContextFactory : DesignTimeContextFactoryBase<EventStoreSQLContext>
    {
        protected override string ConnectionStringName => "SweetGoodsRecipesES";

        protected override EventStoreSQLContext CreateNewInstance(DbContextOptions<EventStoreSQLContext> options)
        {
            return new EventStoreSQLContext(options);
        }
    }
}