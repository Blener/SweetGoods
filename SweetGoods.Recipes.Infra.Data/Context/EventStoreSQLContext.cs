using Microsoft.EntityFrameworkCore;
using SweetGoods.Recipes.Domain.Core.Events;

namespace SweetGoods.Recipes.Infra.Data.Context
{
    public class EventStoreSQLContext : ContextBase<EventStoreSQLContext>
    {
        public EventStoreSQLContext(DbContextOptions<EventStoreSQLContext> options) : base(options)
        {
        }

        public DbSet<StoredEvent> StoredEvent { get; set; }
    }
}