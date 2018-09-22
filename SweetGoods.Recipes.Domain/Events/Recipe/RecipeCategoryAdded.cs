using GiftBagOfBases.Events;
using System;

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