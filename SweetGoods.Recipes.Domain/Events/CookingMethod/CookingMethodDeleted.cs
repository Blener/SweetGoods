using GiftBagOfBases.Events;
using System;

namespace SweetGoods.Recipes.Domain.Events.CookingMethod
{
    public class CookingMethodDeleted : Event
    {
        public CookingMethodDeleted(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }
    }
}