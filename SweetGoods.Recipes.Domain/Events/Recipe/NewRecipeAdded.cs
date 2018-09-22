using GiftBagOfBases.Events;
using SweetGoods.Recipes.Domain.Models.ValueObjects;
using System;

namespace SweetGoods.Recipes.Domain.Events.Recipe
{
    public class NewRecipeAdded : Event
    {
        public NewRecipeAdded(Guid aggregateId, NameValueObject name, DescriptionValueObject description)
        {
            AggregateId = aggregateId;
            Name = name;
            Description = description;
        }

        public NameValueObject Name { get; }

        public DescriptionValueObject Description { get; }
    }
}