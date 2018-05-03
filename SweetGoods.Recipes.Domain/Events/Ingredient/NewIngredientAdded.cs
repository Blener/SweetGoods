using SweetGoods.Recipes.Domain.Core.Events;
using SweetGoods.Recipes.Domain.Models.ValueObjects;
using System;

namespace SweetGoods.Recipes.Domain.Events.Ingredient
{
    public class NewIngredientAdded : Event
    {
        public NewIngredientAdded(Guid aggregateId, NameValueObject name, string details)
        {
            AggregateId = aggregateId;
            Name = name;
            Details = details;
        }

        public NameValueObject Name { get; }

        public string Details { get; }
    }
}