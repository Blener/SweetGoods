using Microsoft.EntityFrameworkCore;
using SweetGoods.Recipes.Domain.Core.Events;
using SweetGoods.Recipes.Infra.Data.Mappings;

namespace SweetGoods.Recipes.Infra.Data.Context
{
    public class EventStoreSQLContext : ContextBase<EventStoreSQLContext>
    {
        public EventStoreSQLContext(DbContextOptions<EventStoreSQLContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new StoredEventMap().Map(modelBuilder.Entity<StoredEvent>());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<StoredEvent> StoredEvent { get; set; }
    }
}