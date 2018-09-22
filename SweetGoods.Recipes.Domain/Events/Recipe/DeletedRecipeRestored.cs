using GiftBagOfBases.Events;
using System;

namespace SweetGoods.Recipes.Domain.Events.Recipe
{
    public class DeletedRecipeRestored : Event
    {
        public DeletedRecipeRestored(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }
    }
}