using GiftBagOfBases.Events;
using System;

namespace SweetGoods.Recipes.Domain.Events.Ingredient
{
    public class DeletedIngredientRestored : Event
    {
        public DeletedIngredientRestored(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }
    }
}