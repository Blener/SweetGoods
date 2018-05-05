using SweetGoods.Recipes.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace SweetGoods.Recipes.Domain.Events.Recipe
{
    public class RecipeCategoryAdded : Event
    {
        public RecipeCategoryAdded(Guid aggregateId, Guid categoryAggregateId)
        {
            AggregateId = aggregateId;
            CategoryAggregateId = categoryAggregateId;
        }

        public Guid CategoryAggregateId { get; }
    }
}