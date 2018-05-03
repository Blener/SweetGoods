using SweetGoods.Recipes.Domain.Models.ValueObjects;
using System;

namespace SweetGoods.Recipes.Domain.Commands.Ingredient
{
    public class UpdateIngredient : IngredientBaseCommand
    {
        public UpdateIngredient(Guid aggregateId, NameValueObject name, string details)
        {
            AggregateId = aggregateId;
            Name = name;
            Details = details;
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}