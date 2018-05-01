using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SweetGoods.Recipes.Domain.Core.Events;
using SweetGoods.Recipes.Infra.Data.Extensions;
using SweetGoods.Recipes.Infra.Data.Mappings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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