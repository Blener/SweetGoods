using GiftBagOfBases.Events;
using SweetGoods.Recipes.Domain.Models.ValueObjects;
using System;

namespace SweetGoods.Recipes.Domain.Events.CookingMethod
{
    public class NewCookingMethodAdded : Event
    {
        public NewCookingMethodAdded(Guid aggregateId, TimeSpan cookingTime, DescriptionValueObject description)
        {
            AggregateId = aggregateId;
            CookingTime = cookingTime;
            Description = description;
        }

        public TimeSpan CookingTime { get; }

        public DescriptionValueObject Description { get; }
    }
}