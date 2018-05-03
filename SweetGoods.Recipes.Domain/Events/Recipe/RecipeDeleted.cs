using SweetGoods.Recipes.Domain.Core.Events;
using System;

namespace SweetGoods.Recipes.Domain.Events.Recipe
{
    public class RecipeDeleted : Event
    {
        public RecipeDeleted(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }
    }
}