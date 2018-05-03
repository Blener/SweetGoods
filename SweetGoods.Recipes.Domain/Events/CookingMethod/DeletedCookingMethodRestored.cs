using SweetGoods.Recipes.Domain.Core.Events;
using System;

namespace SweetGoods.Recipes.Domain.Events.CookingMethod
{
    public class DeletedCookingMethodRestored : Event
    {
        public DeletedCookingMethodRestored(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }
    }
}