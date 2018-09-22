using GiftBagOfBases.Events;
using System;

namespace SweetGoods.Recipes.Domain.Events.Ingredient
{
    public class IngredientDeleted : Event
    {
        public IngredientDeleted(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }
    }
}